using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    public abstract class ErrorCode : IEquatable<ErrorCode>
    {
        private string category;
        private int id;
        private DiagnosticSeverity defaultSeverity;
        private int warningLevel;
        private string defaultMessage;

        public ErrorCode(string category, int id, DiagnosticSeverity defaultSeverity, int warningLevel, string defaultMessage)
        {
            this.id = id;
            this.defaultSeverity = defaultSeverity;
            this.defaultMessage = defaultMessage;
        }

        public string Category
        {
            get { return this.category; }
        }

        public int Id
        {
            get { return this.id; }
        }

        public DiagnosticSeverity DefaultSeverity
        {
            get { return this.defaultSeverity; }
        }

        public int WarningLevel
        {
            get { return this.warningLevel; }
        }

        public string DefaultMessage
        {
            get { return this.defaultMessage; }
        }

        public bool Equals(ErrorCode other)
        {
            if (other == null) return false;
            return other.GetType() == this.GetType() && other.id == this.id && other.category == this.category;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ErrorCode);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(Hash.Combine(this.GetType().GetHashCode(), this.category.GetHashCode()), this.id);
        }
    }

}
