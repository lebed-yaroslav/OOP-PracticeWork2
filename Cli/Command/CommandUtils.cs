namespace PracticeWork2.Cli.Command;

public static class CommandUtils {
	public const int DefaultPageSize = 10;

	public static void ShowPaged<T>(IEnumerable<T> items, int pageSize = DefaultPageSize) {
		int i = 0;
		foreach (var item in items) {
			if (i == pageSize) {
				Console.WriteLine("Enter to list next page or enter '.' to stop.");
				Console.Write("p > ");
				if (Console.ReadLine() == ".")
					return;
				i = -1;
			}
			Console.WriteLine(item);
			i++;
		}
	}
}
