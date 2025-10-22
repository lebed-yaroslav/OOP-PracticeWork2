using PracticeWork2.Person;
using PracticeWork2.University;

namespace PracticeWork2.Cli.Command;


public static class Add {
	public static readonly CommandEntry Command = new(
		Name: "add",
		Arguments: ["<student|teacher|students|teachers>", "<serialized_person|filename>"],
		Command: Execute
	);

	private static void Execute(string[] args, IUniversity university) {
		Command.ValidateArgumentCount(args);

		IEnumerable<IPerson> persons;
		try {
			persons = args[1] switch {
				"student" => [Student.Parse(args[2])],
				"teacher" => [Teacher.Parse(args[2])],
				"students" => File.ReadAllLines(args[2]).Select(Student.Parse),
				"teachers" => File.ReadAllLines(args[2]).Select(Teacher.Parse),
				_ => throw new InvalidArgumentException(args[1], "Must be one of: student, teacher, students, teachers.")
			};
		}
		catch (FormatException ex) {
			Console.WriteLine($"Invalid format: {ex.Message}");
			return;
		}

		foreach (var person in persons)
			university.Add(person);
	}
}
