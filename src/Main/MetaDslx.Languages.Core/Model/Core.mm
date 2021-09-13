namespace MetaDslx.Languages.Core.Model
{
	metamodel Core(Uri="http://MetaDslx.Languages.Core/1.0",MajorVersion=1,MinorVersion=0);

	class Element
	{
		list<Attribute> Attributes;
	}

	class Attribute
	{
	}

	class NamedElement : Element
	{
		string Name;
	}
}
