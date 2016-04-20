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
            return (Parent)model.AddGreenSymbol(new GreenParent());
        }

        public Child Child()
        {
            return (Child)model.AddGreenSymbol(new GreenChild());
        }
    }

    public interface ImmutableParent : RedSymbol
    {
        ImmutableModelList<ImmutableChild> Children { get; }
        Parent AsMutable(MutableRedModel model);
    }

    public interface ImmutableChild : RedSymbol
    {
        ImmutableParent Parent { get; }
        Child AsMutable(MutableRedModel model);
    }

    public interface Parent : RedSymbol
    {
        ModelList<Child> Children { get; }
        ImmutableParent AsImmutable(ImmutableRedModel model);
    }

    public interface Child : RedSymbol
    {
        Parent Parent { get; set; }
        void SetParent(Func<Parent> lazy);
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

        public ImmutableModelList<ImmutableChild> Children
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

        public ModelList<Child> Children
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

        public void SetParent(Func<Parent> lazy)
        {
            this.SetLazyValue(SampleModelDescriptor.Child.ParentProperty, lazy);
        }

        public ImmutableChild AsImmutable(ImmutableRedModel model)
        {
            return model.GetRedSymbol(this.Green) as ImmutableChild;
        }
    }

}
