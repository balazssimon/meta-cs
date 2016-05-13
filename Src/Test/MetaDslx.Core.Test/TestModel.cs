using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Test
{
    class Husband : ModelObject
    {
        [OppositeAttribute(typeof(Wife), "Husband")]
        public static readonly ModelProperty WifeProperty =
            ModelProperty.Register("Wife", typeof(Wife), typeof(Husband));

        public Wife Wife
        {
            get { return (Wife)this.MGet(Husband.WifeProperty); }
            set { this.MSet(Husband.WifeProperty, value); }
        }
    }

    class Wife : ModelObject
    {
        [OppositeAttribute(typeof(Husband), "Wife")]
        public static readonly ModelProperty HusbandProperty =
            ModelProperty.Register("Husband", typeof(Husband), typeof(Wife));

        public Husband Husband
        {
            get { return (Husband)this.MGet(Wife.HusbandProperty); }
            set { this.MSet(Wife.HusbandProperty, value); }
        }
    }


    class ListParent : ModelObject
    {
        public ListParent()
        {
            this.MSet(ListParent.ChildrenProperty, new ModelList<ListChild>(this, ListParent.ChildrenProperty));
        }

        [OppositeAttribute(typeof(ListChild), "Parent")]
        public static readonly ModelProperty ChildrenProperty =
            ModelProperty.Register("Children", typeof(ModelList<ListChild>), typeof(ListParent));

        public IList<ListChild> Children
        {
            get { return (IList<ListChild>)this.MGet(ListParent.ChildrenProperty); }
        }
    }

    class ListChild : ModelObject
    {
        [OppositeAttribute(typeof(ListParent), "Children")]
        public static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(ListParent), typeof(ListChild));

        public ListParent Parent
        {
            get { return (ListParent)this.MGet(ListChild.ParentProperty); }
            set { this.MSet(ListChild.ParentProperty, value); }
        }
    }

    class SetParent : ModelObject
    {
        public SetParent()
        {
            this.MSet(SetParent.ChildrenProperty, new ModelSet<SetChild>(this, SetParent.ChildrenProperty));
        }

        [OppositeAttribute(typeof(SetChild), "Parent")]
        public static readonly ModelProperty ChildrenProperty =
            ModelProperty.Register("Children", typeof(ModelSet<SetChild>), typeof(SetParent));

        public ICollection<SetChild> Children
        {
            get { return (ICollection<SetChild>)this.MGet(SetParent.ChildrenProperty); }
        }
    }

    class SetChild : ModelObject
    {
        [OppositeAttribute(typeof(SetParent), "Children")]
        public static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(SetParent), typeof(SetChild));

        public SetParent Parent
        {
            get { return (SetParent)this.MGet(SetChild.ParentProperty); }
            set { this.MSet(SetChild.ParentProperty, value); }
        }
    }

    class User : ModelObject
    {
        public User()
        {
            this.MSet(User.RolesProperty, new ModelList<Role>(this, User.RolesProperty));
        }

        [OppositeAttribute(typeof(Role), "Users")]
        public static readonly ModelProperty RolesProperty =
            ModelProperty.Register("Roles", typeof(ModelList<Role>), typeof(User));

        public IList<Role> Roles
        {
            get { return (IList<Role>)this.MGet(User.RolesProperty); }
        }
    }

    class Role : ModelObject
    {
        public Role()
        {
            this.MSet(Role.UsersProperty, new ModelSet<User>(this, Role.UsersProperty));
        }

        [OppositeAttribute(typeof(User), "Roles")]
        public static readonly ModelProperty UsersProperty =
            ModelProperty.Register("Users", typeof(ModelSet<User>), typeof(Role));

        public ICollection<User> Users
        {
            get { return (ICollection<User>)this.MGet(Role.UsersProperty); }
        }
    }

    class Person : ModelObject
    {
        public Person()
        {
            this.MSet(Person.PetsProperty, new ModelSet<Pet>(this, Person.PetsProperty));
        }

        [OppositeAttribute(typeof(Pet), "Owner")]
        public static readonly ModelProperty PetsProperty =
            ModelProperty.Register("Pets", typeof(ModelSet<Pet>), typeof(Person));

        public ICollection<Pet> Pets
        {
            get { return (ICollection<Pet>)this.MGet(Person.PetsProperty); }
        }
    }

    class Student : Person
    {
        public Student()
        {
            this.MSet(Student.DogsProperty, new ModelSet<Dog>(this, Student.DogsProperty));
        }

        [OppositeAttribute(typeof(Dog), "Friend")]
        public static readonly ModelProperty DogsProperty =
            ModelProperty.Register("Dogs", typeof(ModelSet<Dog>), typeof(Student));

        public ICollection<Dog> Dogs
        {
            get { return (ICollection<Dog>)this.MGet(Student.DogsProperty); }
        }
    }

    class Pet : ModelObject
    {
        public Pet()
        {
        }

        [OppositeAttribute(typeof(Person), "Pets")]
        public static readonly ModelProperty OwnerProperty =
            ModelProperty.Register("Owner", typeof(Person), typeof(Pet));

        public Person Owner
        {
            get { return (Person)this.MGet(Pet.OwnerProperty); }
            set { this.MSet(Pet.OwnerProperty, value); }
        }
    }

    class Dog : Pet
    {
        public Dog()
        {
        }

        [OppositeAttribute(typeof(Student), "Dogs")]
        public static readonly ModelProperty FriendProperty =
            ModelProperty.Register("Friend", typeof(Student), typeof(Dog));

        public Student Friend
        {
            get { return (Student)this.MGet(Dog.FriendProperty); }
            set { this.MSet(Dog.FriendProperty, value); }
        }
    }

    interface IPersonX
    {
        ICollection<IPetX> Pets { get; }
    }

    interface IStudentX : IPersonX
    {
        ICollection<IDogX> Dogs { get; }
    }

    interface IPetX
    {
        IPersonX Owner { get; set; }
    }

    interface IDogX : IPetX
    {
        IStudentX Friend { get; set; }
    }

    class PersonX : ModelObject, IPersonX
    {
        public PersonX()
        {
            this.MSet(PersonX.PetsProperty, new ModelSet<IPetX>(this, PersonX.PetsProperty));
        }

        [OppositeAttribute(typeof(PetX), "Owner")]
        public static readonly ModelProperty PetsProperty =
            ModelProperty.Register("Pets", typeof(ICollection<IPetX>), typeof(PersonX));

        public ICollection<IPetX> Pets
        {
            get { return (ICollection<IPetX>)this.MGet(PersonX.PetsProperty); }
        }
    }

    class StudentX : ModelObject, IStudentX
    {
        public StudentX()
        {
            this.MSet(StudentX.DogsProperty, new ModelSet<IDogX>(this, StudentX.DogsProperty));
            this.MSet(PersonX.PetsProperty, new ModelSet<IPetX>(this, PersonX.PetsProperty));
        }

        [OppositeAttribute(typeof(DogX), "Friend")]
        public static readonly ModelProperty DogsProperty =
            ModelProperty.Register("Dogs", typeof(ICollection<IDogX>), typeof(StudentX));

        public ICollection<IDogX> Dogs
        {
            get { return (ICollection<IDogX>)this.MGet(StudentX.DogsProperty); }
        }

        public ICollection<IPetX> Pets
        {
            get { return (ICollection<IPetX>)this.MGet(PersonX.PetsProperty); }
        }
    }

    class PetX : ModelObject, IPetX
    {
        public PetX()
        {
        }

        [OppositeAttribute(typeof(PersonX), "Pets")]
        public static readonly ModelProperty OwnerProperty =
            ModelProperty.Register("Owner", typeof(IPersonX), typeof(PetX));

        public IPersonX Owner
        {
            get { return (IPersonX)this.MGet(PetX.OwnerProperty); }
            set { this.MSet(PetX.OwnerProperty, value); }
        }
    }

    class DogX : ModelObject, IDogX
    {
        public DogX()
        {
        }

        [OppositeAttribute(typeof(StudentX), "Dogs")]
        public static readonly ModelProperty FriendProperty =
            ModelProperty.Register("Friend", typeof(IStudentX), typeof(DogX));

        public IStudentX Friend
        {
            get { return (IStudentX)this.MGet(DogX.FriendProperty); }
            set { this.MSet(DogX.FriendProperty, value); }
        }

        public IPersonX Owner
        {
            get { return (IPersonX)this.MGet(PetX.OwnerProperty); }
            set { this.MSet(PetX.OwnerProperty, value); }
        }
    }

}
