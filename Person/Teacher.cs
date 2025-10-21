using PracticeWork2.Cli.Command;
using System.Reflection;

namespace PracticeWork2.Person;

public sealed class Teacher(
	PersonData personData,
	string department,
	uint workExpirience,
	TeacherPosition position
) : IPerson {
	static readonly string[] Fields = typeof(Teacher)
		.GetPublicPropertyNames()
		.ToArray();

	// Immutable Person data
	public string LastName => personData.LastName;
	public string Name => personData.Name;
	public string Patronimic => personData.Patronimic;
	public DateTime BirthDate => personData.BirthDate;

	// Mutable Teacher specific fields
	public string Department { get; set; } = department;
	public uint WorkExpirience { get; set; } = workExpirience;
	public TeacherPosition Position { get; set; } = position;


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
		=> $"{personData},{Department},{WorkExpirience},{Position}";
}

public enum TeacherPosition {
	Assistant,
	Teacher,
	SeniorLecturer,
	Lector,
	Docent,
	Professor
}
