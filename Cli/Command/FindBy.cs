using PracticeWork2.University;

namespace PracticeWork2.Cli.Command;

public static class FindBy {
	public static readonly CommandEntry Command = new(
		Name: "findby",
		Arguments: ["<last_name|average_point|department>", "<value>"],
		Command: Execute
	);

	private static void Execute(string[] args, IUniversity university) {
		Command.ValidateArgumentCount(args);

		var result = args[1] switch {
			"last_name" => university.FindByLastName(args[2]),
			"average_point" => university.FindByAveragePoint(float.Parse(args[2])),
			"department" => university.FindByDepartment(args[2]),
			_ => throw new InvalidArgumentException(args[1], "Must be one of: last_name, average_point, department.")
		};

		if (!result.Any()) {
			Console.WriteLine("empty");
			return;
		}

		foreach (var item in result)
			Console.WriteLine(item);
	}
}
