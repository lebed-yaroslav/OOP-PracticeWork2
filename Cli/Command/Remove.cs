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
			.ToArray();

		Console.WriteLine("Found entries:");
		for (int i = 0; i < toRemove.Length; i++)
			Console.WriteLine($"{i}. {toRemove[i]}");

		Console.WriteLine("Enter index of entry to delete, or leave blank to cancel remove");
		Console.Write("i > ");

		if (int.TryParse(Console.ReadLine(), out int k)) {
			if (k < 0 || k >= toRemove.Length) {
				Console.WriteLine($"{k} is out of range");
				return;
			}

			var person = toRemove[k];
			university.Remove(person);
			Console.WriteLine($"Removed: {person}");
		}
		else {
			Console.WriteLine("No entries removed");
		}
	}
}
