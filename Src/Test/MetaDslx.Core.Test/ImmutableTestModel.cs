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
        private MutableRedModelPart part;

        public TestModelFactory(MutableRedModel model)
        {
            TestModelDescriptor.Init();
            this.model = model;
            var parts = this.model.Parts.ToList();
            if (parts.Count != 1)
            {
                throw new ModelException("The model must have exactly one part.");
            }
            this.part = parts[0];
        }

        public TestModelFactory(MutableRedModel model, MutableRedModelPart part)
        {
            TestModelDescriptor.Init();
            this.model = model;
            if (!model.Parts.Contains(part))
            {
                throw new ModelException("The model must contain the given part.");
            }
            this.part = part;
        }

        public MutableRedSymbol Create(string type, ReferenceMode referenceMode = ReferenceMode.Default)
        {
            switch (type)
            {
                case "Husband": return (MutableRedSymbol)this.Husband(referenceMode);
                case "Wife": return (MutableRedSymbol)this.Wife(referenceMode);
                case "ListChild": return (MutableRedSymbol)this.ListChild(referenceMode);
                case "ListParent": return (MutableRedSymbol)this.ListParent(referenceMode);
                case "User": return (MutableRedSymbol)this.User(referenceMode);
                case "Role": return (MutableRedSymbol)this.Role(referenceMode);
                default:
                    return null;
            }
        }

        public Husband Husband(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (Husband)part.AddSymbol(new GreenHusband(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public Wife Wife(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (Wife)part.AddSymbol(new GreenWife(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public ListChild ListChild(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (ListChild)part.AddSymbol(new GreenListChild(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public ListParent ListParent(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (ListParent)part.AddSymbol(new GreenListParent(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public User User(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (User)part.AddSymbol(new GreenUser(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public Role Role(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (Role)part.AddSymbol(new GreenRole(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public Person Person(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (Person)part.AddSymbol(new GreenPerson(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public Student Student(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (Student)part.AddSymbol(new GreenStudent(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public Pet Pet(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (Pet)part.AddSymbol(new GreenPet(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }

        public Dog Dog(ReferenceMode referenceMode = ReferenceMode.Default)
        {
            var symbol = (Dog)part.AddSymbol(new GreenDog(), referenceMode);
            ((MutableRedSymbolBase)symbol).MMakeCreated();
            return symbol;
        }
    }

    internal class GreenHusband : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableHusband); } }
        public override Type MutableType { get { return typeof(Husband); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableHusbandImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new HusbandImpl(this, model);
        }
    }

    internal class GreenWife : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableWife); } }
        public override Type MutableType { get { return typeof(Wife); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableWifeImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new WifeImpl(this, model);
        }
    }

    internal class GreenListChild : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableListChild); } }
        public override Type MutableType { get { return typeof(ListChild); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableListChildImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new ListChildImpl(this, model);
        }
    }

    internal class GreenListParent : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableListParent); } }
        public override Type MutableType { get { return typeof(ListParent); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableListParentImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new ListParentImpl(this, model);
        }
    }

    internal class GreenUser : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableUser); } }
        public override Type MutableType { get { return typeof(User); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableUserImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new UserImpl(this, model);
        }
    }

    internal class GreenRole : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableRole); } }
        public override Type MutableType { get { return typeof(Role); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableRoleImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new RoleImpl(this, model);
        }
    }

    internal class GreenPerson : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutablePerson); } }
        public override Type MutableType { get { return typeof(Person); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutablePersonImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new PersonImpl(this, model);
        }
    }

    internal class GreenStudent : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableStudent); } }
        public override Type MutableType { get { return typeof(Student); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableStudentImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new StudentImpl(this, model);
        }
    }

    internal class GreenPet : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutablePet); } }
        public override Type MutableType { get { return typeof(Pet); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutablePetImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
        {
            return new PetImpl(this, model);
        }
    }

    internal class GreenDog : SymbolId
    {
        public override Type ImmutableType { get { return typeof(ImmutableDog); } }
        public override Type MutableType { get { return typeof(Dog); } }

        public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)
        {
            return new ImmutableDogImpl(this, model);
        }

        public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)
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

    public interface HusbandBuilder : Husband
    {
        Func<string> NameLazy { get; set; }
        Func<Wife> WifeLazy { get; set; }
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

        public ImmutableHusbandImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutableWifeImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutableListChildImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutableListParentImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutableUserImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutableRoleImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutablePersonImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutableStudentImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutablePetImpl(SymbolId green, ImmutableRedModelPart model)
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

        public ImmutableDogImpl(SymbolId green, ImmutableRedModelPart model)
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

    public class HusbandImpl : MutableRedSymbolBase, Husband, HusbandBuilder
    {
        public HusbandImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Husband.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Husband.WifeProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.Husband.NameProperty); }
            set { this.SetValue(TestModelDescriptor.Husband.NameProperty, value); }
        }

        public Func<string> NameLazy
        {
            get { return this.GetLazyValue<string>(TestModelDescriptor.Husband.NameProperty); }
            set { this.SetLazyValue(TestModelDescriptor.Husband.NameProperty, value); }
        }

        public Wife Wife
        {
            get { return this.GetValue<Wife>(TestModelDescriptor.Husband.WifeProperty); }
            set { this.SetValue(TestModelDescriptor.Husband.WifeProperty, value); }
        }

        public Func<Wife> WifeLazy
        {
            get { return this.GetLazyValue<Wife>(TestModelDescriptor.Husband.WifeProperty); }
            set { this.SetLazyValue(TestModelDescriptor.Husband.WifeProperty, value); }
        }

    }

    public class WifeImpl : MutableRedSymbolBase, Wife
    {
        public WifeImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Wife.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Wife.HusbandProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.Wife.NameProperty); }
            set { this.SetValue(TestModelDescriptor.Wife.NameProperty, value); }
        }

        public Husband Husband
        {
            get { return this.GetValue<Husband>(TestModelDescriptor.Wife.HusbandProperty); }
            set { this.SetValue(TestModelDescriptor.Wife.HusbandProperty, value); }
        }
    }

    public class ListChildImpl : MutableRedSymbolBase, ListChild
    {
        public ListChildImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.ListChild.NameProperty);
            this.MAttachProperty(TestModelDescriptor.ListChild.ParentProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.ListChild.NameProperty); }
            set { this.SetValue(TestModelDescriptor.ListChild.NameProperty, value); }
        }

        public ListParent Parent
        {
            get { return this.GetValue<ListParent>(TestModelDescriptor.ListChild.ParentProperty); }
            set { this.SetValue(TestModelDescriptor.ListChild.ParentProperty, value); }
        }
    }

    public class ListParentImpl : MutableRedSymbolBase, ListParent
    {
        private MutableRedList<ListChild> children;

        public ListParentImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.ListParent.NameProperty);
            this.MAttachProperty(TestModelDescriptor.ListParent.ChildrenProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.ListParent.NameProperty); }
            set { this.SetValue(TestModelDescriptor.ListParent.NameProperty, value); }
        }

        public ModelList<ListChild> Children
        {
            get { return this.GetList(TestModelDescriptor.ListParent.ChildrenProperty, ref this.children); }
        }

    }

    public class UserImpl : MutableRedSymbolBase, User
    {
        private MutableRedList<Role> roles;

        public UserImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.User.NameProperty);
            this.MAttachProperty(TestModelDescriptor.User.RolesProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.User.NameProperty); }
            set { this.SetValue(TestModelDescriptor.User.NameProperty, value); }
        }

        public ModelList<Role> Roles
        {
            get { return this.GetList(TestModelDescriptor.User.RolesProperty, ref this.roles); }
        }

    }

    public class RoleImpl : MutableRedSymbolBase, Role
    {
        private MutableRedList<User> roles;

        public RoleImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Role.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Role.UsersProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.Role.NameProperty); }
            set { this.SetValue(TestModelDescriptor.Role.NameProperty, value); }
        }

        public ModelList<User> Users
        {
            get { return this.GetList(TestModelDescriptor.Role.UsersProperty, ref this.roles); }
        }

    }

    public class PersonImpl : MutableRedSymbolBase, Person
    {
        private MutableRedList<Pet> pets;

        public PersonImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Person.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Person.PetsProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.Person.NameProperty); }
            set { this.SetValue(TestModelDescriptor.Person.NameProperty, value); }
        }

        public ModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

    }

    public class StudentImpl : MutableRedSymbolBase, Student
    {
        private MutableRedList<Pet> pets;
        private MutableRedList<Dog> dogs;

        public StudentImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Person.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Person.PetsProperty);
            this.MAttachProperty(TestModelDescriptor.Student.DogsProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.Person.NameProperty); }
            set { this.SetValue(TestModelDescriptor.Person.NameProperty, value); }
        }

        public ModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

        public ModelList<Dog> Dogs
        {
            get { return this.GetList(TestModelDescriptor.Student.DogsProperty, ref this.dogs); }
        }

    }

    public class PetImpl : MutableRedSymbolBase, Pet
    {
        public PetImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Pet.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Pet.OwnerProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.Pet.NameProperty); }
            set { this.SetValue(TestModelDescriptor.Pet.NameProperty, value); }
        }

        public Person Owner
        {
            get { return this.GetValue<Person>(TestModelDescriptor.Pet.OwnerProperty); }
            set { this.SetValue(TestModelDescriptor.Pet.OwnerProperty, value); }
        }
    }

    public class DogImpl : MutableRedSymbolBase, Dog
    {
        public DogImpl(SymbolId green, MutableRedModelPart model)
            : base(green, model)
        {
            this.MAttachProperty(TestModelDescriptor.Pet.NameProperty);
            this.MAttachProperty(TestModelDescriptor.Pet.OwnerProperty);
            this.MAttachProperty(TestModelDescriptor.Dog.FriendProperty);
            this.MInit();
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
            get { return this.GetValue<string>(TestModelDescriptor.Pet.NameProperty); }
            set { this.SetValue(TestModelDescriptor.Pet.NameProperty, value); }
        }

        public Person Owner
        {
            get { return this.GetValue<Person>(TestModelDescriptor.Pet.OwnerProperty); }
            set { this.SetValue(TestModelDescriptor.Pet.OwnerProperty, value); }
        }

        public Student Friend
        {
            get { return this.GetValue<Student>(TestModelDescriptor.Dog.FriendProperty); }
            set { this.SetValue(TestModelDescriptor.Dog.FriendProperty, value); }
        }

    }
}