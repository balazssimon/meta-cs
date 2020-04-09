using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    public class ReferencesTag : ITag
    {
        public ReferencesTag(ImmutableArray<SnapshotSpan> references)
        {
            References = references;
        }

        public readonly ImmutableArray<SnapshotSpan> References;
    }
}
