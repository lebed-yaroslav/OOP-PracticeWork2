using PracticeWork2.Cli;
using PracticeWork2.University;

var university = new University();
var cli = new UniversityCli(university);
cli.Run();
