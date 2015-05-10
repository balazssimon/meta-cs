using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Test
{
    class Husband : MetaObject
    {
        [OppositeAttribute(typeof(Wife), "Husband")]
        public static readonly MetaProperty WifeProperty =
            MetaProperty.Register("Wife", typeof(Wife), typeof(Husband));

        public Wife Wife
        {
            get { return (Wife)this.MetaGetValue(Husband.WifeProperty); }
            set { this.MetaSetValue(Husband.WifeProperty, value); }
        }
    }

    class Wife : MetaObject
    {
        [OppositeAttribute(typeof(Husband), "Wife")]
        public static readonly MetaProperty HusbandProperty =
            MetaProperty.Register("Husband", typeof(Husband), typeof(Wife));

        public Husband Husband
        {
            get { return (Husband)this.MetaGetValue(Wife.HusbandProperty); }
            set { this.MetaSetValue(Wife.HusbandProperty, value); }
        }
    }


    class ListParent : MetaObject
    {
        public ListParent()
        {
            this.MetaInitValue(ListParent.ChildrenProperty, () => new MetaList<ListChild>(this, ListParent.ChildrenProperty));
        }

        [OppositeAttribute(typeof(ListChild), "Parent")]
        public static readonly MetaProperty ChildrenProperty =
            MetaProperty.Register("Children", typeof(MetaList<ListChild>), typeof(ListParent));

        public IList<ListChild> Children
        {
            get { return (IList<ListChild>)this.MetaGetValue(ListParent.ChildrenProperty); }
        }
    }

    class ListChild : MetaObject
    {
        [OppositeAttribute(typeof(ListParent), "Children")]
        public static readonly MetaProperty ParentProperty =
            MetaProperty.Register("Parent", typeof(ListParent), typeof(ListChild));

        public ListParent Parent
        {
            get { return (ListParent)this.MetaGetValue(ListChild.ParentProperty); }
            set { this.MetaSetValue(ListChild.ParentProperty, value); }
        }
    }

    class SetParent : MetaObject
    {
        public SetParent()
        {
            this.MetaSetValue(SetParent.ChildrenProperty, new MetaSet<SetChild>(this, SetParent.ChildrenProperty));
        }

        [OppositeAttribute(typeof(SetChild), "Parent")]
        public static readonly MetaProperty ChildrenProperty =
            MetaProperty.Register("Children", typeof(MetaSet<SetChild>), typeof(SetParent));

        public ICollection<SetChild> Children
        {
            get { return (ICollection<SetChild>)this.MetaGetValue(SetParent.ChildrenProperty); }
        }
    }

    class SetChild : MetaObject
    {
        [OppositeAttribute(typeof(SetParent), "Children")]
        public static readonly MetaProperty ParentProperty =
            MetaProperty.Register("Parent", typeof(SetParent), typeof(SetChild));

        public SetParent Parent
        {
            get { return (SetParent)this.MetaGetValue(SetChild.ParentProperty); }
            set { this.MetaSetValue(SetChild.ParentProperty, value); }
        }
    }

    class User : MetaObject
    {
        public User()
        {
            this.MetaSetValue(User.RolesProperty, new MetaList<Role>(this, User.RolesProperty));
        }

        [OppositeAttribute(typeof(Role), "Users")]
        public static readonly MetaProperty RolesProperty =
            MetaProperty.Register("Roles", typeof(MetaList<Role>), typeof(User));

        public IList<Role> Roles
        {
            get { return (IList<Role>)this.MetaGetValue(User.RolesProperty); }
        }
    }

    class Role : MetaObject
    {
        public Role()
        {
            this.MetaSetValue(Role.UsersProperty, new MetaSet<User>(this, Role.UsersProperty));
        }

        [OppositeAttribute(typeof(User), "Roles")]
        public static readonly MetaProperty UsersProperty =
            MetaProperty.Register("Users", typeof(MetaSet<User>), typeof(Role));

        public ICollection<User> Users
        {
            get { return (ICollection<User>)this.MetaGetValue(Role.UsersProperty); }
        }
    }
}
