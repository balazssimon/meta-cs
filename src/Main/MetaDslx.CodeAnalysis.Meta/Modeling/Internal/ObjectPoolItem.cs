using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling.Internal
{
#if DEBUG
    internal class IdCounter
    {
        internal static int s_id = 0;
    }
#endif

    public class ObjectPoolItem<TIntf, TImpl,TThis>
        where TImpl: ObjectPoolItem<TIntf, TImpl, TThis>, TIntf, new()
        where TIntf: class
        where TThis: class
    {
        private static ObjectPool<TImpl> s_pool = new ObjectPool<TImpl>(() => new TImpl());
        private TIntf _rootObject;
        private TThis _this;
        private int _referenceCounter;

#if DEBUG
        public ObjectPoolItem()
        {
            _Id = ++IdCounter.s_id;
        }

        public int _Id { get; }
#endif

        protected TIntf _RootObject => _rootObject;
        protected TThis _This => _this;

        public void _Init(TIntf rootObject, TThis state)
        {
            Debug.Assert(_rootObject == null);
            Debug.Assert(_this == null);
            Debug.Assert(_referenceCounter == 0);
            _rootObject = rootObject;
            _this = state;
            _referenceCounter = 1;
            Console.WriteLine("  INIT: "+_rootObject.GetType().Name);
        }

        public static TImpl _AllocateRoot(ref TImpl rootObject, TThis state)
        {
            if (rootObject != null) return rootObject;
            var newItem = s_pool.Allocate();
            newItem._Init(newItem, state);
            bool success = false;
            while (!success)
            {
                var oldItem = Interlocked.CompareExchange(ref rootObject, newItem, null);
                success = oldItem == null;
                if (!success)
                {
                    var oldCounter = oldItem._referenceCounter;
                    if (oldCounter > 0 && Interlocked.CompareExchange(ref oldItem._referenceCounter, oldCounter + 1, oldCounter) == oldCounter)
                    {
                        success = true;
                        s_pool.Free(newItem);
                    }
                }
            }
            return rootObject;
        }

        public static TImpl _Allocate(ref TImpl baseObject, TIntf rootObject, TThis state)
        {
            if (baseObject != null) return baseObject;
            var newItem = s_pool.Allocate();
            newItem._Init(rootObject, state);
            if (Interlocked.CompareExchange(ref baseObject, newItem, null) != null)
            {
                _Free(ref newItem);
            }
            return baseObject;
        }

        public virtual bool _Free()
        {
            var oldObject = _rootObject;
            var oldCounter = _referenceCounter;
            if (object.ReferenceEquals(this, oldObject) && oldCounter == 1 && 
                Interlocked.CompareExchange(ref _referenceCounter, oldCounter - 1, oldCounter) == oldCounter &&
                Interlocked.CompareExchange(ref _rootObject, null, oldObject) == oldObject)
            {
                var obj = (TImpl)oldObject;
                _Free(ref obj);
            }
            return false;
        }

        public static void _Free(ref TImpl obj)
        {
            var oldObject = obj;
            if (oldObject == null) return;
            if (Interlocked.CompareExchange(ref obj, null, oldObject) == oldObject)
            {
                Console.WriteLine("  FREE: " + oldObject.GetType().Name);
                oldObject._referenceCounter = 0;
                oldObject._this = null;
                oldObject._rootObject = null;
                s_pool.Free(oldObject);
            }
        }
    }

}
