using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel.Composition;
using EnvDTE;

namespace MetaDslx.VisualStudio
{
    public class MultipleFileItem
    {
        public MultipleFileItem(string filePath, bool isDefault)
        {
            this.Properties = new Dictionary<string, string>();
            this.IsDefault = isDefault;
            this.FilePath = filePath;
            this.FileName = Path.GetFileName(filePath);
            this.DependUponInputFile = true;
        }

        public bool IsDefault { get; }
        public string FileName { get; }
        public string FilePath { get; }
        public string CustomTool { get; set; }
        public Dictionary<string,string> Properties { get; }
        public bool EmbedResource { get; set; }
        public bool DependUponInputFile { get; set; }
        public bool GeneratedExternally { get; set; }
    }


    internal static class VSConstants
    {
        internal const int S_OK = 0;
        internal const int S_FALSE = 1;
        internal const int E_FAIL = -2147467259;
    }

    [ComVisible(true)]
    public abstract class SingleFileGenerator : BaseCodeGeneratorWithSite
    {

    }

    [ComVisible(true)]
    public abstract class MultipleFileGenerator<TFileItem> : BaseCodeGeneratorWithSite
        where TFileItem : MultipleFileItem
    {
        private IEnumerable<TFileItem> fileItems;

        public MultipleFileGenerator()
        {
        }

        protected string FilePathWithoutExtension
        {
            get { return Path.Combine(this.InputFileDirectory, Path.GetFileNameWithoutExtension(this.InputFileName)); }
        }

        public override int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            int result = base.Generate(wszInputFilePath, bstrInputFileContents, wszDefaultNamespace, rgbOutputFileContents, out pcbOutput, pGenerateProgress);
            if (result == VSConstants.S_OK)
            {
                try
                {
                    string defaultFileName = this.InputFileName;
                    string defaultExt = this.GetDefaultExtension();
                    if (!string.IsNullOrEmpty(defaultExt))
                    {
                        defaultFileName = Path.ChangeExtension(defaultFileName, defaultExt);
                    }
                    else
                    {
                        defaultFileName = Path.GetFileNameWithoutExtension(defaultFileName);
                    }

                    var project = this.GetProject();
                    var inputProjectItem = this.GetProjectItem();
                    List<string> newFileNames = new List<string>();
                    // now we can start our work, iterate across all the 'elements' in our source file 
                    foreach (TFileItem item in this.GetFileItems())
                    {
                        if (item.IsDefault) continue;
                        try
                        {
                            if (item.GeneratedExternally)
                            {
                                newFileNames.Add(item.FileName);
                            }
                            else
                            {
                                FileStream fs = File.Create(item.FilePath);
                                try
                                {
                                    byte[] data = this.GenerateByteContent(item);
                                    fs.Write(data, 0, data.Length);
                                    fs.Close();
                                    if (item.DependUponInputFile)
                                    {
                                        newFileNames.Add(item.FileName);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    fs.Close();
                                    if (File.Exists(item.FilePath))
                                    {
                                        File.Delete(item.FilePath);
                                    }
                                    throw ex;
                                }
                            }

                            // add the newly generated file to the solution, as a child of the source file...
                            if (File.Exists(item.FilePath))
                            {
                                ProjectItem projectItem = null;
                                projectItem = FindItemByFilePath(project.ProjectItems, item.FilePath, true);
                                if (projectItem == null)
                                {
                                    if (item.DependUponInputFile)
                                    {
                                        projectItem = inputProjectItem.ProjectItems.AddFromFile(item.FilePath);
                                    }
                                    else
                                    {
                                        projectItem = project.ProjectItems.AddFromFile(item.FilePath);
                                    }
                                }

                                // embed as a resource:
                                if (item.EmbedResource)
                                {
                                    projectItem.Properties.Item("BuildAction").Value = 3;
                                }

                                // set a custom tool:
                                if (!string.IsNullOrEmpty(item.CustomTool))
                                {
                                    string customTool = item.Properties["CustomTool"];
                                    if (string.IsNullOrEmpty(customTool) || !string.Equals(customTool, item.CustomTool))
                                    {
                                        item.Properties["CustomTool"] = item.CustomTool;
                                    }
                                }

                                foreach (var key in item.Properties.Keys)
                                {
                                    string value = item.Properties[key];
                                    if (string.IsNullOrEmpty((string)value) || !string.Equals((string)value, value))
                                    {
                                        item.Properties[key] = value;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    List<ProjectItem> itemsToRemove = new List<ProjectItem>();
                    foreach (ProjectItem projectItem in inputProjectItem.ProjectItems)
                    {
                        if (!newFileNames.Contains(projectItem.Name))
                        {
                            itemsToRemove.Add(projectItem);
                        }
                    }
                    // perform some clean-up, making sure we delete any old (stale) target-files
                    foreach (var projectItem in itemsToRemove)
                    {
                        projectItem.Delete();
                    }
                    return VSConstants.S_OK;
                }
                catch (Exception ex)
                {
                    this.GeneratorError(0, string.Format("[{2}] Could not process input file: {0}. Error: {1}", wszInputFilePath, ex.ToString(), this.GetType().Name), 0, 0);
                }
                return VSConstants.S_FALSE;
            }
            return result;
        }

        protected abstract IEnumerable<TFileItem> Compile();

        protected IEnumerable<TFileItem> GetFileItems()
        {
            return this.fileItems;
        }

        public sealed override string GenerateStringContent()
        {
            return base.GenerateStringContent();
        }

        public sealed override byte[] GenerateByteContent()
        {
            this.fileItems = this.Compile();
            foreach (TFileItem item in this.GetFileItems())
            {
                if (item.IsDefault)
                {
                    return this.GenerateByteContent(item);
                }
            }
            return new byte[0];
        }

        /// <summary>
        /// The method that does the actual work of generating code given the input file
        /// </summary>
        /// <returns>The generated code file as a string</returns>
        public virtual string GenerateStringContent(TFileItem item)
        {
            return "";
        }

        /// <summary>
        /// The method that does the actual work of generating code given the input file
        /// </summary>
        /// <returns>The generated code file as a byte-array</returns>
        public virtual byte[] GenerateByteContent(TFileItem item)
        {
            string stringContent = this.GenerateStringContent(item);
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


        /// <summary>
        /// Finds a <see cref="ProjectItem"/> by name. 
        /// The comparison is not case sensitive.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The file path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns></returns>
        public static ProjectItem FindItemByFilePath(ProjectItems collection, string filePath, bool recursive)
        {
            if (collection != null)
            {
                foreach (ProjectItem item1 in collection)
                {
                    if (string.Compare((string)item1.Properties.Item("FullPath")?.Value, filePath, true) == 0)
                    {
                        return item1;
                    }
                    if (recursive)
                    {
                        ProjectItem item2 = FindItemByFilePath(item1.ProjectItems, filePath, recursive);
                        if (item2 != null)
                        {
                            return item2;
                        }
                    }
                }
            }
            return null;
        }
    }
}


