namespace Entities.Samples.HusbandWife
{
	entity NamedEntity
	{
		string Name;
	}
}
namespace Entities
{
	namespace Samples.HusbandWife
	{
		entity Husband : NamedEntity
		{
			Wife Wife;
		}
	}
}
namespace Entities
{
	namespace Samples
	{
		namespace HusbandWife
		{
			entity Wife : NamedEntity
			{
				Husband Husband;
			}

			association Husband.Wife with Wife.Husband;
		}
	}
}
