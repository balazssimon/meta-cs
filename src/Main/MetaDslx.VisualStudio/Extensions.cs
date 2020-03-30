using Microsoft.VisualStudio.ComponentModelHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    internal static class EditorExtensions
    {
        internal static IComponentModel GetComponentModel(this IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return null;
            }
            return (IComponentModel)serviceProvider.GetService(typeof(SComponentModel));
        }
    }
}
