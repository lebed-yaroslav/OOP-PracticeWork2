namespace PracticeWork2;

public class MissingArgumentsException : ArgumentException {
	public MissingArgumentsException(IEnumerable<string> arguments) :
		base($"Missing arguments: {string.Join(", ", arguments)}") { }
}

public class InvalidArgumentException : ArgumentException {
	public InvalidArgumentException(string argument, string details) :
		base($"Invalid argument: {argument}. {details}") { }
}
