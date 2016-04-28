using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MetaDslx.Core.Immutable.Test
{
    using MetaDslx.Core.Immutable;

    public static class TestModelDescriptor
    {
        public static class Husband
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(Husband),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutableHusband)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.Husband)));
            [Opposite(typeof(Wife), "Husband")]
            public static readonly ModelProperty WifeProperty =
                ModelProperty.Register("Wife", typeof(Husband),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableWife), null, typeof(Test.ImmutableHusband)),
                    new ModelPropertyTypeInfo(typeof(Test.Wife), null, typeof(Test.Husband)));
        }
        public static class Wife
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(Wife),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutableWife)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.Wife)));
            [Opposite(typeof(Husband), "Wife")]
            public static readonly ModelProperty HusbandProperty =
                ModelProperty.Register("Husband", typeof(Wife),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableHusband), null, typeof(Test.ImmutableWife)),
                    new ModelPropertyTypeInfo(typeof(Test.Husband), null, typeof(Test.Wife)));
        }
        public static class ListChild
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(ListChild),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutableListChild)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ListChild)));
            [Opposite(typeof(ListParent), "Children")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(ListChild),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableListParent), null, typeof(Test.ImmutableListChild)),
                    new ModelPropertyTypeInfo(typeof(Test.ListParent), null, typeof(Test.ListChild)));
        }
        public static class ListParent
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(ListParent),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutableListParent)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ListParent)));
            [Opposite(typeof(ListChild), "Parent")]
            public static readonly ModelProperty ChildrenProperty =
                ModelProperty.Register("Children", typeof(ListParent),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableListChild), typeof(ImmutableModelList<Test.ImmutableListChild>), typeof(Test.ImmutableListParent)),
                    new ModelPropertyTypeInfo(typeof(Test.ListChild), typeof(ModelList<Test.ListChild>), typeof(Test.ListParent)));
        }
        public static class User
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(User),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutableUser)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.User)));
            [Opposite(typeof(Role), "Users")]
            public static readonly ModelProperty RolesProperty =
                ModelProperty.Register("Roles", typeof(User),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableRole), typeof(ImmutableModelList<Test.ImmutableRole>), typeof(Test.ImmutableUser)),
                    new ModelPropertyTypeInfo(typeof(Test.Role), typeof(ModelList<Test.Role>), typeof(Test.User)));
        }
        public static class Role
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(Role),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutableRole)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.Role)));
            [Opposite(typeof(User), "Roles")]
            public static readonly ModelProperty UsersProperty =
                ModelProperty.Register("Users", typeof(Role),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableUser), typeof(ImmutableModelList<Test.ImmutableUser>), typeof(Test.ImmutableRole)),
                    new ModelPropertyTypeInfo(typeof(Test.User), typeof(ModelList<Test.User>), typeof(Test.Role)));
        }
    }

    public class TestModelFactory
    {
        private MutableRedModel model;

        public TestModelFactory(MutableRedModel model)
        {
            this.model = model;
        }

        public Husband Husband()
        {
            GreenHusband symbol = new GreenHusband();
            return (Husband)model.AddSymbol(symbol);
        }

        public Wife Wife()
        {
            GreenWife symbol = new GreenWife();
            return (Wife)model.AddSymbol(symbol);
        }

        public ListChild ListChild()
        {
            GreenListChild symbol = new GreenListChild();
            return (ListChild)model.AddSymbol(symbol);
        }

        public ListParent ListParent()
        {
            GreenListParent symbol = new GreenListParent();
            return (ListParent)model.AddSymbol(symbol);
        }

        public User User()
        {
            GreenUser symbol = new GreenUser();
            return (User)model.AddSymbol(symbol);
        }

        public Role Role()
        {
            GreenRole symbol = new GreenRole();
            return (Role)model.AddSymbol(symbol);
        }
    }

    internal class GreenHusband : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableHusband); } }
        public override Type MutableType { get { return typeof(Husband); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableHusbandImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new HusbandImpl(this, model);
        }
    }

    internal class GreenWife : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableWife); } }
        public override Type MutableType { get { return typeof(Wife); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableWifeImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new WifeImpl(this, model);
        }
    }

    internal class GreenListChild : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableListChild); } }
        public override Type MutableType { get { return typeof(ListChild); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableListChildImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new ListChildImpl(this, model);
        }
    }

    internal class GreenListParent : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableListParent); } }
        public override Type MutableType { get { return typeof(ListParent); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableListParentImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new ListParentImpl(this, model);
        }
    }

    internal class GreenUser : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableUser); } }
        public override Type MutableType { get { return typeof(User); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableUserImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new UserImpl(this, model);
        }
    }

    internal class GreenRole : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableRole); } }
        public override Type MutableType { get { return typeof(Role); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableRoleImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new RoleImpl(this, model);
        }
    }

    public interface ImmutableHusband : ImmutableRedSymbol
    {
        string Name { get; }
        ImmutableWife Wife { get; }
    }

    public interface ImmutableWife : ImmutableRedSymbol
    {
        string Name { get; }
        ImmutableHusband Husband { get; }
    }

    public interface ImmutableListChild : ImmutableRedSymbol
    {
        ImmutableListParent Parent { get; }
    }

    public interface ImmutableListParent : ImmutableRedSymbol
    {
        ImmutableModelList<ImmutableListChild> Children { get; }
    }

    public interface ImmutableUser : ImmutableRedSymbol
    {
        ImmutableModelList<ImmutableRole> Roles { get; }
    }

    public interface ImmutableRole : ImmutableRedSymbol
    {
        ImmutableModelList<ImmutableUser> Users { get; }
    }


    public interface Husband : MutableRedSymbol
    {
        string Name { get; set; }
        Wife Wife { get; set; }
    }

    public interface Wife : MutableRedSymbol
    {
        string Name { get; set; }
        Husband Husband { get; set; }
    }

    public interface ListChild : MutableRedSymbol
    {
        ListParent Parent { get; set; }
    }

    public interface ListParent : MutableRedSymbol
    {
        ModelList<ListChild> Children { get; }
    }

    public interface User : MutableRedSymbol
    {
        ModelList<Role> Roles { get; }
    }

    public interface Role : MutableRedSymbol
    {
        ModelList<User> Users { get; }
    }


    public class ImmutableHusbandImpl : ImmutableRedSymbolBase, ImmutableHusband
    {
        private string name;
        private ImmutableWife wife;

        public ImmutableHusbandImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public override object MMetaClass
        {
            get{ return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.Husband.NameProperty, ref this.name); }
        }

        public ImmutableWife Wife
        {
            get { return this.GetValue(TestModelDescriptor.Husband.WifeProperty, ref this.wife); }
        }
    }

    public class ImmutableWifeImpl : ImmutableRedSymbolBase, ImmutableWife
    {
        private string name;
        private ImmutableHusband husband;

        public ImmutableWifeImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.Wife.NameProperty, ref this.name); }
        }

        public ImmutableHusband Husband
        {
            get { return this.GetValue(TestModelDescriptor.Wife.HusbandProperty, ref this.husband); }
        }
    }

    public class ImmutableListChildImpl : ImmutableRedSymbolBase, ImmutableListChild
    {
        private string name;
        private ImmutableListParent parent;

        public ImmutableListChildImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.ListChild.NameProperty, ref this.name); }
        }

        public ImmutableListParent Parent
        {
            get { return this.GetValue(TestModelDescriptor.ListChild.ParentProperty, ref this.parent); }
        }
    }

    public class ImmutableListParentImpl : ImmutableRedSymbolBase, ImmutableListParent
    {
        private string name;
        private ImmutableRedList<ImmutableListChild> children;

        public ImmutableListParentImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.ListParent.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutableListChild> Children
        {
            get { return this.GetList(TestModelDescriptor.ListParent.ChildrenProperty, ref this.children); }
        }
    }

    public class ImmutableUserImpl : ImmutableRedSymbolBase, ImmutableUser
    {
        private string name;
        private ImmutableRedList<ImmutableRole> roles;

        public ImmutableUserImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.User.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutableRole> Roles
        {
            get { return this.GetList(TestModelDescriptor.User.RolesProperty, ref this.roles); }
        }
    }

    public class ImmutableRoleImpl : ImmutableRedSymbolBase, ImmutableRole
    {
        private string name;
        private ImmutableRedList<ImmutableUser> users;

        public ImmutableRoleImpl(GreenSymbol green, ImmutableRedModel model)
            : base(green, model)
        {
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.Role.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutableUser> Users
        {
            get { return this.GetList(TestModelDescriptor.Role.UsersProperty, ref this.users); }
        }
    }


    public class HusbandImpl : MutableRedSymbolBase, Husband
    {
        private string name;
        private Wife wife;

        public HusbandImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Husband.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Husband.WifeProperty);
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.Husband.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.Husband.NameProperty, ref this.name, value); }
        }

        public Wife Wife
        {
            get { return this.GetValue(TestModelDescriptor.Husband.WifeProperty, ref this.wife); }
            set { this.SetValue(TestModelDescriptor.Husband.WifeProperty, ref this.wife, value); }
        }
    }

    public class WifeImpl : MutableRedSymbolBase, Wife
    {
        private string name;
        private Husband husband;

        public WifeImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Wife.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Wife.HusbandProperty);
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.Wife.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.Wife.NameProperty, ref this.name, value); }
        }

        public Husband Husband
        {
            get { return this.GetValue(TestModelDescriptor.Wife.HusbandProperty, ref this.husband); }
            set { this.SetValue(TestModelDescriptor.Wife.HusbandProperty, ref this.husband, value); }
        }
    }

    public class ListChildImpl : MutableRedSymbolBase, ListChild
    {
        private string name;
        private ListParent parent;

        public ListChildImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.ListChild.NameProperty);
            this.MAttachProperty(TestModelDescriptor.ListChild.ParentProperty);
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.ListChild.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.ListChild.NameProperty, ref this.name, value); }
        }

        public ListParent Parent
        {
            get { return this.GetValue(TestModelDescriptor.ListChild.ParentProperty, ref this.parent); }
            set { this.SetValue(TestModelDescriptor.ListChild.ParentProperty, ref this.parent, value); }
        }
    }

    public class ListParentImpl : MutableRedSymbolBase, ListParent
    {
        private string name;
        private MutableRedList<ListChild> children;

        public ListParentImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.ListParent.NameProperty);
            this.MAttachProperty(TestModelDescriptor.ListParent.ChildrenProperty);
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.ListParent.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.ListParent.NameProperty, ref this.name, value); }
        }

        public ModelList<ListChild> Children
        {
            get { return this.GetList(TestModelDescriptor.ListParent.ChildrenProperty, ref this.children); }
        }
    }

    public class UserImpl : MutableRedSymbolBase, User
    {
        private string name;
        private MutableRedList<Role> roles;

        public UserImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.User.NameProperty);
            this.MAttachProperty(TestModelDescriptor.User.RolesProperty);
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.User.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.User.NameProperty, ref this.name, value); }
        }

        public ModelList<Role> Roles
        {
            get { return this.GetList(TestModelDescriptor.User.RolesProperty, ref this.roles); }
        }
    }

    public class RoleImpl : MutableRedSymbolBase, Role
    {
        private string name;
        private MutableRedList<User> roles;

        public RoleImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Role.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Role.UsersProperty);
        }

        public override object MMetaClass
        {
            get { return null; }
        }

        public override object MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetValue(TestModelDescriptor.Role.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.Role.NameProperty, ref this.name, value); }
        }

        public ModelList<User> Users
        {
            get { return this.GetList(TestModelDescriptor.Role.UsersProperty, ref this.roles); }
        }
    }

}