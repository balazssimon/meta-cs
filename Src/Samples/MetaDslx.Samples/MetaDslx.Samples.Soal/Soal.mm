namespace MetaDslx.Samples.Soal
{
	metamodel Soal(Uri="http://MetaDslx.Samples.Soal/1.0");
	
	class Class
	{
		string Name;
		list<Operation> Operations;
	}

	class Operation
	{
		string Name;
	}
}
