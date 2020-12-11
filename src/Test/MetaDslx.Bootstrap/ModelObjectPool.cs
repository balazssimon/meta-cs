using MetaDslx.Modeling.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Bootstrap
{

    interface ObjectPoolItemZ
    {
        int _Id { get; }
        ObjectPoolItemZ ObjectPoolItemZ { get; }
    }

    interface ObjectPoolItemA : ObjectPoolItemZ
    {
        ObjectPoolItemA ObjectPoolItemA { get; }
    }

    interface ObjectPoolItemB : ObjectPoolItemZ
    {
        ObjectPoolItemB ObjectPoolItemB { get; }
    }

    interface ObjectPoolItemC : ObjectPoolItemA, ObjectPoolItemB
    {
        ObjectPoolItemC ObjectPoolItemC { get; }
    }

    interface ObjectPoolItemD : ObjectPoolItemC
    {
        ObjectPoolItemD ObjectPoolItemD { get; }
    }

    class ObjectPoolItemImplZ : ObjectPoolItem<ObjectPoolItemZ,ObjectPoolItemImplZ, object>, ObjectPoolItemZ
    {
        public ObjectPoolItemZ ObjectPoolItemZ => this;
    }

    class ObjectPoolItemImplA : ObjectPoolItem<ObjectPoolItemA, ObjectPoolItemImplA, object>, ObjectPoolItemA
    {
        private ObjectPoolItemImplZ _ObjectPoolItemZ;
        public ObjectPoolItemZ ObjectPoolItemZ => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplZ._Allocate(ref _ObjectPoolItemZ, _RootObject, _This) : _RootObject.ObjectPoolItemZ;
        public ObjectPoolItemA ObjectPoolItemA => this;

        public override bool _Free()
        {
            if (base._Free())
            {
                ObjectPoolItemImplZ._Free(ref _ObjectPoolItemZ);
                return true;
            }
            return false;
        }
    }

    class ObjectPoolItemImplB : ObjectPoolItem<ObjectPoolItemB, ObjectPoolItemImplB, object>, ObjectPoolItemB
    {
        private ObjectPoolItemImplZ _ObjectPoolItemZ;
        public ObjectPoolItemZ ObjectPoolItemZ => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplZ._Allocate(ref _ObjectPoolItemZ, _RootObject, _This) : _RootObject.ObjectPoolItemZ;
        public ObjectPoolItemB ObjectPoolItemB => this;

        public override bool _Free()
        {
            if (base._Free())
            {
                ObjectPoolItemImplZ._Free(ref _ObjectPoolItemZ);
                return true;
            }
            return false;
        }
    }

    class ObjectPoolItemImplC : ObjectPoolItem<ObjectPoolItemC, ObjectPoolItemImplC, object>, ObjectPoolItemC
    {
        private ObjectPoolItemImplZ _ObjectPoolItemZ;
        public ObjectPoolItemZ ObjectPoolItemZ => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplZ._Allocate(ref _ObjectPoolItemZ, _RootObject, _This) : _RootObject.ObjectPoolItemZ;
        private ObjectPoolItemImplA _ObjectPoolItemA;
        public ObjectPoolItemA ObjectPoolItemA => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplA._Allocate(ref _ObjectPoolItemA, _RootObject, _This) : _RootObject.ObjectPoolItemA;
        private ObjectPoolItemImplB _ObjectPoolItemB;
        public ObjectPoolItemB ObjectPoolItemB => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplB._Allocate(ref _ObjectPoolItemB, _RootObject, _This) : _RootObject.ObjectPoolItemB;
        public ObjectPoolItemC ObjectPoolItemC => this;

        public override bool _Free()
        {
            if (base._Free())
            {
                ObjectPoolItemImplB._Free(ref _ObjectPoolItemB);
                ObjectPoolItemImplA._Free(ref _ObjectPoolItemA);
                ObjectPoolItemImplZ._Free(ref _ObjectPoolItemZ);
                return true;
            }
            return false;
        }
    }

    class ObjectPoolItemImplD : ObjectPoolItem<ObjectPoolItemD, ObjectPoolItemImplD, object>, ObjectPoolItemD
    {
        private ObjectPoolItemImplZ _ObjectPoolItemZ;
        public ObjectPoolItemZ ObjectPoolItemZ => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplZ._Allocate(ref _ObjectPoolItemZ, _RootObject, _This) : _RootObject.ObjectPoolItemZ;
        private ObjectPoolItemImplA _ObjectPoolItemA;
        public ObjectPoolItemA ObjectPoolItemA => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplA._Allocate(ref _ObjectPoolItemA, _RootObject, _This) : _RootObject.ObjectPoolItemA;
        private ObjectPoolItemImplB _ObjectPoolItemB;
        public ObjectPoolItemB ObjectPoolItemB => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplB._Allocate(ref _ObjectPoolItemB, _RootObject, _This) : _RootObject.ObjectPoolItemB;
        private ObjectPoolItemImplC _ObjectPoolItemC;
        public ObjectPoolItemC ObjectPoolItemC => object.ReferenceEquals(this, _RootObject) ? ObjectPoolItemImplC._Allocate(ref _ObjectPoolItemC, _RootObject, _This) : _RootObject.ObjectPoolItemC;
        public ObjectPoolItemD ObjectPoolItemD => this;

        public override bool _Free()
        {
            if (base._Free())
            {
                ObjectPoolItemImplC._Free(ref _ObjectPoolItemC);
                ObjectPoolItemImplB._Free(ref _ObjectPoolItemB);
                ObjectPoolItemImplA._Free(ref _ObjectPoolItemA);
                ObjectPoolItemImplZ._Free(ref _ObjectPoolItemZ);
                return true;
            }
            return false;
        }
    }

}
