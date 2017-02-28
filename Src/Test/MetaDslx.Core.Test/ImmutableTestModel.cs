using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MetaDslx.Core.Immutable.Test
{
    using Compiler.Diagnostics;
    using Languages.Meta.Symbols;
    using System.Collections.Immutable;
    using System.Threading;
    public static class TestModelDescriptor
    {
        private static ImmutableList<ModelProperty> properties;

        static TestModelDescriptor()
        {
            List<ModelProperty> properties = new List<ModelProperty>();
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

            Interlocked.CompareExchange(ref TestModelDescriptor.properties, properties.ToImmutableList(), null);
        }

        public static void Initialize()
        {
        }

        [ModelSymbolDescriptor(null, typeof(Test.Husband))]
        public static class Husband
        {
            static Husband()
            {
                Husband.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Husband));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(Husband), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Opposite(typeof(Wife), "Husband")]
            public static readonly ModelProperty WifeProperty =
                ModelProperty.Register(typeof(Husband), "Wife", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableWife), null),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.Wife), null));
        }
        [ModelSymbolDescriptor(null, typeof(Test.Wife))]
        public static class Wife
        {
            static Wife()
            {
                Wife.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Wife));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(Wife), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Opposite(typeof(Husband), "Wife")]
            public static readonly ModelProperty HusbandProperty =
                ModelProperty.Register(typeof(Wife), "Husband", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableHusband), null),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.Husband), null));
        }
        [ModelSymbolDescriptor(null, typeof(Test.ListChild))]
        public static class ListChild
        {
            static ListChild()
            {
                ListChild.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ListChild));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(ListChild), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Opposite(typeof(ListParent), "Children")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register(typeof(ListChild), "Parent", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableListParent), null),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ListParent), null));
        }
        [ModelSymbolDescriptor(null, typeof(Test.ListParent))]
        public static class ListParent
        {
            static ListParent()
            {
                ListParent.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ListParent));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(ListParent), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Containment]
            [Opposite(typeof(ListChild), "Parent")]
            public static readonly ModelProperty ChildrenProperty =
                ModelProperty.Register(typeof(ListParent), "Children", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableListChild), typeof(ImmutableModelList<MetaDslx.Core.Immutable.Test.ImmutableListChild>)),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ListChild), typeof(MutableModelList<MetaDslx.Core.Immutable.Test.ListChild>)));
        }
        [ModelSymbolDescriptor(null, typeof(Test.User))]
        public static class User
        {
            static User()
            {
                User.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(User));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(User), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Opposite(typeof(Role), "Users")]
            public static readonly ModelProperty RolesProperty =
                ModelProperty.Register(typeof(User), "Roles", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableRole), typeof(ImmutableModelList<MetaDslx.Core.Immutable.Test.ImmutableRole>)),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.Role), typeof(MutableModelList<MetaDslx.Core.Immutable.Test.Role>)));
        }
        [ModelSymbolDescriptor(null, typeof(Test.Role))]
        public static class Role
        {
            static Role()
            {
                Role.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Role));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(Role), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Opposite(typeof(User), "Roles")]
            public static readonly ModelProperty UsersProperty =
                ModelProperty.Register(typeof(Role), "Users", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableUser), typeof(ImmutableModelList<MetaDslx.Core.Immutable.Test.ImmutableUser>)),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.User), typeof(MutableModelList<MetaDslx.Core.Immutable.Test.User>)));
        }
        [ModelSymbolDescriptor(null, typeof(Test.Person))]
        public static class Person
        {
            static Person()
            {
                Person.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Person));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(Person), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Opposite(typeof(Pet), "Owner")]
            public static readonly ModelProperty PetsProperty =
                ModelProperty.Register(typeof(Person), "Pets", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutablePet), typeof(ImmutableModelList<MetaDslx.Core.Immutable.Test.ImmutablePet>)),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.Pet), typeof(MutableModelList<MetaDslx.Core.Immutable.Test.Pet>)));
        }
        [ModelSymbolDescriptor(null, typeof(Test.Student), BaseSymbolDescriptors = new Type[] { typeof(Person) })]
        public static class Student
        {
            static Student()
            {
                Student.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Student));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            [Redefines(typeof(Person), "Pets")]
            [Opposite(typeof(Dog), "Friend")]
            public static readonly ModelProperty DogsProperty =
                ModelProperty.Register(typeof(Student), "Dogs",
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableDog), typeof(ImmutableModelList<MetaDslx.Core.Immutable.Test.ImmutableDog>)),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.Dog), typeof(MutableModelList<MetaDslx.Core.Immutable.Test.Dog>)));
        }
        [ModelSymbolDescriptor(null, typeof(Test.Pet))]
        public static class Pet
        {
            static Pet()
            {
                Pet.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Pet));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            public static readonly ModelProperty NameProperty =
                ModelProperty.Register(typeof(Pet), "Name", 
                    new ModelPropertyTypeInfo(typeof(string), null),
                    new ModelPropertyTypeInfo(typeof(string), null));
            [Opposite(typeof(Person), "Pets")]
            public static readonly ModelProperty OwnerProperty =
                ModelProperty.Register(typeof(Pet), "Owner", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutablePerson), null),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.Person), null));
        }
        [ModelSymbolDescriptor(null, typeof(Test.Dog), BaseSymbolDescriptors = new Type[] { typeof(Pet) })]
        public static class Dog
        {
            static Dog()
            {
                Dog.ModelSymbolInfo = ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Dog));
            }

            public static ModelSymbolInfo ModelSymbolInfo { get; }

            [Redefines(typeof(Pet), "Owner")]
            [Opposite(typeof(Student), "Dogs")]
            public static readonly ModelProperty FriendProperty =
                ModelProperty.Register(typeof(Dog), "Friend", 
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.ImmutableStudent), null),
                    new ModelPropertyTypeInfo(typeof(MetaDslx.Core.Immutable.Test.Student), null));
        }
    }

    public class TestModelFactory : ModelFactory
    {
        public TestModelFactory(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.None)
            : base(model, flags)
        {
            TestModelDescriptor.Initialize();
        }

        public override MutableSymbol Create(string type)
        {
            switch (type)
            {
                case "Husband": return (MutableSymbolBase)this.Husband();
                case "Wife": return (MutableSymbolBase)this.Wife();
                case "ListChild": return (MutableSymbolBase)this.ListChild();
                case "ListParent": return (MutableSymbolBase)this.ListParent();
                case "User": return (MutableSymbolBase)this.User();
                case "Role": return (MutableSymbolBase)this.Role();
                default:
                    throw new ModelException(Location.None, new DiagnosticInfo(ModelErrorCode.ERR_UnknownTypeName, type));
            }
        }

        public Husband Husband()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenHusband());
            return (Husband)symbol;
        }

        public Wife Wife()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenWife());
            return (Wife)symbol;
        }

        public ListChild ListChild()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenListChild());
            return (ListChild)symbol;
        }

        public ListParent ListParent()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenListParent());
            return (ListParent)symbol;
        }

        public User User()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenUser());
            return (User)symbol;
        }

        public Role Role()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenRole());
            return (Role)symbol;
        }

        public Person Person()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenPerson());
            return (Person)symbol;
        }

        public Student Student()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenStudent());
            return (Student)symbol;
        }

        public Pet Pet()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenPet());
            return (Pet)symbol;
        }

        public Dog Dog()
        {
            MutableSymbol symbol = this.CreateSymbol(new GreenDog());
            return (Dog)symbol;
        }
    }

    internal class GreenHusband : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.Husband.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableHusbandImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new HusbandImpl(this, model, creating);
        }
    }

    internal class GreenWife : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.Wife.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableWifeImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new WifeImpl(this, model, creating);
        }
    }

    internal class GreenListChild : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.ListChild.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableListChildImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new ListChildImpl(this, model, creating);
        }
    }

    internal class GreenListParent : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.ListParent.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableListParentImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new ListParentImpl(this, model, creating);
        }
    }

    internal class GreenUser : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.User.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableUserImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new UserImpl(this, model, creating);
        }
    }

    internal class GreenRole : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.Role.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableRoleImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new RoleImpl(this, model, creating);
        }
    }

    internal class GreenPerson : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.Person.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutablePersonImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new PersonImpl(this, model, creating);
        }
    }

    internal class GreenStudent : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.Student.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableStudentImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new StudentImpl(this, model, creating);
        }
    }

    internal class GreenPet : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.Pet.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutablePetImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new PetImpl(this, model, creating);
        }
    }

    internal class GreenDog : SymbolId
    {
        public override ModelSymbolInfo SymbolInfo { get { return TestModelDescriptor.Dog.ModelSymbolInfo; } }

        public override ImmutableSymbolBase CreateImmutable(ImmutableModel model)
        {
            return new ImmutableDogImpl(this, model);
        }

        public override MutableSymbolBase CreateMutable(MutableModel model, bool creating)
        {
            return new DogImpl(this, model, creating);
        }
    }

    public interface ImmutableHusband : ImmutableSymbol
    {
        string Name { get; }
        ImmutableWife Wife { get; }

        new Husband ToMutable();
    }

    public interface ImmutableWife : ImmutableSymbol
    {
        string Name { get; }
        ImmutableHusband Husband { get; }

        new Wife ToMutable();
    }

    public interface ImmutableListChild : ImmutableSymbol
    {
        string Name { get; }
        ImmutableListParent Parent { get; }
    }

    public interface ImmutableListParent : ImmutableSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutableListChild> Children { get; }
    }

    public interface ImmutableUser : ImmutableSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutableRole> Roles { get; }
    }

    public interface ImmutableRole : ImmutableSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutableUser> Users { get; }
    }

    public interface ImmutablePerson : ImmutableSymbol
    {
        string Name { get; }
        ImmutableModelList<ImmutablePet> Pets { get; }
    }

    public interface ImmutableStudent : ImmutablePerson
    {
        ImmutableModelList<ImmutableDog> Dogs { get; }
    }

    public interface ImmutablePet : ImmutableSymbol
    {
        string Name { get; }
        ImmutablePerson Owner { get; }
    }

    public interface ImmutableDog : ImmutablePet
    {
        ImmutableStudent Friend { get; }
    }

    public interface Husband : MutableSymbol
    {
        string Name { get; set; }
        Wife Wife { get; set; }

        new ImmutableHusband ToImmutable();
    }

    public interface HusbandBuilder : Husband
    {
        Func<string> NameLazy { get; set; }
        Func<Wife> WifeLazy { get; set; }
    }

    public interface Wife : MutableSymbol
    {
        string Name { get; set; }
        Husband Husband { get; set; }

        new ImmutableWife ToImmutable();
    }

    public interface ListChild : MutableSymbol
    {
        string Name { get; set; }
        ListParent Parent { get; set; }
    }

    public interface ListParent : MutableSymbol
    {
        string Name { get; set; }
        MutableModelList<ListChild> Children { get; }
    }

    public interface User : MutableSymbol
    {
        string Name { get; set; }
        MutableModelList<Role> Roles { get; }
    }

    public interface Role : MutableSymbol
    {
        string Name { get; set; }
        MutableModelList<User> Users { get; }
    }

    public interface Person : MutableSymbol
    {
        string Name { get; set; }
        MutableModelList<Pet> Pets { get; }
    }

    public interface Student : Person
    {
        MutableModelList<Dog> Dogs { get; }
    }

    public interface Pet : MutableSymbol
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

        public override MetaClass MMetaClass
        {
            get{ return null; }
        }

        public override MetaModel MMetaModel
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

        Husband ImmutableHusband.ToMutable()
        {
            return (Husband)base.ToMutable();
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

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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

        Wife ImmutableWife.ToMutable()
        {
            return (Wife)base.ToMutable();
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

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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
        private ImmutableModelList<ImmutableListChild> children;

        public ImmutableListParentImpl(SymbolId green, ImmutableModel model)
            : base(green, model)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference(TestModelDescriptor.ListParent.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutableListChild> Children
        {
            get { return this.GetList(TestModelDescriptor.ListParent.ChildrenProperty, ref this.children); }
        }
    }

    public class ImmutableUserImpl : ImmutableSymbolBase, ImmutableUser
    {
        private string name;
        private ImmutableModelList<ImmutableRole> roles;

        public ImmutableUserImpl(SymbolId green, ImmutableModel model)
            : base(green, model)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference(TestModelDescriptor.User.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutableRole> Roles
        {
            get { return this.GetList(TestModelDescriptor.User.RolesProperty, ref this.roles); }
        }
    }

    public class ImmutableRoleImpl : ImmutableSymbolBase, ImmutableRole
    {
        private string name;
        private ImmutableModelList<ImmutableUser> users;

        public ImmutableRoleImpl(SymbolId green, ImmutableModel model)
            : base(green, model)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference(TestModelDescriptor.Role.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutableUser> Users
        {
            get { return this.GetList(TestModelDescriptor.Role.UsersProperty, ref this.users); }
        }
    }

    public class ImmutablePersonImpl : ImmutableSymbolBase, ImmutablePerson
    {
        private string name;
        private ImmutableModelList<ImmutablePet> pets;

        public ImmutablePersonImpl(SymbolId green, ImmutableModel model)
            : base(green, model)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference(TestModelDescriptor.Person.NameProperty, ref this.name); }
        }

        public ImmutableModelList<ImmutablePet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }
    }

    public class ImmutableStudentImpl : ImmutableSymbolBase, ImmutableStudent
    {
        private string name;
        private ImmutableModelList<ImmutablePet> pets;
        private ImmutableModelList<ImmutableDog> dogs;

        public ImmutableStudentImpl(SymbolId green, ImmutableModel model)
            : base(green, model)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference(TestModelDescriptor.Person.NameProperty, ref this.name); }
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

    public class ImmutablePetImpl : ImmutableSymbolBase, ImmutablePet
    {
        private string name;
        private ImmutablePerson owner;

        public ImmutablePetImpl(SymbolId green, ImmutableModel model)
            : base(green, model)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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
        public HusbandImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public new ImmutableHusband ToImmutable()
        {
            return (ImmutableHusband)base.ToImmutable();
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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
        public WifeImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        ImmutableWife Wife.ToImmutable()
        {
            return (ImmutableWife)base.ToImmutable();
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
        public ListChildImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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
        private MutableModelList<ListChild> children;

        public ListParentImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference<string>(TestModelDescriptor.ListParent.NameProperty); }
            set { this.SetReference(TestModelDescriptor.ListParent.NameProperty, value); }
        }

        public MutableModelList<ListChild> Children
        {
            get { return this.GetList(TestModelDescriptor.ListParent.ChildrenProperty, ref this.children); }
        }

    }

    public class UserImpl : MutableSymbolBase, User
    {
        private MutableModelList<Role> roles;

        public UserImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference<string>(TestModelDescriptor.User.NameProperty); }
            set { this.SetReference(TestModelDescriptor.User.NameProperty, value); }
        }

        public MutableModelList<Role> Roles
        {
            get { return this.GetList(TestModelDescriptor.User.RolesProperty, ref this.roles); }
        }

    }

    public class RoleImpl : MutableSymbolBase, Role
    {
        private MutableModelList<User> roles;

        public RoleImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference<string>(TestModelDescriptor.Role.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Role.NameProperty, value); }
        }

        public MutableModelList<User> Users
        {
            get { return this.GetList(TestModelDescriptor.Role.UsersProperty, ref this.roles); }
        }

    }

    public class PersonImpl : MutableSymbolBase, Person
    {
        private MutableModelList<Pet> pets;

        public PersonImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference<string>(TestModelDescriptor.Person.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Person.NameProperty, value); }
        }

        public MutableModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

    }

    public class StudentImpl : MutableSymbolBase, Student
    {
        private MutableModelList<Pet> pets;
        private MutableModelList<Dog> dogs;

        public StudentImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
        {
            get { return null; }
        }

        public string Name
        {
            get { return this.GetReference<string>(TestModelDescriptor.Person.NameProperty); }
            set { this.SetReference(TestModelDescriptor.Person.NameProperty, value); }
        }

        public MutableModelList<Pet> Pets
        {
            get { return this.GetList(TestModelDescriptor.Person.PetsProperty, ref this.pets); }
        }

        public MutableModelList<Dog> Dogs
        {
            get { return this.GetList(TestModelDescriptor.Student.DogsProperty, ref this.dogs); }
        }

    }

    public class PetImpl : MutableSymbolBase, Pet
    {
        public PetImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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
        public DogImpl(SymbolId green, MutableModel model, bool creating)
            : base(green, model, creating)
        {
        }

        public override MetaClass MMetaClass
        {
            get { return null; }
        }

        public override MetaModel MMetaModel
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