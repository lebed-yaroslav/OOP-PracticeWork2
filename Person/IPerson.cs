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

	public sealed class LastNameComparer : IComparer<IPerson> {
		public static readonly LastNameComparer Instance = new();

		private LastNameComparer() {}

		public int Compare(IPerson? x, IPerson? y) {
			if (ReferenceEquals(x, y)) return 0;
			if (x == null) return -1;
			if (y == null) return 1;
			var result = x.LastName.CompareTo(y.LastName);
			if (result != 0) return result;
			result = x.Name.CompareTo(y.Name);
			if (result != 0) return result;
			result = x.Patronimic.CompareTo(y.Patronimic);
			if (result != 0) return result;
			return x.BirthDate.CompareTo(y.BirthDate);
		}
	}
}
