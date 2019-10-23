namespace MetaDslx.CodeAnalysis.Meta.Test.Languages.PropertiesTest
{
	metamodel PropertiesTest;

	class Wife
	{
		Husband Husband;
	}

	class Husband
	{
		Wife Wife;
	}

	association Wife.Husband with Husband.Wife;
	
	class ParentSet
	{
		set<ChildSet> Children;
	}

	class ChildSet
	{
		ParentSet Parent;
	}

	association ParentSet.Children with ChildSet.Parent;
		
	class ParentList
	{
		list<ChildList> Children;
	}

	class ChildList
	{
		ParentList Parent;
	}
	
	association ParentList.Children with ChildList.Parent;

	class ParentMultiSet
	{
		multi_set<ChildMultiSet> Children;
	}

	class ChildMultiSet
	{
		ParentMultiSet Parent;
	}
	
	association ParentMultiSet.Children with ChildMultiSet.Parent;
		
	class ParentMultiList
	{
		multi_list<ChildMultiList> Children;
	}

	class ChildMultiList
	{
		ParentMultiList Parent;
	}
	
	association ParentMultiList.Children with ChildMultiList.Parent;

	class Association
	{
		AssociationEnd First;
		AssociationEnd Second;
		set<AssociationEndSet> FirstSet;
		set<AssociationEndSet> SecondSet;
		list<AssociationEndList> FirstList;
		list<AssociationEndList> SecondList;
		multi_set<AssociationEndMultiSet> FirstMultiSet;
		multi_set<AssociationEndMultiSet> SecondMultiSet;
		multi_list<AssociationEndMultiList> FirstMultiList;
		multi_list<AssociationEndMultiList> SecondMultiList;
	}

	class AssociationEnd
	{
		Association Association;
	}

	class AssociationEndSet
	{
		Association Association;
	}
	
	class AssociationEndList
	{
		Association Association;
	}

	class AssociationEndMultiSet
	{
		Association Association;
	}
	
	class AssociationEndMultiList
	{
		Association Association;
	}

	association Association.First with AssociationEnd.Association;
	association Association.Second with AssociationEnd.Association;
	association Association.FirstSet with AssociationEndSet.Association;
	association Association.SecondSet with AssociationEndSet.Association;
	association Association.FirstList with AssociationEndList.Association;
	association Association.SecondList with AssociationEndList.Association;
	association Association.FirstMultiSet with AssociationEndMultiSet.Association;
	association Association.SecondMultiSet with AssociationEndMultiSet.Association;
	association Association.FirstMultiList with AssociationEndMultiList.Association;
	association Association.SecondMultiList with AssociationEndMultiList.Association;

	class User
	{
		set<Role> RolesSet2Set;
		list<Role> RolesList2Set;
		multi_set<Role> RolesMultiSet2Set;
		multi_list<Role> RolesMultiList2Set;
		set<Role> RolesSet2List;
		list<Role> RolesList2List;
		multi_set<Role> RolesMultiSet2List;
		multi_list<Role> RolesMultiList2List;
		set<Role> RolesSet2MultiSet;
		list<Role> RolesList2MultiSet;
		multi_set<Role> RolesMultiSet2MultiSet;
		multi_list<Role> RolesMultiList2MultiSet;
		set<Role> RolesSet2MultiList;
		list<Role> RolesList2MultiList;
		multi_set<Role> RolesMultiSet2MultiList;
		multi_list<Role> RolesMultiList2MultiList;
	}

	class Role
	{
		set<User> UsersSet2Set;
		set<User> UsersList2Set;
		set<User> UsersMultiSet2Set;
		set<User> UsersMultiList2Set;
		list<User> UsersSet2List;
		list<User> UsersList2List;
		list<User> UsersMultiSet2List;
		list<User> UsersMultiList2List;
		multi_set<User> UsersSet2MultiSet;
		multi_set<User> UsersList2MultiSet;
		multi_set<User> UsersMultiSet2MultiSet;
		multi_set<User> UsersMultiList2MultiSet;
		multi_list<User> UsersSet2MultiList;
		multi_list<User> UsersList2MultiList;
		multi_list<User> UsersMultiSet2MultiList;
		multi_list<User> UsersMultiList2MultiList;
	}

	association User.RolesSet2Set with Role.UsersSet2Set;
	association User.RolesList2Set with Role.UsersList2Set;
	association User.RolesMultiSet2Set with Role.UsersMultiSet2Set;
	association User.RolesMultiList2Set with Role.UsersMultiList2Set;
	association User.RolesSet2List with Role.UsersSet2List;
	association User.RolesList2List with Role.UsersList2List;
	association User.RolesMultiSet2List with Role.UsersMultiSet2List;
	association User.RolesMultiList2List with Role.UsersMultiList2List;
	association User.RolesSet2MultiSet with Role.UsersSet2MultiSet;
	association User.RolesList2MultiSet with Role.UsersList2MultiSet;
	association User.RolesMultiSet2MultiSet with Role.UsersMultiSet2MultiSet;
	association User.RolesMultiList2MultiSet with Role.UsersMultiList2MultiSet;
	association User.RolesSet2MultiList with Role.UsersSet2MultiList;
	association User.RolesList2MultiList with Role.UsersList2MultiList;
	association User.RolesMultiSet2MultiList with Role.UsersMultiSet2MultiList;
	association User.RolesMultiList2MultiList with Role.UsersMultiList2MultiList;

	class BaseClass
	{
	}

	class DerivedClass : BaseClass
	{
	}


	class RedefinitionBase2Derived
	{
		BaseClass Single2SingleBase;
		BaseClass Single2SetBase;
		BaseClass Single2ListBase;
		BaseClass Single2MultiSetBase;
		BaseClass Single2MultiListBase;
		set<BaseClass> Set2SingleBase;
		set<BaseClass> Set2SetBase;
		set<BaseClass> Set2ListBase;
		set<BaseClass> Set2MultiSetBase;
		set<BaseClass> Set2MultiListBase;
		list<BaseClass> List2SingleBase;
		list<BaseClass> List2SetBase;
		list<BaseClass> List2ListBase;
		list<BaseClass> List2MultiSetBase;
		list<BaseClass> List2MultiListBase;
		multi_set<BaseClass> MultiSet2SingleBase;
		multi_set<BaseClass> MultiSet2SetBase;
		multi_set<BaseClass> MultiSet2ListBase;
		multi_set<BaseClass> MultiSet2MultiSetBase;
		multi_set<BaseClass> MultiSet2MultiListBase;
		multi_list<BaseClass> MultiList2SingleBase;
		multi_list<BaseClass> MultiList2SetBase;
		multi_list<BaseClass> MultiList2ListBase;
		multi_list<BaseClass> MultiList2MultiSetBase;
		multi_list<BaseClass> MultiList2MultiListBase;
		DerivedClass Single2SingleDerived redefines Single2SingleBase;
		set<DerivedClass> Single2SetDerived redefines Single2SetBase;
		list<DerivedClass> Single2ListDerived redefines Single2ListBase;
		multi_set<DerivedClass> Single2MultiSetDerived redefines Single2MultiSetBase;
		multi_list<DerivedClass> Single2MultiListDerived redefines Single2MultiListBase;
		DerivedClass Set2SingleDerived redefines Set2SingleBase;
		set<DerivedClass> Set2SetDerived redefines Set2SetBase;
		list<DerivedClass> Set2ListDerived redefines Set2ListBase;
		multi_set<DerivedClass> Set2MultiSetDerived redefines Set2MultiSetBase;
		multi_list<DerivedClass> Set2MultiListDerived redefines Set2MultiListBase;
		DerivedClass List2SingleDerived redefines List2SingleBase;
		set<DerivedClass> List2SetDerived redefines List2SetBase;
		list<DerivedClass> List2ListDerived redefines List2ListBase;
		multi_set<DerivedClass> List2MultiSetDerived redefines List2MultiSetBase;
		multi_list<DerivedClass> List2MultiListDerived redefines List2MultiListBase;
		DerivedClass MultiSet2SingleDerived redefines MultiSet2SingleBase;
		set<DerivedClass> MultiSet2SetDerived redefines MultiSet2SetBase;
		list<DerivedClass> MultiSet2ListDerived redefines MultiSet2ListBase;
		multi_set<DerivedClass> MultiSet2MultiSetDerived redefines MultiSet2MultiSetBase;
		multi_list<DerivedClass> MultiSet2MultiListDerived redefines MultiSet2MultiListBase;
		DerivedClass MultiList2SingleDerived redefines MultiList2SingleBase;
		set<DerivedClass> MultiList2SetDerived redefines MultiList2SetBase;
		list<DerivedClass> MultiList2ListDerived redefines MultiList2ListBase;
		multi_set<DerivedClass> MultiList2MultiSetDerived redefines MultiList2MultiSetBase;
		multi_list<DerivedClass> MultiList2MultiListDerived redefines MultiList2MultiListBase;
	}

	class RedefinitionDerived2Base
	{
		DerivedClass Single2SingleBase;
		DerivedClass Single2SetBase;
		DerivedClass Single2ListBase;
		DerivedClass Single2MultiSetBase;
		DerivedClass Single2MultiListBase;
		set<DerivedClass> Set2SingleBase;
		set<DerivedClass> Set2SetBase;
		set<DerivedClass> Set2ListBase;
		set<DerivedClass> Set2MultiSetBase;
		set<DerivedClass> Set2MultiListBase;
		list<DerivedClass> List2SingleBase;
		list<DerivedClass> List2SetBase;
		list<DerivedClass> List2ListBase;
		list<DerivedClass> List2MultiSetBase;
		list<DerivedClass> List2MultiListBase;
		multi_set<DerivedClass> MultiSet2SingleBase;
		multi_set<DerivedClass> MultiSet2SetBase;
		multi_set<DerivedClass> MultiSet2ListBase;
		multi_set<DerivedClass> MultiSet2MultiSetBase;
		multi_set<DerivedClass> MultiSet2MultiListBase;
		multi_list<DerivedClass> MultiList2SingleBase;
		multi_list<DerivedClass> MultiList2SetBase;
		multi_list<DerivedClass> MultiList2ListBase;
		multi_list<DerivedClass> MultiList2MultiSetBase;
		multi_list<DerivedClass> MultiList2MultiListBase;
		BaseClass Single2SingleDerived redefines Single2SingleBase;
		set<BaseClass> Single2SetDerived redefines Single2SetBase;
		list<BaseClass> Single2ListDerived redefines Single2ListBase;
		multi_set<BaseClass> Single2MultiSetDerived redefines Single2MultiSetBase;
		multi_list<BaseClass> Single2MultiListDerived redefines Single2MultiListBase;
		BaseClass Set2SingleDerived redefines Set2SingleBase;
		set<BaseClass> Set2SetDerived redefines Set2SetBase;
		list<BaseClass> Set2ListDerived redefines Set2ListBase;
		multi_set<BaseClass> Set2MultiSetDerived redefines Set2MultiSetBase;
		multi_list<BaseClass> Set2MultiListDerived redefines Set2MultiListBase;
		BaseClass List2SingleDerived redefines List2SingleBase;
		set<BaseClass> List2SetDerived redefines List2SetBase;
		list<BaseClass> List2ListDerived redefines List2ListBase;
		multi_set<BaseClass> List2MultiSetDerived redefines List2MultiSetBase;
		multi_list<BaseClass> List2MultiListDerived redefines List2MultiListBase;
		BaseClass MultiSet2SingleDerived redefines MultiSet2SingleBase;
		set<BaseClass> MultiSet2SetDerived redefines MultiSet2SetBase;
		list<BaseClass> MultiSet2ListDerived redefines MultiSet2ListBase;
		multi_set<BaseClass> MultiSet2MultiSetDerived redefines MultiSet2MultiSetBase;
		multi_list<BaseClass> MultiSet2MultiListDerived redefines MultiSet2MultiListBase;
		BaseClass MultiList2SingleDerived redefines MultiList2SingleBase;
		set<BaseClass> MultiList2SetDerived redefines MultiList2SetBase;
		list<BaseClass> MultiList2ListDerived redefines MultiList2ListBase;
		multi_set<BaseClass> MultiList2MultiSetDerived redefines MultiList2MultiSetBase;
		multi_list<BaseClass> MultiList2MultiListDerived redefines MultiList2MultiListBase;
	}

	class SubsettingBase2Derived
	{
		BaseClass Single2SingleBase;
		BaseClass Single2SetBase;
		BaseClass Single2ListBase;
		set<BaseClass> Set2SingleBase;
		set<BaseClass> Set2SetBase;
		set<BaseClass> Set2ListBase;
		list<BaseClass> List2SingleBase;
		list<BaseClass> List2SetBase;
		list<BaseClass> List2ListBase;
		DerivedClass Single2SingleDerived subsets Single2SingleBase;
		set<DerivedClass> Single2SetDerived subsets Single2SetBase;
		list<DerivedClass> Single2ListDerived subsets Single2ListBase;
		DerivedClass Set2SingleDerived subsets Set2SingleBase;
		set<DerivedClass> Set2SetDerived subsets Set2SetBase;
		list<DerivedClass> Set2ListDerived subsets Set2ListBase;
		DerivedClass List2SingleDerived subsets List2SingleBase;
		set<DerivedClass> List2SetDerived subsets List2SetBase;
		list<DerivedClass> List2ListDerived subsets List2ListBase;
	}

	class SubsettingDerived2Base
	{
		DerivedClass Single2SingleBase;
		DerivedClass Single2SetBase;
		DerivedClass Single2ListBase;
		set<DerivedClass> Set2SingleBase;
		set<DerivedClass> Set2SetBase;
		set<DerivedClass> Set2ListBase;
		list<DerivedClass> List2SingleBase;
		list<DerivedClass> List2SetBase;
		list<DerivedClass> List2ListBase;
		BaseClass Single2SingleDerived subsets Single2SingleBase;
		set<BaseClass> Single2SetDerived subsets Single2SetBase;
		list<BaseClass> Single2ListDerived subsets Single2ListBase;
		BaseClass Set2SingleDerived subsets Set2SingleBase;
		set<BaseClass> Set2SetDerived subsets Set2SetBase;
		list<BaseClass> Set2ListDerived subsets Set2ListBase;
		BaseClass List2SingleDerived subsets List2SingleBase;
		set<BaseClass> List2SetDerived subsets List2SetBase;
		list<BaseClass> List2ListDerived subsets List2ListBase;
	}

}
