using PracticeWork2.University;

namespace PracticeWork2.Cli.Command; 

public delegate void Command(string[] args, IUniversity university);

public sealed record CommandEntry(
	string Name,
	string[] Arguments,
	Command Command
) {
	public int ArgumentCount => Arguments.Length;
	public string Usage => $"{Name} {string.Join(' ', Arguments)}";
}

public static class CommandExtensions {
	public static void ValidateArgumentCount(this CommandEntry command, string[] args) {
		int argumentCount = args.Length - 1;
		if (argumentCount < command.ArgumentCount)
			throw new MissingArgumentsException(command.Arguments.Skip(argumentCount));
	}
}

public sealed class Commands {
	private Dictionary<string, CommandEntry> _entries = new();

	public Commands() {}

	public Commands(IEnumerable<CommandEntry> commands) {
		RegisterAll(commands);
	}

	public void Register(CommandEntry command)
		=> _entries.Add(command.Name, command);

	public void RegisterAll(IEnumerable<CommandEntry> commands) {
		foreach (var command in commands)
			Register(command);
	}

	public void Execute(string[] args, IUniversity university) {
		if (args[0] == "help") {
			ShowHelp();
			return;
		}
		try {
			_entries[args[0]].Command.Invoke(args, university);
		}
		catch (KeyNotFoundException) {
			Console.WriteLine($"Unknown command: '{args[0]}'. Enter 'help' to see available commands.");
		}
		catch (Exception ex) {
			Console.WriteLine($"Error: {ex.Message}");
		}
	}

	public void ShowHelp() {
		foreach (var entry in _entries.Values)
			Console.WriteLine(entry.Usage);
	}
}
