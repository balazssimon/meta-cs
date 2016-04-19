using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable4
{
    public static class SampleModelDescriptor
    {
        public static class Parent
        {
            public static ModelProperty ChildrenProperty = null;
        }

        public static class Child
        {
            public static ModelProperty ParentProperty = null;
        }
    }

    public class SampleModelFactory
    {
        private MutableRedModel model;

        public SampleModelFactory(MutableRedModel model)
        {
            this.model = model;
        }

        public Parent Parent()
        {
            GreenParent green = new GreenParent();
            model.AddGreenSymbol(green);
            ParentImpl red = new ParentImpl(green, model);
            return red;
        }

        public Child Child()
        {
            GreenChild green = new GreenChild();
            model.AddGreenSymbol(green);
            ChildImpl red = new ChildImpl(green, model);
            return red;
        }
    }

    public interface ImmutableParent
    {
        IReadOnlyList<ImmutableChild> Children { get; }
        Parent AsMutable(MutableRedModel model);
    }

    public interface ImmutableChild
    {
        ImmutableParent Parent { get; }
        Child AsMutable(MutableRedModel model);
    }

    public interface Parent
    {
        IList<Child> Children { get; }
        ImmutableParent AsImmutable(ImmutableRedModel model);
    }

    public interface Child
    {
        Parent Parent { get; set; }
        ImmutableChild AsImmutable(ImmutableRedModel model);
    }



    internal class GreenParent : GreenSymbol
    {
        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableParentImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new ParentImpl(this, model);
        }
    }
    internal class GreenChild : GreenSymbol
    {
        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableChildImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new ChildImpl(this, model);
        }
    }

    internal class ImmutableParentImpl : ImmutableRedSymbol, ImmutableParent
    {
        private ImmutableRedSymbolList<ImmutableChild> children;

        public ImmutableParentImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {

        }

        public IReadOnlyList<ImmutableChild> Children
        {
            get
            {
                return this.GetSymbolList(SampleModelDescriptor.Parent.ChildrenProperty, ref this.children);
            }
        }

        public Parent AsMutable(MutableRedModel model)
        {
            return model.GetRedSymbol(this.Green) as Parent;
        }
    }
    internal class ImmutableChildImpl : ImmutableRedSymbol, ImmutableChild
    {
        private ImmutableParent parent;

        public ImmutableChildImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {

        }

        public ImmutableParent Parent
        {
            get
            {
                return this.GetValue(SampleModelDescriptor.Child.ParentProperty, ref this.parent);
            }
        }

        public Child AsMutable(MutableRedModel model)
        {
            return model.GetRedSymbol(this.Green) as Child;
        }
    }

    internal class ParentImpl : MutableRedSymbol, Parent
    {
        private MutableRedSymbolList<Child> children;

        public ParentImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {

        }

        public IList<Child> Children
        {
            get
            {
                return this.GetSymbolList(SampleModelDescriptor.Parent.ChildrenProperty, ref this.children);
            }
        }

        public ImmutableParent AsImmutable(ImmutableRedModel model)
        {
            return model.GetRedSymbol(this.Green) as ImmutableParent;
        }
    }
    internal class ChildImpl : MutableRedSymbol, Child
    {
        private Parent parent;

        public ChildImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {

        }

        public Parent Parent
        {
            get
            {
                return this.GetValue(SampleModelDescriptor.Child.ParentProperty, ref this.parent);
            }
            set
            {
                this.SetValue(SampleModelDescriptor.Child.ParentProperty, ref this.parent, value);
            }
        }

        public ImmutableChild AsImmutable(ImmutableRedModel model)
        {
            return model.GetRedSymbol(this.Green) as ImmutableChild;
        }
    }

}
