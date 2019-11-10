using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace MetaDslx.Languages.Meta.Model
{
    public static class ImmutableMetaModelExtensions
    {
        public static IReadOnlyList<string> GetDocumentationLines(this MetaDocumentedElement documentedElement)
        {
            if (documentedElement.Documentation == null) return ImmutableList<string>.Empty;
            List<string> result = new List<string>();
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(documentedElement.Documentation);
            writer.Flush();
            stream.Position = 0;
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        result.Add(line);
                    }
                }
            }
            return result;
        }
    }
}
