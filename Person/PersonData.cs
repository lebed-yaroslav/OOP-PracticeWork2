using System.Globalization;

namespace PracticeWork2.Person;

/// <summary>
/// Immutable data of person.
/// Should be composed into IPerson derived classes.
/// </summary>
public record PersonData(
	string LastName,
	string Name,
	string Patronimic,
	DateTime BirthDate
) : IPerson {
	static readonly string[] Fields = typeof(PersonData)
		.GetPublicPropertyNames()
		.ToArray();

	public static PersonData Parse(string s)
		=> Parse(s.Split(',', StringSplitOptions.TrimEntries));

	public static PersonData Parse(ReadOnlySpan<string> s) {
		if (s.Length < Fields.Length)
			throw new MissingArgumentsException(Fields.Skip(s.Length));

		return new PersonData(
			LastName: s[0],
			Name: s[1],
			Patronimic: s[2],
			BirthDate: DateTime.ParseExact(
				s[3], 
				IPerson.DefaultBirthDateFormat, 
				CultureInfo.InvariantCulture
			)
		);
	}

	public override string ToString()
		=> $"{LastName},{Name},{Patronimic},{BirthDate.ToString(IPerson.DefaultBirthDateFormat)}";
}
