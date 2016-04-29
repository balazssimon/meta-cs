using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MetaDslx.Core.Immutable.Test
{
    using MetaDslx.Core.Immutable;
    using System.Threading;
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
            [Containment]
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
        public static class Person
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(Person),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutablePerson)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.Person)));
            [Opposite(typeof(Pet), "Owner")]
            public static readonly ModelProperty PetsProperty =
                ModelProperty.Register("Pets", typeof(Person),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutablePet), typeof(ImmutableModelList<Test.ImmutablePet>), typeof(Test.ImmutablePerson)),
                    new ModelPropertyTypeInfo(typeof(Test.Pet), typeof(ModelList<Test.Pet>), typeof(Test.Person)));
        }
        public static class Student
        {
            [Redefines(typeof(Person), "Pets")]
            [Opposite(typeof(Dog), "Friend")]
            public static readonly ModelProperty DogsProperty =
                ModelProperty.Register("Dogs", typeof(Student),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableDog), typeof(ImmutableModelList<Test.ImmutableDog>), typeof(Test.ImmutableStudent)),
                    new ModelPropertyTypeInfo(typeof(Test.Dog), typeof(ModelList<Test.Dog>), typeof(Test.Student)));
        }
        public static class Pet
        {
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(Pet),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.ImmutablePet)),
                    new ModelPropertyTypeInfo(typeof(string), null, typeof(Test.Pet)));
            [Opposite(typeof(Person), "Pets")]
            public static readonly ModelProperty OwnerProperty =
                ModelProperty.Register("Owner", typeof(Pet),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutablePerson), null, typeof(Test.ImmutablePet)),
                    new ModelPropertyTypeInfo(typeof(Test.Person), null, typeof(Test.Pet)));
        }
        public static class Dog
        {
            [Redefines(typeof(Pet), "Owner")]
            [Opposite(typeof(Student), "Dogs")]
            public static readonly ModelProperty FriendProperty =
                ModelProperty.Register("Friend", typeof(Dog),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableStudent), null, typeof(Test.ImmutableDog)),
                    new ModelPropertyTypeInfo(typeof(Test.Student), null, typeof(Test.Dog)));
        }
    }

    public class TestModelFactory
    {
        private MutableRedModel model;

        public TestModelFactory(MutableRedModel model)
        {
            this.model = model;
        }

        public MutableRedSymbol Create(string type)
        {
            switch (type)
            {
                case "Husband": return (MutableRedSymbol)this.Husband();
                case "Wife": return (MutableRedSymbol)this.Wife();
                case "ListChild": return (MutableRedSymbol)this.ListChild();
                case "ListParent": return (MutableRedSymbol)this.ListParent();
                case "User": return (MutableRedSymbol)this.User();
                case "Role": return (MutableRedSymbol)this.Role();
                default:
                    return null;
            }
        }

        public Husband Husband()
        {
            return (Husband)model.AddSymbol(new GreenHusband());
        }

        public Wife Wife()
        {
            return (Wife)model.AddSymbol(new GreenWife());
        }

        public ListChild ListChild()
        {
            return (ListChild)model.AddSymbol(new GreenListChild());
        }

        public ListParent ListParent()
        {
            return (ListParent)model.AddSymbol(new GreenListParent());
        }

        public User User()
        {
            return (User)model.AddSymbol(new GreenUser());
        }

        public Role Role()
        {
            return (Role)model.AddSymbol(new GreenRole());
        }

        public Person Person()
        {
            return (Person)model.AddSymbol(new GreenPerson());
        }

        public Student Student()
        {
            return (Student)model.AddSymbol(new GreenStudent());
        }

        public Pet Pet()
        {
            return (Pet)model.AddSymbol(new GreenPet());
        }

        public Dog Dog()
        {
            return (Dog)model.AddSymbol(new GreenDog());
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

    internal class GreenPerson : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutablePerson); } }
        public override Type MutableType { get { return typeof(Person); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutablePersonImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new PersonImpl(this, model);
        }
    }

    internal class GreenStudent : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableStudent); } }
        public override Type MutableType { get { return typeof(Student); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableStudentImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new StudentImpl(this, model);
        }
    }

    internal class GreenPet : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutablePet); } }
        public override Type MutableType { get { return typeof(Pet); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutablePetImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new PetImpl(this, model);
        }
    }

    internal class GreenDog : GreenSymbol
    {
        public override Type ImmutableType { get { return typeof(ImmutableDog); } }
        public override Type MutableType { get { return typeof(Dog); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model)
        {
            return new ImmutableDogImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModel model)
        {
            return new DogImpl(this, model);
        }
    }

    public interface ImmutableHusband : RedSymbol
    {
        string Name { get; }
        ImmutableWife Wife { get; }
    }

    public interface ImmutableWife : RedSymbol
    {
        string Name { get; }
        ImmutableHusband Husband { get; }
    }

    public interface ImmutableListChild : RedSymbol
    {
        string Name { get; }
        ImmutableListParent Parent { get; }
    }

    public interface ImmutableListParent : RedSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutableListChild> Children { get; }
    }

    public interface ImmutableUser : RedSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutableRole> Roles { get; }
    }

    public interface ImmutableRole : RedSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutableUser> Users { get; }
    }

    public interface ImmutablePerson : RedSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutablePet> Pets { get; }
    }

    public interface ImmutableStudent : ImmutablePerson
    {
        ImmutableModelList<ImmutableDog> Dogs { get; }
    }

    public interface ImmutablePet : RedSymbol
    {
        string Name { get; }
        ImmutablePerson Owner { get; }
    }

    public interface ImmutableDog : ImmutablePet
    {
        ImmutableStudent Friend { get; }
    }

    public interface Husband : RedSymbol
    {
        string Name { get; set; }
        Wife Wife { get; set; }
    }

    public interface Wife : RedSymbol
    {
        string Name { get; set; }
        Husband Husband { get; set; }
    }

    public interface ListChild : RedSymbol
    {
        string Name { get; set; }
        ListParent Parent { get; set; }
    }

    public interface ListParent : RedSymbol
    {
        string Name { get; set; }
        ModelList<ListChild> Children { get; }
    }

    public interface User : RedSymbol
    {
        string Name { get; set; }
        ModelList<Role> Roles { get; }
    }

    public interface Role : RedSymbol
    {
        string Name { get; set; }
        ModelList<User> Users { get; }
    }

    public interface Person : RedSymbol
    {
        string Name { get; set; }
        ModelList<Pet> Pets { get; }
    }

    public interface Student : Person
    {
        ModelList<Dog> Dogs { get; }
    }

    public interface Pet : RedSymbol
    {
        string Name { get; set; }
        Person Owner { get; set; }
    }

    public interface Dog : Pet
    {
        Student Friend { get; set; }
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

    public class ImmutablePersonImpl : ImmutableRedSymbolBase, ImmutablePerson
    {
        private string name;
        private ImmutableRedList<ImmutablePet> pets;

        public ImmutablePersonImpl(GreenSymbol green, ImmutableRedModel model)
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
            get { return this.GetValue(TestModelDescriptor.Person.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutablePet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }
    }

    public class ImmutableStudentImpl : ImmutableRedSymbolBase, ImmutableStudent
    {
        private string name;
        private ImmutableRedList<ImmutablePet> pets;
        private ImmutableRedList<ImmutableDog> dogs;

        public ImmutableStudentImpl(GreenSymbol green, ImmutableRedModel model)
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
            get { return this.GetValue(TestModelDescriptor.Person.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutablePet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

        public ImmutableModelList<ImmutableDog> Dogs
        {
            get { return this.GetList(TestModelDescriptor.Student.DogsProperty, ref this.dogs); }
        }
    }

    public class ImmutablePetImpl : ImmutableRedSymbolBase, ImmutablePet
    {
        private string name;
        private ImmutablePerson owner;

        public ImmutablePetImpl(GreenSymbol green, ImmutableRedModel model)
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
            get { return this.GetValue(TestModelDescriptor.Pet.NameProperty, ref this.name); }
        }

        public ImmutablePerson Owner
        {
            get { return this.GetValue(TestModelDescriptor.Pet.OwnerProperty, ref this.owner); }
        }
    }

    public class ImmutableDogImpl : ImmutableRedSymbolBase, ImmutableDog
    {
        private string name;
        private ImmutablePerson owner;
        private ImmutableStudent friend;

        public ImmutableDogImpl(GreenSymbol green, ImmutableRedModel model)
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
            get { return this.GetValue(TestModelDescriptor.Pet.NameProperty, ref this.name); }
        }

        public ImmutablePerson Owner
        {
            get { return this.GetValue(TestModelDescriptor.Pet.OwnerProperty, ref this.owner); }
        }

        public ImmutableStudent Friend
        {
            get { return this.GetValue(TestModelDescriptor.Dog.FriendProperty, ref this.friend); }
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

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.Husband.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.Husband.WifeProperty)
            {
                Interlocked.Exchange(ref this.wife, null);
            }
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

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.Wife.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.Wife.HusbandProperty)
            {
                Interlocked.Exchange(ref this.husband, null);
            }
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

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.ListChild.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.ListChild.ParentProperty)
            {
                Interlocked.Exchange(ref this.parent, null);
            }
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

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.ListParent.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.ListParent.ChildrenProperty)
            {
                Interlocked.Exchange(ref this.children, null);
            }
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

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.User.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.User.RolesProperty)
            {
                Interlocked.Exchange(ref this.roles, null);
            }
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

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.Role.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.Role.UsersProperty)
            {
                Interlocked.Exchange(ref this.roles, null);
            }
        }
    }

    public class PersonImpl : MutableRedSymbolBase, Person
    {
        private string name;
        private MutableRedList<Pet> pets;

        public PersonImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Person.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Person.PetsProperty);
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
            get { return this.GetValue(TestModelDescriptor.Person.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.Person.NameProperty, ref this.name, value); }
        }

        public ModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.Person.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.Person.PetsProperty)
            {
                Interlocked.Exchange(ref this.pets, null);
            }
        }
    }

    public class StudentImpl : MutableRedSymbolBase, Student
    {
        private string name;
        private MutableRedList<Pet> pets;
        private MutableRedList<Dog> dogs;

        public StudentImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Person.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Person.PetsProperty);
            this.MAttachProperty(TestModelDescriptor.Student.DogsProperty);
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
            get { return this.GetValue(TestModelDescriptor.Person.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.Person.NameProperty, ref this.name, value); }
        }

        public ModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

        public ModelList<Dog> Dogs
        {
            get { return this.GetList(TestModelDescriptor.Student.DogsProperty, ref this.dogs); }
        }

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.Person.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.Person.PetsProperty)
            {
                Interlocked.Exchange(ref this.pets, null);
            }
            if (property == TestModelDescriptor.Student.DogsProperty)
            {
                Interlocked.Exchange(ref this.dogs, null);
            }
        }
    }

    public class PetImpl : MutableRedSymbolBase, Pet
    {
        private string name;
        private Person owner;

        public PetImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Pet.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Pet.OwnerProperty);
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
            get { return this.GetValue(TestModelDescriptor.Pet.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.Pet.NameProperty, ref this.name, value); }
        }

        public Person Owner
        {
            get { return this.GetValue(TestModelDescriptor.Pet.OwnerProperty, ref this.owner); }
            set { this.SetValue(TestModelDescriptor.Pet.OwnerProperty, ref this.owner, value); }
        }

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.Pet.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.Pet.OwnerProperty)
            {
                Interlocked.Exchange(ref this.owner, null);
            }
        }
    }

    public class DogImpl : MutableRedSymbolBase, Dog
    {
        private string name;
        private Person owner;
        private Student friend;

        public DogImpl(GreenSymbol green, MutableRedModel model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Pet.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Pet.OwnerProperty);
            this.MAttachProperty(TestModelDescriptor.Dog.FriendProperty);
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
            get { return this.GetValue(TestModelDescriptor.Pet.NameProperty, ref this.name); }
            set { this.SetValue(TestModelDescriptor.Pet.NameProperty, ref this.name, value); }
        }

        public Person Owner
        {
            get { return this.GetValue(TestModelDescriptor.Pet.OwnerProperty, ref this.owner); }
            set { this.SetValue(TestModelDescriptor.Pet.OwnerProperty, ref this.owner, value); }
        }

        public Student Friend
        {
            get { return this.GetValue(TestModelDescriptor.Dog.FriendProperty, ref this.friend); }
            set { this.SetValue(TestModelDescriptor.Dog.FriendProperty, ref this.friend, value); }
        }

        protected override void InvalidateProperty(ModelProperty property)
        {
            if (property == TestModelDescriptor.Pet.NameProperty)
            {
                Interlocked.Exchange(ref this.name, null);
            }
            if (property == TestModelDescriptor.Pet.OwnerProperty)
            {
                Interlocked.Exchange(ref this.owner, null);
            }
            if (property == TestModelDescriptor.Dog.FriendProperty)
            {
                Interlocked.Exchange(ref this.friend, null);
            }
        }
    }
}