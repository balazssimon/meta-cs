using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class NormalizeByMetadata : Task
    {
        [Required]
        public ITaskItem[] Items
        {
            get;
            set;
        }

        [Required]
        public string MetadataName
        {
            get;
            set;
        }

        [Output]
        public ITaskItem[] NormalizedItems
        {
            get;
            private set;
        }

        public override bool Execute()
        {
            NormalizedItems = Items.Distinct(new ItemEqualityComparer(MetadataName)).ToArray();
            return true;
        }

        private sealed class ItemEqualityComparer : IEqualityComparer<ITaskItem>
        {
            private readonly string _metadataName;

            public ItemEqualityComparer(string metadataName)
            {
                Debug.Assert(metadataName != null);
                _metadataName = metadataName;
            }

            public bool Equals(ITaskItem x, ITaskItem y)
            {
                if (x == null || y == null)
                {
                    return x == y;
                }

                var xMetadata = x.GetMetadata(_metadataName);
                var yMetadata = y.GetMetadata(_metadataName);
                return string.Equals(xMetadata, yMetadata);
            }

            public int GetHashCode(ITaskItem obj)
            {
                if (obj == null)
                {
                    return 0;
                }

                var objMetadata = obj.GetMetadata(_metadataName);
                return objMetadata.GetHashCode();
            }
        }
    }
}
