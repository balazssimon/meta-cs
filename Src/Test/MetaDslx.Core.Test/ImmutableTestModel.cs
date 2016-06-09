using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MetaDslx.Core.Immutable.Test
{
    using MetaDslx.Core.Immutable;
    using System.Threading;
    public static class TestModelDescriptor
    {
        private static List<ModelProperty> properties = new List<ModelProperty>();

        static TestModelDescriptor()
        {
            properties.Add(Husband.NameProperty);
            properties.Add(Husband.WifeProperty);
            properties.Add(Wife.NameProperty);
            properties.Add(Wife.HusbandProperty);
            properties.Add(ListChild.NameProperty);
            properties.Add(ListChild.ParentProperty);
            properties.Add(ListParent.NameProperty);
            properties.Add(ListParent.ChildrenProperty);
            properties.Add(User.NameProperty);
            properties.Add(User.RolesProperty);
            properties.Add(Role.NameProperty);
            properties.Add(Role.UsersProperty);
            properties.Add(Person.NameProperty);
            properties.Add(Person.PetsProperty);
            properties.Add(Student.DogsProperty);
            properties.Add(Pet.NameProperty);
            properties.Add(Pet.OwnerProperty);
            properties.Add(Dog.FriendProperty);

            foreach (var property in properties)
            {
                property.Init();
            }
        }

        public static void Init()
        {

        }

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
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableListChild), typeof(IImmutableModelList<Test.ImmutableListChild>), typeof(Test.ImmutableListParent)),
                    new ModelPropertyTypeInfo(typeof(Test.ListChild), typeof(IMutableModelList<Test.ListChild>), typeof(Test.ListParent)));
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
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableRole), typeof(IImmutableModelList<Test.ImmutableRole>), typeof(Test.ImmutableUser)),
                    new ModelPropertyTypeInfo(typeof(Test.Role), typeof(IMutableModelList<Test.Role>), typeof(Test.User)));
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
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableUser), typeof(IImmutableModelList<Test.ImmutableUser>), typeof(Test.ImmutableRole)),
                    new ModelPropertyTypeInfo(typeof(Test.User), typeof(IMutableModelList<Test.User>), typeof(Test.Role)));
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
                    new ModelPropertyTypeInfo(typeof(Test.ImmutablePet), typeof(IImmutableModelList<Test.ImmutablePet>), typeof(Test.ImmutablePerson)),
                    new ModelPropertyTypeInfo(typeof(Test.Pet), typeof(IMutableModelList<Test.Pet>), typeof(Test.Person)));
        }
        public static class Student
        {
            [Redefines(typeof(Person), "Pets")]
            [Opposite(typeof(Dog), "Friend")]
            public static readonly ModelProperty DogsProperty =
                ModelProperty.Register("Dogs", typeof(Student),
                    new ModelPropertyTypeInfo(typeof(Test.ImmutableDog), typeof(IImmutableModelList<Test.ImmutableDog>), typeof(Test.ImmutableStudent)),
                    new ModelPropertyTypeInfo(typeof(Test.Dog), typeof(IMutableModelList<Test.Dog>), typeof(Test.Student)));
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

    public class TestModelFactory : ModelFactory
    {
        public TestModelFactory()
            : base()
        {
        }

        public TestModelFactory(MutableModel model)
            : base(model)
        {
            TestModelDescriptor.Init();
        }

        public override IMutableSymbol Create(string type)
        {
            switch (type)
            {
                case "Husband": return (IMutableSymbol)this.Husband();
                case "Wife": return (IMutableSymbol)this.Wife();
                case "ListChild": return (IMutableSymbol)this.ListChild();
                case "ListParent": return (IMutableSymbol)this.ListParent();
                case "User": return (IMutableSymbol)this.User();
                case "Role": return (IMutableSymbol)this.Role();
                default:
                    throw new ModelException("Unknown type name: " + type);
            }
        }

        public Husband Husband()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenHusband());
            symbol.MMakeCreated();
            return (Husband)symbol;
        }

        public Wife Wife()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenWife());
            symbol.MMakeCreated();
            return (Wife)symbol;
        }

        public ListChild ListChild()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenListChild());
            symbol.MMakeCreated();
            return (ListChild)symbol;
        }

        public ListParent ListParent()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenListParent());
            symbol.MMakeCreated();
            return (ListParent)symbol;
        }

        public User User()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenUser());
            symbol.MMakeCreated();
            return (User)symbol;
        }

        public Role Role()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenRole());
            symbol.MMakeCreated();
            return (Role)symbol;
        }

        public Person Person()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenPerson());
            symbol.MMakeCreated();
            return (Person)symbol;
        }

        public Student Student()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenStudent());
            symbol.MMakeCreated();
            return (Student)symbol;
        }

        public Pet Pet()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenPet());
            symbol.MMakeCreated();
            return (Pet)symbol;
        }

        public Dog Dog()
        {
            MutableSymbolBase symbol = (MutableSymbolBase)this.AddSymbol(new GreenDog());
            symbol.MMakeCreated();
            return (Dog)symbol;
        }
    }

    internal class GreenHusband : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableHusband); } }
        public override Type MutableType { get { return typeof(Husband); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableHusbandImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new HusbandImpl(this, model, created);
        }
    }

    internal class GreenWife : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableWife); } }
        public override Type MutableType { get { return typeof(Wife); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableWifeImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new WifeImpl(this, model, created);
        }
    }

    internal class GreenListChild : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableListChild); } }
        public override Type MutableType { get { return typeof(ListChild); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableListChildImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new ListChildImpl(this, model, created);
        }
    }

    internal class GreenListParent : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableListParent); } }
        public override Type MutableType { get { return typeof(ListParent); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableListParentImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new ListParentImpl(this, model, created);
        }
    }

    internal class GreenUser : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableUser); } }
        public override Type MutableType { get { return typeof(User); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableUserImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new UserImpl(this, model, created);
        }
    }

    internal class GreenRole : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableRole); } }
        public override Type MutableType { get { return typeof(Role); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableRoleImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new RoleImpl(this, model, created);
        }
    }

    internal class GreenPerson : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutablePerson); } }
        public override Type MutableType { get { return typeof(Person); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutablePersonImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new PersonImpl(this, model, created);
        }
    }

    internal class GreenStudent : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableStudent); } }
        public override Type MutableType { get { return typeof(Student); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableStudentImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new StudentImpl(this, model, created);
        }
    }

    internal class GreenPet : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutablePet); } }
        public override Type MutableType { get { return typeof(Pet); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutablePetImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new PetImpl(this, model, created);
        }
    }

    internal class GreenDog : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableDog); } }
        public override Type MutableType { get { return typeof(Dog); } }

        public override IImmutableSymbol CreateImmutable(ImmutableModel model)
        {
            return new ImmutableDogImpl(this, model);
        }

        public override IMutableSymbol CreateMutable(MutableModel model, bool created)
        {
            return new DogImpl(this, model, created);
        }
    }

    public interface ImmutableHusband : ISymbol
    {
        string Name { get; }
        ImmutableWife Wife { get; }
    }

    public interface ImmutableWife : ISymbol
    {
        string Name { get; }
        ImmutableHusband Husband { get; }
    }

    public interface ImmutableListChild : ISymbol
    {
        string Name { get; }
        ImmutableListParent Parent { get; }
    }

    public interface ImmutableListParent : ISymbol
    {
        string Name { get; }
        IImmutableModelList<ImmutableListChild> Children { get; }
    }

    public interface ImmutableUser : ISymbol
    {
        string Name { get; }
        IImmutableModelList<ImmutableRole> Roles { get; }
    }

    public interface ImmutableRole : ISymbol
    {
        string Name { get; }
        IImmutableModelList<ImmutableUser> Users { get; }
    }

    public interface ImmutablePerson : ISymbol
    {
        string Name { get; }
        IImmutableModelList<ImmutablePet> Pets { get; }
    }

    public interface ImmutableStudent : ImmutablePerson
    {
        IImmutableModelList<ImmutableDog> Dogs { get; }
    }

    public interface ImmutablePet : ISymbol
    {
        string Name { get; }
        ImmutablePerson Owner { get; }
    }

    public interface ImmutableDog : ImmutablePet
    {
        ImmutableStudent Friend { get; }
    }

    public interface Husband : ISymbol
    {
        string Name { get; set; }
        Wife Wife { get; set; }
    }

    public interface HusbandBuilder : Husband
    {
        Func<string> NameLazy { get; set; }
        Func<Wife> WifeLazy { get; set; }
    }

    public interface Wife : ISymbol
    {
        string Name { get; set; }
        Husband Husband { get; set; }
    }

    public interface ListChild : ISymbol
    {
        string Name { get; set; }
        ListParent Parent { get; set; }
    }

    public interface ListParent : ISymbol
    {
        string Name { get; set; }
        IMutableModelList<ListChild> Children { get; }
    }

    public interface User : ISymbol
    {
        string Name { get; set; }
        IMutableModelList<Role> Roles { get; }
    }

    public interface Role : ISymbol
    {
        string Name { get; set; }
        IMutableModelList<User> Users { get; }
    }

    public interface Person : ISymbol
    {
        string Name { get; set; }
        IMutableModelList<Pet> Pets { get; }
    }

    public interface Student : Person
    {
        IMutableModelList<Dog> Dogs { get; }
    }

    public interface Pet : ISymbol
    {
        string Name { get; set; }
        Person Owner { get; set; }
    }

    public interface Dog : Pet
    {
        Student Friend { get; set; }
    }


    public class ImmutableHusbandImpl : ImmutableSymbolBase, ImmutableHusband
    {
        private string name;
        private ImmutableWife wife;

        public ImmutableHusbandImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.Husband.NameProperty, ref this.name); }
        }

        public ImmutableWife Wife
        {
            get { return this.GetReference(TestModelDescriptor.Husband.WifeProperty, ref this.wife); }
        }
    }

    public class ImmutableWifeImpl : ImmutableSymbolBase, ImmutableWife
    {
        private string name;
        private ImmutableHusband husband;

        public ImmutableWifeImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.Wife.NameProperty, ref this.name); }
        }

        public ImmutableHusband Husband
        {
            get { return this.GetReference(TestModelDescriptor.Wife.HusbandProperty, ref this.husband); }
        }
    }

    public class ImmutableListChildImpl : ImmutableSymbolBase, ImmutableListChild
    {
        private string name;
        private ImmutableListParent parent;

        public ImmutableListChildImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.ListChild.NameProperty, ref this.name); }
        }

        public ImmutableListParent Parent
        {
            get { return this.GetReference(TestModelDescriptor.ListChild.ParentProperty, ref this.parent); }
        }
    }

    public class ImmutableListParentImpl : ImmutableSymbolBase, ImmutableListParent
    {
        private string name;
        private IImmutableModelList<ImmutableListChild> children;

        public ImmutableListParentImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.ListParent.NameProperty, ref this.name); }
        }

        public IImmutableModelList<ImmutableListChild> Children
        {
            get { return this.GetList(TestModelDescriptor.ListParent.ChildrenProperty, ref this.children); }
        }
    }

    public class ImmutableUserImpl : ImmutableSymbolBase, ImmutableUser
    {
        private string name;
        private IImmutableModelList<ImmutableRole> roles;

        public ImmutableUserImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.User.NameProperty, ref this.name); }
        }

        public IImmutableModelList<ImmutableRole> Roles
        {
            get { return this.GetList(TestModelDescriptor.User.RolesProperty, ref this.roles); }
        }
    }

    public class ImmutableRoleImpl : ImmutableSymbolBase, ImmutableRole
    {
        private string name;
        private IImmutableModelList<ImmutableUser> users;

        public ImmutableRoleImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.Role.NameProperty, ref this.name); }
        }

        public IImmutableModelList<ImmutableUser> Users
        {
            get { return this.GetList(TestModelDescriptor.Role.UsersProperty, ref this.users); }
        }
    }

    public class ImmutablePersonImpl : ImmutableSymbolBase, ImmutablePerson
    {
        private string name;
        private IImmutableModelList<ImmutablePet> pets;

        public ImmutablePersonImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.Person.NameProperty, ref this.name); }
        }

        public IImmutableModelList<ImmutablePet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }
    }

    public class ImmutableStudentImpl : ImmutableSymbolBase, ImmutableStudent
    {
        private string name;
        private IImmutableModelList<ImmutablePet> pets;
        private IImmutableModelList<ImmutableDog> dogs;

        public ImmutableStudentImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.Person.NameProperty, ref this.name); }
        }

        public IImmutableModelList<ImmutablePet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

        public IImmutableModelList<ImmutableDog> Dogs
        {
            get { return this.GetList(TestModelDescriptor.Student.DogsProperty, ref this.dogs); }
        }
    }

    public class ImmutablePetImpl : ImmutableSymbolBase, ImmutablePet
    {
        private string name;
        private ImmutablePerson owner;

        public ImmutablePetImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.Pet.NameProperty, ref this.name); }
        }

        public ImmutablePerson Owner
        {
            get { return this.GetReference(TestModelDescriptor.Pet.OwnerProperty, ref this.owner); }
        }
    }

    public class ImmutableDogImpl : ImmutableSymbolBase, ImmutableDog
    {
        private string name;
        private ImmutablePerson owner;
        private ImmutableStudent friend;

        public ImmutableDogImpl(SymbolId green, ImmutableModel model)
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
            get { return this.GetReference(TestModelDescriptor.Pet.NameProperty, ref this.name); }
        }

        public ImmutablePerson Owner
        {
            get { return this.GetReference(TestModelDescriptor.Pet.OwnerProperty, ref this.owner); }
        }

        public ImmutableStudent Friend
        {
            get { return this.GetReference(TestModelDescriptor.Dog.FriendProperty, ref this.friend); }
        }
    }

    public class HusbandImpl : MutableSymbolBase, Husband, HusbandBuilder
    {
        public HusbandImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.Husband.NameProperty);
                this.MAttachProperty(TestModelDescriptor.Husband.WifeProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.Husband.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Husband.NameProperty, value); }
        }

        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(TestModelDescriptor.Husband.NameProperty); }
            set { this.SetLazyReference(TestModelDescriptor.Husband.NameProperty, value); }
        }

        public Wife Wife
        {
            get { return this.GetReference<Wife>(TestModelDescriptor.Husband.WifeProperty); }
            set { this.SetReference(TestModelDescriptor.Husband.WifeProperty, value); }
        }

        public Func<Wife> WifeLazy
        {
            get { return this.GetLazyReference<Wife>(TestModelDescriptor.Husband.WifeProperty); }
            set { this.SetLazyReference(TestModelDescriptor.Husband.WifeProperty, value); }
        }

    }

    public class WifeImpl : MutableSymbolBase, Wife
    {
        public WifeImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.Wife.NameProperty);
                this.MAttachProperty(TestModelDescriptor.Wife.HusbandProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.Wife.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Wife.NameProperty, value); }
        }

        public Husband Husband
        {
            get { return this.GetReference<Husband>(TestModelDescriptor.Wife.HusbandProperty); }
            set { this.SetReference(TestModelDescriptor.Wife.HusbandProperty, value); }
        }
    }

    public class ListChildImpl : MutableSymbolBase, ListChild
    {
        public ListChildImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.ListChild.NameProperty);
                this.MAttachProperty(TestModelDescriptor.ListChild.ParentProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.ListChild.NameProperty); }
            set { this.SetReference(TestModelDescriptor.ListChild.NameProperty, value); }
        }

        public ListParent Parent
        {
            get { return this.GetReference<ListParent>(TestModelDescriptor.ListChild.ParentProperty); }
            set { this.SetReference(TestModelDescriptor.ListChild.ParentProperty, value); }
        }
    }

    public class ListParentImpl : MutableSymbolBase, ListParent
    {
        private IMutableModelList<ListChild> children;

        public ListParentImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.ListParent.NameProperty);
                this.MAttachProperty(TestModelDescriptor.ListParent.ChildrenProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.ListParent.NameProperty); }
            set { this.SetReference(TestModelDescriptor.ListParent.NameProperty, value); }
        }

        public IMutableModelList<ListChild> Children
        {
            get { return this.GetList(TestModelDescriptor.ListParent.ChildrenProperty, ref this.children); }
        }

    }

    public class UserImpl : MutableSymbolBase, User
    {
        private IMutableModelList<Role> roles;

        public UserImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.User.NameProperty);
                this.MAttachProperty(TestModelDescriptor.User.RolesProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.User.NameProperty); }
            set { this.SetReference(TestModelDescriptor.User.NameProperty, value); }
        }

        public IMutableModelList<Role> Roles
        {
            get { return this.GetList(TestModelDescriptor.User.RolesProperty, ref this.roles); }
        }

    }

    public class RoleImpl : MutableSymbolBase, Role
    {
        private IMutableModelList<User> roles;

        public RoleImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.Role.NameProperty);
                this.MAttachProperty(TestModelDescriptor.Role.UsersProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.Role.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Role.NameProperty, value); }
        }

        public IMutableModelList<User> Users
        {
            get { return this.GetList(TestModelDescriptor.Role.UsersProperty, ref this.roles); }
        }

    }

    public class PersonImpl : MutableSymbolBase, Person
    {
        private IMutableModelList<Pet> pets;

        public PersonImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.Person.NameProperty);
                this.MAttachProperty(TestModelDescriptor.Person.PetsProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.Person.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Person.NameProperty, value); }
        }

        public IMutableModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

    }

    public class StudentImpl : MutableSymbolBase, Student
    {
        private IMutableModelList<Pet> pets;
        private IMutableModelList<Dog> dogs;

        public StudentImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.Person.NameProperty);
                this.MAttachProperty(TestModelDescriptor.Person.PetsProperty);
                this.MAttachProperty(TestModelDescriptor.Student.DogsProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.Person.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Person.NameProperty, value); }
        }

        public IMutableModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

        public IMutableModelList<Dog> Dogs
        {
            get { return this.GetList(TestModelDescriptor.Student.DogsProperty, ref this.dogs); }
        }

    }

    public class PetImpl : MutableSymbolBase, Pet
    {
        public PetImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.Pet.NameProperty);
                this.MAttachProperty(TestModelDescriptor.Pet.OwnerProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.Pet.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Pet.NameProperty, value); }
        }

        public Person Owner
        {
            get { return this.GetReference<Person>(TestModelDescriptor.Pet.OwnerProperty); }
            set { this.SetReference(TestModelDescriptor.Pet.OwnerProperty, value); }
        }
    }

    public class DogImpl : MutableSymbolBase, Dog
    {
        public DogImpl(SymbolId green, MutableModel model, bool created)
            : base(green, model, created)
        {
            if (!created)
            {
                this.MAttachProperty(TestModelDescriptor.Pet.NameProperty);
                this.MAttachProperty(TestModelDescriptor.Pet.OwnerProperty);
                this.MAttachProperty(TestModelDescriptor.Dog.FriendProperty);
                this.MInit();
            }
        }

        protected override void MDoInit()
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
            get { return this.GetReference<string>(TestModelDescriptor.Pet.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Pet.NameProperty, value); }
        }

        public Person Owner
        {
            get { return this.GetReference<Person>(TestModelDescriptor.Pet.OwnerProperty); }
            set { this.SetReference(TestModelDescriptor.Pet.OwnerProperty, value); }
        }

        public Student Friend
        {
            get { return this.GetReference<Student>(TestModelDescriptor.Dog.FriendProperty); }
            set { this.SetReference(TestModelDescriptor.Dog.FriendProperty, value); }
        }

    }
}