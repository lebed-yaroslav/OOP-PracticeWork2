using PracticeWork2.Person;
using PracticeWork2.University;

namespace PracticeWork2.Cli.Command;


public static class Add {
	public static readonly CommandEntry Command = new(
		Name: "add",
		Arguments: ["<student|teacher>", "<serialized_person>"],
		Command: Execute
	);

	private static void Execute(string[] args, IUniversity university) {
		Command.ValidateArgumentCount(args);

		IPerson person;
		try {
			person = args[1] switch {
				"student" => Student.Parse(args[2]),
				"teacher" => Teacher.Parse(args[2]),
				_ => throw new InvalidArgumentException(args[1], "Must be one of: student, teacher.")
			};
		}
		catch (FormatException ex) {
			Console.WriteLine($"Invalid format: {ex.Message}");
			return;
		}

		university.Add(person);
	}
}
