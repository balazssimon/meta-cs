using MetaDslx.Languages.Soal.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MetaDslx.Languages.Soal.Importer
{
    internal abstract class XmlReader
    {
        public string Uri { get; private set; }
        public XElement Root { get; private set; }
        public SoalImporter Importer { get; private set; }
        public NamespaceBuilder Namespace { get; protected set; }
        public SoalFactory Factory => this.Importer.Factory;
        public MutableModel Model => this.Importer.Model;
        public DiagnosticBag Diagnostics => this.Importer.Diagnostics;

        public XmlReader(SoalImporter importer, XElement root, string uri)
        {
            this.Importer = importer;
            this.Root = root;
            this.Uri = uri;
        }

        public LinePositionSpan GetLinePositionSpan(XObject xobj)
        {
            return SoalImporter.GetLinePositionSpan(xobj);
        }

        public XName GetXName(XElement elem, string reference)
        {
            string[] parts = reference.Split(':');
            if (parts.Length == 2)
            {
                XNamespace ns = elem.GetNamespaceOfPrefix(parts[0]);
                if (ns != null)
                {
                    return ns + parts[1];
                }
                else
                {
                    this.Importer.AddError("Invalid namespace prefix: " + parts[0], this.Uri, this.GetLinePositionSpan(elem));
                    return null;
                }
            }
            else if (parts.Length == 1)
            {
                XNamespace ns = elem.GetDefaultNamespace();
                return ns + parts[0];
            }
            else
            {
                return null;
            }
        }

        public abstract void CollectImportedFiles();

        public virtual void LoadXsdFile(int phase)
        {
        }

        public virtual void LoadWsdlFile(int phase)
        {
        }
    }
}
