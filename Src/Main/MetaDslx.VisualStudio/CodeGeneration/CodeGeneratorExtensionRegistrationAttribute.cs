using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.CodeGeneration
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CodeGeneratorExtensionRegistrationAttribute : RegistrationAttribute
    {
        private Type generatorType;
        private string fileExtension;
        private string contextGuid;

        public CodeGeneratorExtensionRegistrationAttribute(Type generatorType, string fileExtension, string contextGuid)
        {
            this.generatorType = generatorType;
            this.fileExtension = fileExtension;
            this.contextGuid = contextGuid;
        }

        public override void Register(RegistrationContext context)
        {
            Key packageKey = null;
            try
            {
                packageKey = context.CreateKey(@"Generators\{" + this.contextGuid + @"}\" + this.fileExtension);
                packageKey.SetValue(string.Empty, generatorType.Name);
            }
            finally
            {
                if (packageKey != null)
                    packageKey.Close();
            }
        }

        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(@"Generators\{" + this.contextGuid + @"}\" + this.fileExtension);
        }
    }
}
