using PracticeWork2.University;

namespace PracticeWork2.Cli.Command;


public static class List {
	public static readonly CommandEntry Command = new(
		Name: "list",
		Arguments: ["<persons|students|teachers>"],
		Command: Execute
	);

	private static void Execute(string[] args, IUniversity university) {
		Command.ValidateArgumentCount(args);

		var list = args[1] switch {
			"persons" => university.Persons,
			"students" => university.Students,
			"teachers" => university.Teachers,
			_ => throw new InvalidArgumentException(args[1], "Must be one of: persons, students, teachers.")
		};

		if (!list.Any()) {
			Console.WriteLine("empty");
			return;
		}

		CommandUtils.ShowPaged(list);
	}
}
