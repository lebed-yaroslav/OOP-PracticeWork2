using PracticeWork2.Person;
using PracticeWork2.University;


namespace PracticeWork2.Cli.Command;

public static class Remove {
	public static readonly CommandEntry Command = new(
		Name: "remove",
		Arguments: ["<last_name>"],
		Command: Execute
	);

	private static void Execute(string[] args, IUniversity university) {
		Command.ValidateArgumentCount(args);

		var toRemove = university
			.FindByLastName(args[1])
			.Index();

		Console.WriteLine("Found entries:");
		CommandUtils.ShowPaged(toRemove);

		Console.WriteLine("Enter index of entry to delete, or leave blank to cancel remove");
		Console.Write("i > ");

		if (int.TryParse(Console.ReadLine(), out int k)) {
			var person = toRemove.ElementAtOrDefault(k).Item;
			if (person is null) {
				Console.WriteLine($"{k} is out of range");
				return;
			}

			university.Remove(person);
			Console.WriteLine($"Removed: {person}");
		}
		else {
			Console.WriteLine("No entries removed");
		}
	}
}
