using PracticeWork2.Cli.Command;
using PracticeWork2.University;

namespace PracticeWork2.Cli;

public sealed class UniversityCli(
	IUniversity university
) {
	private Commands _commands = new([
		Add.Command,
		FindBy.Command,
		List.Command,
		Remove.Command
	]);

	public void Run() {
		while(true) {
			Console.WriteLine();
			Console.WriteLine("Enter command ('help' to get more information)");
			Console.Write("> ");

			var input = Console.ReadLine();
			if (input is null) return;
			var command = input.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
			if (command.Length == 0) return;
			_commands.Execute(command, university);
		}
	}
}
