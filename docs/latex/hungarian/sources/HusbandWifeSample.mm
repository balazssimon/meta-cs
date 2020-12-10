namespace Entities.Samples.HusbandWife
{
	entity NamedEntity
	{
		string Name;
	}
	
	entity Husband : NamedEntity
	{
		Wife Wife;
	}

	entity Wife : NamedEntity
	{
		Husband Husband;
	}

	association Husband.Wife with Wife.Husband;
}
