using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.ProjectSystem;
using System.ComponentModel.Composition;

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
                this.InputDirectory = Path.GetDirectoryName(inputFilePath);
            }
            this.InputFileContents = inputFileContents;
            this.DefaultNamespace = defaultNamespace;
        }

        public string InputFileContents
        {
            get;
            private set;
        }

        public string InputFileName
        {
            get;
            private set;
        }

        public string InputDirectory
        {
            get;
            private set;
        }

        public string InputFilePath
        {
            get;
            private set;
        }

        public string DefaultNamespace
        {
            get;
            private set;
        }
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

        public string InputFileContents
        {
            get;
            private set;
        }

        public string InputFileName
        {
            get;
            private set;
        }

        public string InputFilePath
        {
            get;
            private set;
        }

        public string InputDirectory
        {
            get;
            private set;
        }

        public string DefaultNamespace
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
    }

    internal static class VSConstants
    {
        internal const int S_OK = 0;
        internal const int S_FALSE = 1;
        internal const int E_FAIL = -2147467259;
    }

    public abstract class VsSingleFileGenerator : IVsSingleFileGenerator
    {

        protected abstract SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace);
        public abstract string GetDefaultFileExtension();

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = this.GetDefaultFileExtension();
            if (!string.IsNullOrWhiteSpace(pbstrDefaultExtension))
            {
                return VSConstants.S_OK;
            }
            else
            {
                return VSConstants.S_FALSE;
            }
        }

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
                return VSConstants.S_OK;
            }
            catch (Exception ex)
            {
                pGenerateProgress.GeneratorError(0, 0, string.Format("[{2}] Could not process input file: {0}. Error: {1}", wszInputFilePath, ex.ToString(), this.GetType().Name), 0, 0);
            }
            return VSConstants.E_FAIL;
        }
    }

    public abstract class VsMultipleFileGenerator<T> : IVsSingleFileGenerator
    {
        [Import]
        IProjectService ProjectService { get; set; }

        public VsMultipleFileGenerator()
        {
        }

        protected abstract MultipleFileGenerator<T> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace);

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            rgbOutputFileContents[0] = IntPtr.Zero;
            pcbOutput = 0;
            try
            {
                string inputPath = Path.GetFullPath(wszInputFilePath);
                UnconfiguredProject project = null;
                foreach (var prj in this.ProjectService.LoadedUnconfiguredProjects)
                {
                    if (!prj.IsOutsideProjectDirectory(inputPath))
                    {
                        project = prj;
                        break;
                    }
                }
                if (project == null) return VSConstants.S_FALSE;

                ConfiguredProject configuredProject = project.Services.ActiveConfiguredProjectProvider.ActiveConfiguredProject;
                if (configuredProject == null) return VSConstants.S_FALSE;

                MultipleFileGenerator<T> generator = this.CreateGenerator(inputPath, bstrInputFileContents, wszDefaultNamespace);
                List<string> newFileNames = new List<string>();

                var sourceItems = configuredProject.Services.SourceItems;
                string inputFilePathInProject = project.MakeRelative(inputPath);

                string defaultFileName = generator.InputFileName;
                string defaultExt = null;
                if (this.DefaultExtension(out defaultExt) == VSConstants.S_OK)
                {
                    defaultFileName = Path.ChangeExtension(defaultFileName, defaultExt);
                }
                else
                {
                    defaultFileName = Path.GetFileNameWithoutExtension(defaultFileName);
                }

                var existingItems = sourceItems.GetItemsAsync().Result;

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
                            if (fileName == defaultFileName)
                            {
                                // generate our target file content
                                byte[] data = generator.GenerateByteContent(element);
                                if (data == null)
                                {
                                    rgbOutputFileContents[0] = IntPtr.Zero;
                                    pcbOutput = 0;
                                }
                                else
                                {
                                    // return our summary data, so that Visual Studio may write it to disk.
                                    rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(data.Length);
                                    Marshal.Copy(data, 0, rgbOutputFileContents[0], data.Length);
                                    pcbOutput = (uint)data.Length;
                                }
                            }
                            else
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
                                    {
                                        File.Delete(strFile);
                                    }
                                    throw ex;
                                }
                            }
                        }
                        
                        // add the newly generated file to the solution, as a child of the source file...
                        if (File.Exists(strFile) && fileName != defaultFileName)
                        {
                            bool newItem = true;
                            foreach (var item in existingItems)
                            {
                                if (item.EvaluatedIncludeAsFullPath == strFile)
                                {
                                    newItem = false;
                                    break;
                                }
                            }
                            if (newItem)
                            {
                                List<KeyValuePair<string, string>> metadata = new List<KeyValuePair<string, string>>();
                                metadata.Add(new KeyValuePair<string, string>("DependentUpon", inputFilePathInProject));
                                sourceItems.AddAsync(strFile, null, metadata).RunSynchronously();
                            }
                            /*EnvDTE.ProjectItem itm = item.ProjectItems.AddFromFile(strFile);

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
                            
                            foreach (var key in element.Properties.Keys)
                            {
                                string value = element.Properties[key];
                                EnvDTE.Property prop = itm.Properties.Item(key);
                                if (prop != null && string.IsNullOrEmpty((string)prop.Value) || !string.Equals((string)prop.Value, value))
                                {
                                    prop.Value = value;
                                }
                            }*/
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                List<IProjectItem> itemsToRemove = new List<IProjectItem>();
                foreach (var item in existingItems)
                {
                    string parentItem = item.Metadata.GetEvaluatedPropertyValueAsync("DependentUpon").Result;
                    if (parentItem == inputFilePathInProject)
                    {
                        if (!newFileNames.Contains(item.EvaluatedIncludeAsFullPath))
                        {
                            itemsToRemove.Add(item);
                        }
                    }
                }
                // perform some clean-up, making sure we delete any old (stale) target-files
                foreach (var item in itemsToRemove)
                {
                    sourceItems.RemoveAsync(item, DeleteOptions.DeleteFromStorage).RunSynchronously();
                }
            }
            catch (Exception ex)
            {
                pGenerateProgress.GeneratorError(0, 0, string.Format("[{2}] Could not process input file: {0}. Error: {1}", wszInputFilePath, ex.ToString(), this.GetType().Name), 0, 0);
            }
            return VSConstants.S_OK;
        }

        public abstract string GetDefaultFileExtension();

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = this.GetDefaultFileExtension();
            if (!string.IsNullOrWhiteSpace(pbstrDefaultExtension))
            {
                return VSConstants.S_OK;
            }
            else
            {
                return VSConstants.S_FALSE;
            }
        }

    }
}


