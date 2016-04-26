using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MetaDslx.Core.Immutable;
using System.Collections.Generic;

namespace MetaDslx.Core.Test
{
    /*
    public class ImmutableTestModelFactory
    {
        public ImmutableHusband CreateHusband(ref ImmutableModel model)
        {
            return new ImmutableHusbandImpl(ref model);
        }

        public ImmutableWife CreateWife(ref ImmutableModel model)
        {
            return new ImmutableWifeImpl(ref model);
        }

        public ImmutableListParent CreateListParent(ref ImmutableModel model)
        {
            return new ImmutableListParentImpl(ref model);
        }

        public ImmutableListChild CreateListChild(ref ImmutableModel model)
        {
            return new ImmutableListChildImpl(ref model);
        }
    }

    public class ImmutableTestModelBuilderFactory
    {
        public ImmutableModel.Builder Builder { get; private set; }

        public ImmutableTestModelBuilderFactory()
        {
            this.Builder = ImmutableModel.CreateBuilder();
        }

        public ImmutableTestModelBuilderFactory(ImmutableModel.Builder modelBuilder)
        {
            this.Builder = modelBuilder;
        }

        public ImmutableHusbandBuilder CreateHusband()
        {
            return new ImmutableHusbandImpl(this.Builder).ToBuilder(this.Builder);
        }

        public ImmutableWifeBuilder CreateWife()
        {
            return new ImmutableWifeImpl(this.Builder).ToBuilder(this.Builder);
        }

        public ImmutableListParentBuilder CreateListParent()
        {
            return new ImmutableListParentImpl(this.Builder).ToBuilder(this.Builder);
        }

        public ImmutableListChildBuilder CreateListChild()
        {
            return new ImmutableListChildImpl(this.Builder).ToBuilder(this.Builder);
        }

        public ImmutableHusband GetHusband(ImmutableModel model, ImmutableHusbandBuilder builder)
        {
            return (ImmutableHusband)model.GetObject((IImmutableObjectBuilder)builder);
        }

        public ImmutableWife GetWife(ImmutableModel model, ImmutableWifeBuilder builder)
        {
            return (ImmutableWife)model.GetObject((IImmutableObjectBuilder)builder);
        }

        public ImmutableListParent GetListParent(ImmutableModel model, ImmutableListParentBuilder builder)
        {
            return (ImmutableListParent)model.GetObject((IImmutableObjectBuilder)builder);
        }

        public ImmutableListChild GetListChild(ImmutableModel model, ImmutableListChildBuilder builder)
        {
            return (ImmutableListChild)model.GetObject((IImmutableObjectBuilder)builder);
        }
    }

    public interface ImmutableHusband
    {
        string Name { get; }
        ImmutableWife Wife { get; }
    }

    public interface ImmutableHusbandBuilder
    {
        string Name { get; set; }
        ImmutableWifeBuilder Wife { get; set; }
    }

    internal class ImmutableHusbandImpl : ImmutableObject, ImmutableHusband
    {
        internal ImmutableHusbandImpl(ImmutableModel model, ImmutableObject oldObject)
            : base(model, oldObject)
        {
        }

        internal ImmutableHusbandImpl(ref ImmutableModel model)
            : base(ref model)
        {
        }

        internal ImmutableHusbandImpl(ImmutableModel.Builder modelBuilder)
            : base(modelBuilder)
        {
        }

        public static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(ImmutableHusbandImpl));

        public string Name
        {
            get { return (string)this.MModel.Get(this, ImmutableHusbandImpl.NameProperty); }
        }

        [OppositeAttribute(typeof(ImmutableWifeImpl), "Husband")]
        public static readonly ModelProperty WifeProperty =
            ModelProperty.Register("Wife", typeof(ImmutableWifeImpl), typeof(ImmutableHusbandImpl));

        public ImmutableWife Wife
        {
            get { return (ImmutableWife)this.MModel.Get(this, ImmutableHusbandImpl.WifeProperty); }
        }

        public ImmutableHusbandBuilder ToBuilder(ImmutableModel.Builder modelBuilder)
        {
            return (ImmutableHusbandBuilder)modelBuilder.GetObject(this);
        }

        protected override IImmutableObjectBuilder CreateBuilder(ImmutableModel.Builder modelBuilder)
        {
            return new Builder(modelBuilder, this);
        }

        public override ImmutableObject MWithModel(ImmutableModel model)
        {
            return new ImmutableHusbandImpl(model, this);
        }

        new private class Builder : ImmutableObject.Builder, ImmutableHusbandBuilder
        {
            public Builder(ImmutableModel.Builder modelBuilder, ImmutableHusbandImpl obj)
                : base(modelBuilder, obj)
            {
            }

            public string Name
            {
                get
                {
                    return (string)this.MGet(ImmutableHusbandImpl.NameProperty);
                }
                set
                {
                    this.MSet(ImmutableHusbandImpl.NameProperty, value);
                }
            }

            public ImmutableWifeBuilder Wife
            {
                get
                {
                    return (ImmutableWifeBuilder)this.MGet(ImmutableHusbandImpl.WifeProperty);
                }
                set
                {
                    this.MSet(ImmutableHusbandImpl.WifeProperty, value);
                }
            }

            public override ImmutableObject ToImmutable()
            {
                return new ImmutableHusbandImpl(this.MModelBuilder.GetNewModel(this.MObject.MModel), this.MObject);
            }
        }
    }

    public interface ImmutableWife
    {
        string Name { get; }
        ImmutableHusband Husband { get; }
    }

    public interface ImmutableWifeBuilder
    {
        string Name { get; set; }
        ImmutableHusbandBuilder Husband { get; set; }
    }

    internal class ImmutableWifeImpl : ImmutableObject, ImmutableWife
    {
        internal ImmutableWifeImpl(ImmutableModel model, ImmutableObject oldObject)
            : base(model, oldObject)
        {
        }

        internal ImmutableWifeImpl(ref ImmutableModel model)
            : base(ref model)
        {

        }

        internal ImmutableWifeImpl(ImmutableModel.Builder modelBuilder)
            : base(modelBuilder)
        {
        }

        public static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(ImmutableWifeImpl));

        public string Name
        {
            get { return (string)this.MModel.Get(this, ImmutableWifeImpl.NameProperty); }
        }

        [OppositeAttribute(typeof(ImmutableHusbandImpl), "Wife")]
        public static readonly ModelProperty HusbandProperty =
            ModelProperty.Register("Husband", typeof(ImmutableHusbandImpl), typeof(ImmutableWifeImpl));

        public ImmutableHusband Husband
        {
            get { return (ImmutableHusband)this.MModel.Get(this, ImmutableWifeImpl.HusbandProperty); }
        }

        public ImmutableWifeBuilder ToBuilder(ImmutableModel.Builder modelBuilder)
        {
            return (ImmutableWifeBuilder)modelBuilder.GetObject(this);
        }

        protected override IImmutableObjectBuilder CreateBuilder(ImmutableModel.Builder modelBuilder)
        {
            return new Builder(modelBuilder, this);
        }

        public override ImmutableObject MWithModel(ImmutableModel model)
        {
            return new ImmutableWifeImpl(model, this);
        }

        new private class Builder : ImmutableObject.Builder, ImmutableWifeBuilder
        {
            public Builder(ImmutableModel.Builder modelBuilder, ImmutableWifeImpl obj)
                : base(modelBuilder, obj)
            {
            }

            public string Name
            {
                get
                {
                    return (string)this.MGet(ImmutableWifeImpl.NameProperty);
                }
                set
                {
                    this.MSet(ImmutableWifeImpl.NameProperty, value);
                }
            }

            public ImmutableHusbandBuilder Husband
            {
                get
                {
                    return (ImmutableHusbandBuilder)this.MGet(ImmutableWifeImpl.HusbandProperty);
                }
                set
                {
                    this.MSet(ImmutableWifeImpl.HusbandProperty, value);
                }
            }

            public override ImmutableObject ToImmutable()
            {
                return new ImmutableWifeImpl(this.MModelBuilder.GetNewModel(this.MObject.MModel), this.MObject);
            }
        }
    }

    public interface ImmutableListParent
    {
        ImmutableModelArray<ImmutableListChild> Children { get; }
    }

    public interface ImmutableListParentBuilder
    {
        ImmutableModelList<ImmutableListChild>.Builder Children { get; }
    }

    internal class ImmutableListParentImpl : ImmutableObject, ImmutableListParent
    {
        internal ImmutableListParentImpl(ImmutableModel model, ImmutableObject oldObject)
            : base(model, oldObject)
        {
        }

        internal ImmutableListParentImpl(ref ImmutableModel model)
            : base(ref model)
        {
        }

        internal ImmutableListParentImpl(ImmutableModel.Builder modelBuilder)
            : base(modelBuilder)
        {
            this.Init();
        }

        private void Init()
        {
            //this.MSet(ImmutableListParentImpl.ChildrenProperty, new ImmutableModelList<ImmutableListChild>());
        }

        [OppositeAttribute(typeof(ImmutableListChildImpl), "Parent")]
        public static readonly ModelProperty ChildrenProperty =
            ModelProperty.Register("Children", typeof(ImmutableModelList<ImmutableListChild>), typeof(ImmutableListParentImpl));

        public ImmutableModelArray<ImmutableListChild> Children
        {
            get { return (ImmutableModelArray<ImmutableListChild>)this.MModel.Get(this, ImmutableListParentImpl.ChildrenProperty); }
        }

        public override ImmutableObject MWithModel(ImmutableModel model)
        {
            return new ImmutableListParentImpl(model, this);
        }

        protected override IImmutableObjectBuilder CreateBuilder(ImmutableModel.Builder modelBuilder)
        {
            return new Builder(modelBuilder, this);
        }

        public ImmutableListParentBuilder ToBuilder(ImmutableModel.Builder modelBuilder)
        {
            return (ImmutableListParentBuilder)modelBuilder.GetObject(this);
        }

        new private class Builder : ImmutableObject.Builder, ImmutableListParentBuilder
        {
            public Builder(ImmutableModel.Builder modelBuilder, ImmutableListParentImpl obj)
                : base(modelBuilder, obj)
            {
            }

            public ImmutableModelList<ImmutableListChild>.Builder Children
            {
                get
                {
                    return (ImmutableModelList<ImmutableListChild>.Builder)this.MGet(ImmutableListParentImpl.ChildrenProperty);
                }
            }

            public override ImmutableObject ToImmutable()
            {
                return new ImmutableListParentImpl(this.MModelBuilder.GetNewModel(this.MObject.MModel), this.MObject);
            }
        }

    }

    public interface ImmutableListChild
    {
        ImmutableListParent Parent { get; }
    }

    public interface ImmutableListChildBuilder
    {
        ImmutableListParentBuilder Parent { get; set; }
    }

    internal class ImmutableListChildImpl : ImmutableObject, ImmutableListChild
    {
        internal ImmutableListChildImpl(ImmutableModel model, ImmutableObject oldObject)
            : base(model, oldObject)
        {
        }

        internal ImmutableListChildImpl(ref ImmutableModel model)
            : base(ref model)
        {
        }

        internal ImmutableListChildImpl(ImmutableModel.Builder modelBuilder)
            : base(modelBuilder)
        {
        }

        [OppositeAttribute(typeof(ImmutableListParentImpl), "Children")]
        public static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(ImmutableListParent), typeof(ImmutableListChildImpl));

        public ImmutableListParent Parent
        {
            get { return (ImmutableListParent)this.MModel.Get(this, ImmutableListChildImpl.ParentProperty); }
        }

        public override ImmutableObject MWithModel(ImmutableModel model)
        {
            return new ImmutableListChildImpl(model, this);
        }

        protected override IImmutableObjectBuilder CreateBuilder(ImmutableModel.Builder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public ImmutableListChildBuilder ToBuilder(ImmutableModel.Builder modelBuilder)
        {
            return (ImmutableListChildBuilder)modelBuilder.GetObject(this);
        }

        new private class Builder : ImmutableObject.Builder, ImmutableListChildBuilder
        {
            public Builder(ImmutableModel.Builder modelBuilder, ImmutableListChildImpl obj)
                : base(modelBuilder, obj)
            {
            }

            public ImmutableListParentBuilder Parent
            {
                get
                {
                    return (ImmutableListParentBuilder)this.MGet(ImmutableListChildImpl.ParentProperty);
                }
                set
                {
                    this.MSet(ImmutableListChildImpl.ParentProperty, value);
                }
            }

            public override ImmutableObject ToImmutable()
            {
                return new ImmutableListChildImpl(this.MModelBuilder.GetNewModel(this.MObject.MModel), this.MObject);
            }
        }
    }
    */
}