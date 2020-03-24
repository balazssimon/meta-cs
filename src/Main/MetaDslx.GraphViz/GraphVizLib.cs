using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MetaDslx.GraphViz
{
    using Agraph_t = IntPtr;
    using Agdisc_t = IntPtr;
    using Agnode_t = IntPtr;
    using Agedge_t = IntPtr;
    using Agsym_t = IntPtr;

    using GVC_t = IntPtr;

    [Flags]
    internal enum Agdesc_t : byte
    {
        none = 0,
        directed = 1,
        strict = 1 << 1,
        no_loop = 1 << 2,
        maingraph = 1 << 3,
        flatlock = 1 << 4,
        no_write = 1 << 5,
        has_attrs = 1 << 6,
        has_cmpnd = 1 << 7,
    }

    internal class CGraphLib
    {
        private const string CGraphDll = @"cgraph.dll";

        public const int AGRAPH = 0;
        public const int AGNODE = 1;
        public const int AGOUTEDGE = 2;
        public const int AGINEDGE = 3;
        public const int AGEDGE = AGOUTEDGE;

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Agraph_t agopen(string name, Agdesc_t desc, Agdisc_t disc);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int agclose(Agraph_t g);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Agnode_t agnode(Agraph_t g, string name, bool createflag);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Agedge_t agedge(Agraph_t g, Agnode_t t, Agnode_t h, string name, bool createflag);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Agsym_t agattr(Agraph_t g, int kind, string name, string value);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr agget(IntPtr obj, string name);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr agxget(IntPtr obj, IntPtr sym);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int agset(IntPtr obj, string name, string value);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int agxset(IntPtr obj, IntPtr sym, string value);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr agattrsym(IntPtr obj, string name);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr agbindrec(IntPtr obj, string name, uint size, bool move_to_front);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Agraph_t agsubg(Agraph_t g, string name, bool cflag);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern long agdelsubg(Agraph_t g, Agraph_t sub);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int agdelnode(Agraph_t g, Agnode_t arg_n);

        [DllImport(CGraphDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int agdeledge(Agraph_t g, Agedge_t arg_e);

    }

    internal class GraphVizLib : IDisposable
    {
        private const string GvcDll = @"gvc.dll";
        private static object LockObject = new object();

        private static GraphVizLib _instance = new GraphVizLib();
        private GVC_t gvc;

        private GraphVizLib()
        {
            gvc = gvContextPlugins(IntPtr.Zero, true);
        }

        public static GraphVizLib Instance => _instance;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                gvFreeContext(gvc);

                disposedValue = true;
            }
        }

         ~GraphVizLib()
         {
           // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
           Dispose(false);
         }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern GVC_t gvContextPlugins(IntPtr builtins, bool demand_loading);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string[] gvcInfo(GVC_t gvc);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string gvcVersion(GVC_t gvc);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string gvcBuildDate(GVC_t gvc);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gvLayout(GVC_t gvc, Agraph_t g, string engine);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int attach_attrs(Agraph_t g);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gvFreeLayout(GVC_t gvc, Agraph_t g);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void gvFinalize(GVC_t gvc);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gvFreeContext(GVC_t gvc);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gvRenderData(GVC_t gvc, Agraph_t g, string format, ref IntPtr result, ref uint length);

        [DllImport(GvcDll, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gvFreeRenderData(IntPtr data);

        public string Layout(Agraph_t graph, string engine)
        {
            lock (LockObject)
            {
                gvLayout(gvc, graph, engine);
                attach_attrs(graph);
                IntPtr data = IntPtr.Zero;
                uint length = 0;
                gvRenderData(gvc, graph, "dot", ref data, ref length);
                var result = Marshal.PtrToStringAnsi(data);
                gvFreeRenderData(data);
                gvFreeLayout(gvc, graph);
                return result;
            }
        }

        public string ToString(Agraph_t graph, string format)
        {
            lock (LockObject)
            {
                IntPtr data = IntPtr.Zero;
                uint length = 0;
                gvRenderData(gvc, graph, format, ref data, ref length);
                var result = Marshal.PtrToStringAnsi(data);
                gvFreeRenderData(data);
                return result;
            }
        }
    }
}
