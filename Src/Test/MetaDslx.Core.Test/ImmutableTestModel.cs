using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetaDslx.Core.Immutable;
using System.Collections.Generic;

namespace MetaDslx.Core.Test
{
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

        public ImmutableHusband GetHusband(ImmutableModel model, ImmutableHusbandBuilder builder)
        {
            return (ImmutableHusband)model.GetObject((ImmutableObject.Builder)builder);
        }

        public ImmutableWife GetWife(ImmutableModel model, ImmutableWifeBuilder builder)
        {
            return (ImmutableWife)model.GetObject((ImmutableObject.Builder)builder);
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

        protected override ImmutableObject.Builder CreateBuilder(ImmutableModel.Builder modelBuilder)
        {
            return new Builder(modelBuilder, this);
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

        protected override ImmutableObject.Builder CreateBuilder(ImmutableModel.Builder modelBuilder)
        {
            return new Builder(modelBuilder, this);
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
        }
    }

}
