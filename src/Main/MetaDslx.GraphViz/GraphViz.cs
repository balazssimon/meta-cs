using System;

namespace MetaDslx.GraphViz
{
    public static class GraphViz
    {
        internal static string GraphVizLibPath;

        public static void Initialize(string graphVizLibPath)
        {
            GraphVizLibPath = graphVizLibPath;
        }
    }
}
