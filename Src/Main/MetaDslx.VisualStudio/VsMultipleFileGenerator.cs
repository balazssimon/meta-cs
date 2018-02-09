using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.VisualStudio.Shell.Interop;
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

    public abstract class SingleFileGenerator : BaseCodeGeneratorWithSite
    {

    }

    //public abstract class MultipleFileGenerator<T> : BaseCodeGeneratorWithSite
    //{
    //    public MultipleFileGenerator()
    //    {
    //    }

    //    public override int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
    //    {
    //        int result = base.Generate(wszInputFilePath, bstrInputFileContents, wszDefaultNamespace, rgbOutputFileContents, out pcbOutput, pGenerateProgress);
    //        if (result == VSConstants.S_OK)
    //        {
    //            try
    //            {
    //                string defaultFileName = generator.InputFileName;
    //                string defaultExt = null;
    //                if (this.DefaultExtension(out defaultExt) == VSConstants.S_OK)
    //                {
    //                    defaultFileName = Path.ChangeExtension(defaultFileName, defaultExt);
    //                }
    //                else
    //                {
    //                    defaultFileName = Path.GetFileNameWithoutExtension(defaultFileName);
    //                }

    //                var existingItems = sourceItems.GetItemsAsync().Result;

    //                // now we can start our work, iterate across all the 'elements' in our source file 
    //                foreach (MultipleFileItem<T> element in generator.GetFileItems())
    //                {
    //                    try
    //                    {
    //                        // obtain a name for this target file
    //                        string fileName = generator.GetFileName(element);
    //                        // add it to the tracking cache
    //                        newFileNames.Add(fileName);
    //                        // fully qualify the file on the filesystem
    //                        string strFile = Path.Combine(wszInputFilePath.Substring(0, wszInputFilePath.LastIndexOf(Path.DirectorySeparatorChar)), fileName);

    //                        if (!element.GeneratedExternally)
    //                        {
    //                            if (fileName == defaultFileName)
    //                            {
    //                                // generate our target file content
    //                                byte[] data = generator.GenerateByteContent(element);
    //                                if (data == null)
    //                                {
    //                                    rgbOutputFileContents[0] = IntPtr.Zero;
    //                                    pcbOutput = 0;
    //                                }
    //                                else
    //                                {
    //                                    // return our summary data, so that Visual Studio may write it to disk.
    //                                    rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(data.Length);
    //                                    Marshal.Copy(data, 0, rgbOutputFileContents[0], data.Length);
    //                                    pcbOutput = (uint)data.Length;
    //                                }
    //                            }
    //                            else
    //                            {
    //                                // create the file
    //                                FileStream fs = File.Create(strFile);
    //                                try
    //                                {
    //                                    // generate our target file content
    //                                    byte[] data = generator.GenerateByteContent(element);

    //                                    // write it out to the stream
    //                                    fs.Write(data, 0, data.Length);

    //                                    fs.Close();
    //                                }
    //                                catch (Exception ex)
    //                                {
    //                                    fs.Close();
    //                                    if (File.Exists(strFile))
    //                                    {
    //                                        File.Delete(strFile);
    //                                    }
    //                                    throw ex;
    //                                }
    //                            }
    //                        }

    //                        // add the newly generated file to the solution, as a child of the source file...
    //                        if (File.Exists(strFile) && fileName != defaultFileName)
    //                        {
    //                            bool newItem = true;
    //                            foreach (var item in existingItems)
    //                            {
    //                                if (item.EvaluatedIncludeAsFullPath == strFile)
    //                                {
    //                                    newItem = false;
    //                                    break;
    //                                }
    //                            }
    //                            if (newItem)
    //                            {
    //                                List<KeyValuePair<string, string>> metadata = new List<KeyValuePair<string, string>>();
    //                                metadata.Add(new KeyValuePair<string, string>("DependentUpon", inputFilePathInProject));
    //                                sourceItems.AddAsync(strFile, null, metadata).RunSynchronously();
    //                            }
    //                            /*EnvDTE.ProjectItem itm = item.ProjectItems.AddFromFile(strFile);

    //                            // embed as a resource:
    //                            if (element.EmbedResource)
    //                            {
    //                                itm.Properties.Item("BuildAction").Value = 3;
    //                            }

    //                            // set a custom tool:
    //                            if (!string.IsNullOrEmpty(element.CustomTool))
    //                            {
    //                                EnvDTE.Property prop = itm.Properties.Item("CustomTool");
    //                                if (string.IsNullOrEmpty((string)prop.Value) || !string.Equals((string)prop.Value, element.CustomTool))
    //                                {
    //                                    prop.Value = element.CustomTool;
    //                                }
    //                            }

    //                            foreach (var key in element.Properties.Keys)
    //                            {
    //                                string value = element.Properties[key];
    //                                EnvDTE.Property prop = itm.Properties.Item(key);
    //                                if (prop != null && string.IsNullOrEmpty((string)prop.Value) || !string.Equals((string)prop.Value, value))
    //                                {
    //                                    prop.Value = value;
    //                                }
    //                            }*/
    //                        }
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        throw ex;
    //                    }
    //                }

    //                List<IProjectItem> itemsToRemove = new List<IProjectItem>();
    //                foreach (var item in existingItems)
    //                {
    //                    string parentItem = item.Metadata.GetEvaluatedPropertyValueAsync("DependentUpon").Result;
    //                    if (parentItem == inputFilePathInProject)
    //                    {
    //                        if (!newFileNames.Contains(item.EvaluatedIncludeAsFullPath))
    //                        {
    //                            itemsToRemove.Add(item);
    //                        }
    //                    }
    //                }
    //                // perform some clean-up, making sure we delete any old (stale) target-files
    //                foreach (var item in itemsToRemove)
    //                {
    //                    sourceItems.RemoveAsync(item, DeleteOptions.DeleteFromStorage).RunSynchronously();
    //                }
    //                return VSConstants.S_OK;
    //            }
    //            catch (Exception ex)
    //            {
    //                pGenerateProgress.GeneratorError(0, 0, string.Format("[{2}] Could not process input file: {0}. Error: {1}", wszInputFilePath, ex.ToString(), this.GetType().Name), 0, 0);
    //            }
    //            return VSConstants.S_FALSE;
    //        }
    //        return result;
    //    }

    //}
}


