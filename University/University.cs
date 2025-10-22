using PracticeWork2.Person;

namespace PracticeWork2.University;

public sealed class University : IUniversity {
	// Performance can be improved using SotedList<string, List<IPerson>>
	public IEnumerable<IPerson> Persons => _persons.OrderBy(p => p.LastName);
	public IEnumerable<Student> Students => _students.OrderBy(p => p.LastName);
	public IEnumerable<Teacher> Teachers => _teachers.OrderBy(p => p.LastName);

	private readonly List<IPerson> _persons = new();
	private readonly List<Student> _students = new();
	private readonly List<Teacher> _teachers = new();

	// O(1) in regular case, O(n) in worst case scenario
	public void Add(IPerson person) {
		_persons.Add(person);
		if (person is Student student) _students.Add(student);
		else if (person is Teacher teacher) _teachers.Add(teacher);
	}

	public IEnumerable<Student> FindByAveragePoint(float greaterThan)
		=> Students.Where(s => s.AveragePoint >= greaterThan);

	public IEnumerable<Teacher> FindByDepartment(string department)
		=> Teachers.Where(t => t.Department == department);

	public IEnumerable<IPerson> FindByLastName(string lastName)
		=> _persons.Where(s => s.LastName == lastName);

	// O(n) complexity, can be improved with lookup cost
	public void Remove(IPerson person) {
		if (_persons.Remove(person)) {
			if (person is Student student) _students.Remove(student);
			else if (person is Teacher teacher) _teachers.Remove(teacher);
		}
	}
}
