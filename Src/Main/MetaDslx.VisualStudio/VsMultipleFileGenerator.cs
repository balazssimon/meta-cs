using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;
using Microsoft.VisualStudio.Shell.Interop;

namespace MetaDslx.VisualStudio
{
    public class MultipleFileItem<T>
    {
        public MultipleFileItem()
        {
            this.Properties = new Dictionary<string, string>();
        }
        public T Info { get; set; }
        public string CustomTool { get; set; }
        public Dictionary<string,string> Properties { get; private set; }
        public bool EmbedResource { get; set; }
        public bool GeneratedExternally { get; set; }
    }

    public abstract class SingleFileGenerator
    {
        public SingleFileGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
        {
            this.InputFilePath = inputFilePath;
            if (inputFilePath != null)
            {
                this.InputFileName = Path.GetFileName(inputFilePath);
            }
            this.InputFileContents = inputFileContents;
            this.DefaultNamespace = defaultNamespace;
        }

        protected string InputFileContents
        {
            get;
            private set;
        }

        protected string InputFileName
        {
            get;
            private set;
        }

        protected string InputFilePath
        {
            get;
            private set;
        }

        protected string DefaultNamespace
        {
            get;
            private set;
        }
        public abstract string GetFileExtension();
        public virtual string GenerateStringContent()
        {
            return "";
        }
        public virtual byte[] GenerateByteContent()
        {
            string stringContent = this.GenerateStringContent();
            MemoryStream memory = new MemoryStream();
            StreamWriter writer = new StreamWriter(memory, Encoding.UTF8);
            writer.Write(stringContent);
            writer.Flush();
            memory.Flush();
            byte[] contents = new byte[memory.Length];
            memory.Position = 0;
            memory.Read(contents, 0, contents.Length);
            return contents;
        }
    }

    public abstract class MultipleFileGenerator<T>
    {
        public MultipleFileGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
        {
            if (inputFilePath != null)
            {
                this.InputFilePath = Path.GetFullPath(inputFilePath);
                this.InputFileName = Path.GetFileName(inputFilePath);
                this.InputDirectory = Path.GetDirectoryName(this.InputFilePath);
            }
            this.InputFileContents = inputFileContents;
            this.DefaultNamespace = defaultNamespace;
        }

        protected string InputFileContents
        {
            get;
            private set;
        }

        protected string InputFileName
        {
            get;
            private set;
        }

        protected string InputFilePath
        {
            get;
            private set;
        }

        protected string InputDirectory
        {
            get;
            private set;
        }

        protected string DefaultNamespace
        {
            get;
            private set;
        }

        public abstract IEnumerable<MultipleFileItem<T>> GetFileItems();
        public abstract string GetFileName(MultipleFileItem<T> element);
        public virtual string GenerateStringContent(MultipleFileItem<T> element)
        {
            return "";
        }
        public virtual byte[] GenerateByteContent(MultipleFileItem<T> element)
        {
            string stringContent = this.GenerateStringContent(element);
            MemoryStream memory = new MemoryStream();
            StreamWriter writer = new StreamWriter(memory, Encoding.UTF8);
            writer.Write(stringContent);
            writer.Flush();
            memory.Flush();
            byte[] contents = new byte[memory.Length];
            memory.Position = 0;
            memory.Read(contents, 0, contents.Length);
            return contents;
        }
        public abstract byte[] GenerateSummaryContent();
    }

    public abstract class VsSingleFileGenerator : IVsSingleFileGenerator, IObjectWithSite
    {
        private object site;
        #region IVsSingleFileGenerator Members
        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            SingleFileGenerator generator = this.CreateGenerator(null, null, null);
            pbstrDefaultExtension = generator.GetFileExtension();
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        protected abstract SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace);

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            rgbOutputFileContents[0] = IntPtr.Zero;
            pcbOutput = 0;
            try
            {
                SingleFileGenerator generator = this.CreateGenerator(wszInputFilePath, bstrInputFileContents, wszDefaultNamespace);
                byte[] contents = generator.GenerateByteContent();
                rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(contents.Length);
                Marshal.Copy(contents, 0, rgbOutputFileContents[0], contents.Length);
                pcbOutput = (uint)contents.Length;
                return Microsoft.VisualStudio.VSConstants.S_OK;
            }
            catch (Exception ex)
            {
                pGenerateProgress.GeneratorError(0, 0, string.Format("[{2}] Could not process input file: {0}. Error: {1}", wszInputFilePath, ex.ToString(), this.GetType().Name), 0, 0);
            }
            return Microsoft.VisualStudio.VSConstants.E_FAIL;
        }
        #endregion
        #region IObjectWithSite Members
        public void GetSite(ref Guid riid, out IntPtr ppvSite)
        {
            if (this.site == null)
            {
                throw new Win32Exception(-2147467259);
            }
            IntPtr objectPointer = Marshal.GetIUnknownForObject(this.site);
            try
            {
                Marshal.QueryInterface(objectPointer, ref riid, out ppvSite);
                if (ppvSite == IntPtr.Zero)
                {
                    throw new Win32Exception(-2147467262);
                }
            }
            finally
            {
                if (objectPointer != IntPtr.Zero)
                {
                    Marshal.Release(objectPointer);
                    objectPointer = IntPtr.Zero;
                }
            }
        }
        public void SetSite(object pUnkSite)
        {
            this.site = pUnkSite;
        }
        #endregion
    }

    public abstract class VsMultipleFileGenerator<T> : IVsSingleFileGenerator, IObjectWithSite
    {
        #region Visual Studio Specific Fields
        private object site;
        private ServiceProvider serviceProvider = null;
        #endregion

        #region Our Fields
        private EnvDTE.Project project;
        private List<string> newFileNames;
        #endregion

        protected EnvDTE.Project Project
        {
            get
            {
                return project;
            }
        }

        private ServiceProvider SiteServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleServiceProvider = site as Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
                    serviceProvider = new ServiceProvider(oleServiceProvider);
                }
                return serviceProvider;
            }
        }

        public VsMultipleFileGenerator()
        {
            newFileNames = new List<string>();
        }

        protected abstract MultipleFileGenerator<T> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace);

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            rgbOutputFileContents[0] = IntPtr.Zero;
            pcbOutput = 0;
            string inputPath = Path.GetFullPath(wszInputFilePath);
            if (project == null)
            {
                EnvDTE.DTE dte = (EnvDTE.DTE)Package.GetGlobalService(typeof(EnvDTE.DTE));
                EnvDTE.Projects projects = dte.Solution.Projects;
                if (projects.Count > 0)
                {
                    foreach (var prjObj in projects)
                    {
                        EnvDTE.Project prj = prjObj as EnvDTE.Project;
                        if (prj != null)
                        {
                            string projectPath = Path.GetFullPath(Path.GetDirectoryName(prj.FullName));
                            if (inputPath.StartsWith(projectPath))
                            {
                                project = prj;
                                break;
                            }
                        }
                    }
                }
            }
            if (project == null) return Microsoft.VisualStudio.VSConstants.S_FALSE;
            try
            {
                MultipleFileGenerator<T> generator = this.CreateGenerator(wszInputFilePath, bstrInputFileContents, wszDefaultNamespace);
                this.newFileNames.Clear();

                int iFound = 0;
                uint itemId = 0;
                EnvDTE.ProjectItem item;
                Microsoft.VisualStudio.Shell.Interop.VSDOCUMENTPRIORITY[] pdwPriority = new Microsoft.VisualStudio.Shell.Interop.VSDOCUMENTPRIORITY[1];

                // obtain a reference to the current project as an IVsProject type
                Microsoft.VisualStudio.Shell.Interop.IVsProject VsProject = VsHelper.ToVsProject(project);
                // this locates, and returns a handle to our source file, as a ProjectItem
                VsProject.IsDocumentInProject(wszInputFilePath, out iFound, pdwPriority, out itemId);


                // if our source file was found in the project (which it should have been)
                if (iFound != 0 && itemId != 0)
                {
                    Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleSp = null;
                    VsProject.GetItemContext(itemId, out oleSp);
                    if (oleSp != null)
                    {
                        ServiceProvider sp = new ServiceProvider(oleSp);
                        // convert our handle to a ProjectItem
                        item = sp.GetService(typeof(EnvDTE.ProjectItem)) as EnvDTE.ProjectItem;
                    }
                    else
                        throw new ApplicationException("Unable to retrieve Visual Studio ProjectItem");
                }
                else
                    throw new ApplicationException("Unable to retrieve Visual Studio ProjectItem");

                // now we can start our work, iterate across all the 'elements' in our source file 
                foreach (MultipleFileItem<T> element in generator.GetFileItems())
                {
                    try
                    {
                        // obtain a name for this target file
                        string fileName = generator.GetFileName(element);
                        // add it to the tracking cache
                        newFileNames.Add(fileName);
                        // fully qualify the file on the filesystem
                        string strFile = Path.Combine(wszInputFilePath.Substring(0, wszInputFilePath.LastIndexOf(Path.DirectorySeparatorChar)), fileName);

                        if (!element.GeneratedExternally)
                        {
                            // create the file
                            FileStream fs = File.Create(strFile);
                            try
                            {
                                // generate our target file content
                                byte[] data = generator.GenerateByteContent(element);

                                // write it out to the stream
                                fs.Write(data, 0, data.Length);

                                fs.Close();
                            }
                            catch (Exception ex)
                            {
                                fs.Close();
                                if (File.Exists(strFile))
                                    File.Delete(strFile);
                                throw ex;
                            }
                        }

                        // add the newly generated file to the solution, as a child of the source file...
                        EnvDTE.ProjectItem itm = item.ProjectItems.AddFromFile(strFile);

                        // embed as a resource:
                        if (element.EmbedResource)
                        {
                            itm.Properties.Item("BuildAction").Value = 3;
                        }

                        // set a custom tool:
                        if (!string.IsNullOrEmpty(element.CustomTool))
                        {
                            EnvDTE.Property prop = itm.Properties.Item("CustomTool");
                            if (string.IsNullOrEmpty((string)prop.Value) || !string.Equals((string)prop.Value, element.CustomTool))
                            {
                                prop.Value = element.CustomTool;
                            }
                        }
                        /*foreach (var key in element.Properties.Keys)
                        {
                            string value = element.Properties[key];
                            EnvDTE.Property prop = itm.Properties.Item(key);
                            if (prop != null && string.IsNullOrEmpty((string)prop.Value) || !string.Equals((string)prop.Value, value))
                            {
                                prop.Value = value;
                            }
                        }*/

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                // perform some clean-up, making sure we delete any old (stale) target-files
                foreach (EnvDTE.ProjectItem childItem in item.ProjectItems)
                {
                    string defaultExt;
                    this.DefaultExtension(out defaultExt);
                    if ((childItem.Name != Path.ChangeExtension(wszInputFilePath, defaultExt)) && !newFileNames.Contains(childItem.Name))
                        // then delete it
                        childItem.Delete();
                }

                // generate our summary content for our 'single' file
                byte[] summaryData = generator.GenerateSummaryContent();

                if (summaryData == null)
                {
                    rgbOutputFileContents[0] = IntPtr.Zero;
                    pcbOutput = 0;
                }
                else
                {
                    // return our summary data, so that Visual Studio may write it to disk.
                    rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(summaryData.Length);
                    Marshal.Copy(summaryData, 0, rgbOutputFileContents[0], summaryData.Length);
                    pcbOutput = (uint)summaryData.Length;
                }
            }
            catch (Exception ex)
            {
                pGenerateProgress.GeneratorError(0, 0, string.Format("[{2}] Could not process input file: {0}. Error: {1}", wszInputFilePath, ex.ToString(), this.GetType().Name), 0, 0);
            }
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        #region IObjectWithSite Members

        public void GetSite(ref Guid riid, out IntPtr ppvSite)
        {
            if (this.site == null)
            {
                throw new Win32Exception(-2147467259);
            }

            IntPtr objectPointer = Marshal.GetIUnknownForObject(this.site);

            try
            {
                Marshal.QueryInterface(objectPointer, ref riid, out ppvSite);
                if (ppvSite == IntPtr.Zero)
                {
                    throw new Win32Exception(-2147467262);
                }
            }
            finally
            {
                if (objectPointer != IntPtr.Zero)
                {
                    Marshal.Release(objectPointer);
                    objectPointer = IntPtr.Zero;
                }
            }
        }

        public void SetSite(object pUnkSite)
        {
            this.site = pUnkSite;
        }

        #endregion


        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            //pbstrDefaultExtension = ".txt";
            pbstrDefaultExtension = null;
            return Microsoft.VisualStudio.VSConstants.S_FALSE;
        }

    }
}


