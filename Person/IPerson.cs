namespace PracticeWork2.Person;

public interface IPerson {
	const string DefaultBirthDateFormat = "MM-dd-yyyy";
	const string DefaultFloatFormat = "E4";

	string LastName { get; }
	string Name { get; }
	string Patronimic { get; }
	DateTime BirthDate { get; }
	int Age => CalculateAge(DateTime.Today);

	sealed int CalculateAge(DateTime when) {
		if (when < BirthDate)
			return 0;

		int age = when.Year - BirthDate.Year;
		if (BirthDate.Date > when.AddYears(-age)) age--;
		return age;
	}
}
