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
            get { return (Wife)this.MGetValue(Husband.WifeProperty); }
            set { this.MSetValue(Husband.WifeProperty, value); }
        }
    }

    class Wife : ModelObject
    {
        [OppositeAttribute(typeof(Husband), "Wife")]
        public static readonly ModelProperty HusbandProperty =
            ModelProperty.Register("Husband", typeof(Husband), typeof(Wife));

        public Husband Husband
        {
            get { return (Husband)this.MGetValue(Wife.HusbandProperty); }
            set { this.MSetValue(Wife.HusbandProperty, value); }
        }
    }


    class ListParent : ModelObject
    {
        public ListParent()
        {
            this.MInitValue(ListParent.ChildrenProperty, () => new ModelList<ListChild>(this, ListParent.ChildrenProperty));
        }

        [OppositeAttribute(typeof(ListChild), "Parent")]
        public static readonly ModelProperty ChildrenProperty =
            ModelProperty.Register("Children", typeof(ModelList<ListChild>), typeof(ListParent));

        public IList<ListChild> Children
        {
            get { return (IList<ListChild>)this.MGetValue(ListParent.ChildrenProperty); }
        }
    }

    class ListChild : ModelObject
    {
        [OppositeAttribute(typeof(ListParent), "Children")]
        public static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(ListParent), typeof(ListChild));

        public ListParent Parent
        {
            get { return (ListParent)this.MGetValue(ListChild.ParentProperty); }
            set { this.MSetValue(ListChild.ParentProperty, value); }
        }
    }

    class SetParent : ModelObject
    {
        public SetParent()
        {
            this.MSetValue(SetParent.ChildrenProperty, new ModelSet<SetChild>(this, SetParent.ChildrenProperty));
        }

        [OppositeAttribute(typeof(SetChild), "Parent")]
        public static readonly ModelProperty ChildrenProperty =
            ModelProperty.Register("Children", typeof(ModelSet<SetChild>), typeof(SetParent));

        public ICollection<SetChild> Children
        {
            get { return (ICollection<SetChild>)this.MGetValue(SetParent.ChildrenProperty); }
        }
    }

    class SetChild : ModelObject
    {
        [OppositeAttribute(typeof(SetParent), "Children")]
        public static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(SetParent), typeof(SetChild));

        public SetParent Parent
        {
            get { return (SetParent)this.MGetValue(SetChild.ParentProperty); }
            set { this.MSetValue(SetChild.ParentProperty, value); }
        }
    }

    class User : ModelObject
    {
        public User()
        {
            this.MSetValue(User.RolesProperty, new ModelList<Role>(this, User.RolesProperty));
        }

        [OppositeAttribute(typeof(Role), "Users")]
        public static readonly ModelProperty RolesProperty =
            ModelProperty.Register("Roles", typeof(ModelList<Role>), typeof(User));

        public IList<Role> Roles
        {
            get { return (IList<Role>)this.MGetValue(User.RolesProperty); }
        }
    }

    class Role : ModelObject
    {
        public Role()
        {
            this.MSetValue(Role.UsersProperty, new ModelSet<User>(this, Role.UsersProperty));
        }

        [OppositeAttribute(typeof(User), "Roles")]
        public static readonly ModelProperty UsersProperty =
            ModelProperty.Register("Users", typeof(ModelSet<User>), typeof(Role));

        public ICollection<User> Users
        {
            get { return (ICollection<User>)this.MGetValue(Role.UsersProperty); }
        }
    }
}
