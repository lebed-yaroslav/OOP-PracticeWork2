namespace PracticeWork2.Person;


public sealed class Student(
	PersonData personData,
	uint year,
	string group,
	float averagePoint
) : IPerson {
	static readonly string[] Fields = typeof(Student)
		.GetPublicPropertyNames()
		.ToArray();

	// Immutable Person data
	public string LastName => personData.LastName;
	public string Name => personData.Name;
	public string Patronimic => personData.Patronimic;
	public DateTime BirthDate => personData.BirthDate;

	// Mutable Student-specific fields
	public uint Year { get; set; } = year;
	public string Group { get; set; } = group;
	public float AveragePoint { get; set; } = averagePoint;


	public static Student Parse(string s) {
		var fields = s.Split(',', StringSplitOptions.TrimEntries);
		if (fields.Length < Fields.Length)
			throw new MissingArgumentsException(Fields.Skip(fields.Length));

		return new Student(
			personData: PersonData.Parse(fields.AsSpan(0, 4)),
			year: uint.Parse(fields[4]),
			group: fields[5],
			averagePoint: float.Parse(fields[6])
		);
	}

	public override string ToString()
		=> $"{personData},{Year},{Group},{AveragePoint.ToString(IPerson.DefaultFloatFormat)}";
}
