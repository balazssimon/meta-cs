/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;
using System.Text;

namespace MetaDslx.VisualStudio
{
    /// <summary>
    /// A managed wrapper for VS's concept of an IVsSingleFileGenerator which is
    /// a custom tool invoked at design time which can take any file as an input
    /// and provide any file as output.
    /// </summary>
    public abstract class BaseCodeGenerator : IVsSingleFileGenerator
    {
        private IVsGeneratorProgress codeGeneratorProgress;
        private string codeFileNameSpace = string.Empty;
        private string codeFilePath = string.Empty;
        private string codeFileDirectory = string.Empty;
        private string codeFileName = string.Empty;
        private string codeFileContents = string.Empty;

        #region IVsSingleFileGenerator Members

        /// <summary>
        /// Implements the IVsSingleFileGenerator.DefaultExtension method. 
        /// Returns the extension of the generated file
        /// </summary>
        /// <param name="pbstrDefaultExtension">Out parameter, will hold the extension that is to be given to the output file name. The returned extension must include a leading period</param>
        /// <returns>S_OK if successful, E_FAIL if not</returns>
        int IVsSingleFileGenerator.DefaultExtension(out string pbstrDefaultExtension)
        {
            try
            {
                pbstrDefaultExtension = GetDefaultExtension();
                return VSConstants.S_OK;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not get default extension.");
                Debug.WriteLine(e.ToString());
                pbstrDefaultExtension = string.Empty;
                return VSConstants.E_FAIL;
            }
        }

        /// <summary>
        /// Implements the IVsSingleFileGenerator.Generate method.
        /// Executes the transformation and returns the newly generated output file, whenever a custom tool is loaded, or the input file is saved
        /// </summary>
        /// <param name="wszInputFilePath">The full path of the input file. May be a null reference (Nothing in Visual Basic) in future releases of Visual Studio, so generators should not rely on this value</param>
        /// <param name="bstrInputFileContents">The contents of the input file. This is either a UNICODE BSTR (if the input file is text) or a binary BSTR (if the input file is binary). If the input file is a text file, the project system automatically converts the BSTR to UNICODE</param>
        /// <param name="wszDefaultNamespace">This parameter is meaningful only for custom tools that generate code. It represents the namespace into which the generated code will be placed. If the parameter is not a null reference (Nothing in Visual Basic) and not empty, the custom tool can use the following syntax to enclose the generated code</param>
        /// <param name="rgbOutputFileContents">[out] Returns an array of bytes to be written to the generated file. You must include UNICODE or UTF-8 signature bytes in the returned byte array, as this is a raw stream. The memory for rgbOutputFileContents must be allocated using the .NET Framework call, System.Runtime.InteropServices.AllocCoTaskMem, or the equivalent Win32 system call, CoTaskMemAlloc. The project system is responsible for freeing this memory</param>
        /// <param name="pcbOutput">[out] Returns the count of bytes in the rgbOutputFileContent array</param>
        /// <param name="pGenerateProgress">A reference to the IVsGeneratorProgress interface through which the generator can report its progress to the project system</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns E_FAIL</returns>
        public virtual int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            if (bstrInputFileContents == null)
            {
                throw new ArgumentNullException(bstrInputFileContents);
            }

            codeFilePath = Path.GetFullPath(wszInputFilePath);
            codeFileName = Path.GetFileName(codeFilePath);
            codeFileDirectory = Path.GetDirectoryName(codeFilePath);
            codeFileNameSpace = wszDefaultNamespace;
            codeFileContents = bstrInputFileContents;
            codeGeneratorProgress = pGenerateProgress;

            rgbOutputFileContents = null;
            pcbOutput = 0;

            try
            {
                byte[] bytes = GenerateByteContent();

                if (bytes == null)
                {
                    // This signals that GenerateCode() has failed. Tasklist items have been put up in GenerateCode()
                    // Return E_FAIL to inform Visual Studio that the generator has failed (so that no file gets generated)
                    return VSConstants.E_FAIL;
                }
                else
                {
                    // The contract between IVsSingleFileGenerator implementors and consumers is that 
                    // any output returned from IVsSingleFileGenerator.Generate() is returned through  
                    // memory allocated via CoTaskMemAlloc(). Therefore, we have to convert the 
                    // byte[] array returned from GenerateCode() into an unmanaged blob.  

                    int outputLength = bytes.Length;
                    rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(outputLength);
                    Marshal.Copy(bytes, 0, rgbOutputFileContents[0], outputLength);
                    pcbOutput = (uint)outputLength;
                    return VSConstants.S_OK;
                }
            }
            catch (Exception ex)
            {
                pGenerateProgress.GeneratorError(0, 0, string.Format("[{2}] Could not process input file: {0}. Error: {1}", wszInputFilePath, ex.ToString(), this.GetType().Name), 0, 0);
            }
            return VSConstants.E_FAIL;
        }

        #endregion
        
        /// <summary>
        /// Namespace for the file
        /// </summary>
        protected string DefaultNamespace
        {
            get
            {
                return codeFileNameSpace;
            }
        }

        /// <summary>
        /// File-path for the input file
        /// </summary>
        protected string InputFilePath
        {
            get
            {
                return codeFilePath;
            }
        }

        /// <summary>
        /// Directory for the input file
        /// </summary>
        protected string InputFileDirectory
        {
            get
            {
                return codeFileDirectory;
            }
        }

        /// <summary>
        /// File name for the input file
        /// </summary>
        protected string InputFileName
        {
            get
            {
                return codeFileName;
            }
        }

        /// <summary>
        /// File name for the input file
        /// </summary>
        protected string InputFileContents
        {
            get
            {
                return codeFileContents;
            }
        }

        /// <summary>
        /// Interface to the VS shell object we use to tell our progress while we are generating
        /// </summary>
        internal IVsGeneratorProgress CodeGeneratorProgress
        {
            get
            {
                return codeGeneratorProgress;
            }
        }

        /// <summary>
        /// Gets the default extension for this generator
        /// </summary>
        /// <returns>String with the default extension for this generator</returns>
        protected abstract string GetDefaultExtension();

        /// <summary>
        /// The method that does the actual work of generating code given the input file
        /// </summary>
        /// <returns>The generated code file as a string</returns>
        public virtual string GenerateStringContent()
        {
            return "";
        }

        /// <summary>
        /// The method that does the actual work of generating code given the input file
        /// </summary>
        /// <returns>The generated code file as a byte-array</returns>
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

        /// <summary>
        /// Method that will communicate an error via the shell callback mechanism
        /// </summary>
        /// <param name="level">Level or severity</param>
        /// <param name="message">Text displayed to the user</param>
        /// <param name="line">Line number of error</param>
        /// <param name="column">Column number of error</param>
        protected virtual void GeneratorError(uint level, string message, uint line, uint column)
        {
            IVsGeneratorProgress progress = CodeGeneratorProgress;
            if (progress != null)
            {
                progress.GeneratorError(0, level, message, line, column);
            }
        }

        /// <summary>
        /// Method that will communicate a warning via the shell callback mechanism
        /// </summary>
        /// <param name="level">Level or severity</param>
        /// <param name="message">Text displayed to the user</param>
        /// <param name="line">Line number of warning</param>
        /// <param name="column">Column number of warning</param>
        protected virtual void GeneratorWarning(uint level, string message, uint line, uint column)
        {
            IVsGeneratorProgress progress = CodeGeneratorProgress;
            if (progress != null)
            {
                progress.GeneratorError(1, level, message, line, column);
            }
        }
    }
}