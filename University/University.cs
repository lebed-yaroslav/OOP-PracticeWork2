using PracticeWork2.Person;

namespace PracticeWork2.University;

public sealed class University : IUniversity {
	public IEnumerable<IPerson> Persons => _persons;
	// O(n) complexity, can be improved with memory cost
	public IEnumerable<Student> Students => _persons.OfType<Student>();
	// O(n) complexity, can be improved with memory cost
	public IEnumerable<Teacher> Teachers => _persons.OfType<Teacher>();

	private readonly SortedSet<IPerson> _persons = new(IPerson.LastNameComparer.Instance);

	public void Add(IPerson person)
		=> _persons.Add(person);

	public IEnumerable<Student> FindByAveragePoint(float greaterThan)
		=> Students.Where(s => s.AveragePoint >= greaterThan);

	public IEnumerable<Teacher> FindByDepartment(string department)
		=> Teachers.Where(t => t.Department == department);

	public IEnumerable<IPerson> FindByLastName(string lastName)
		=> _persons.Where(s => s.LastName == lastName);

	public void Remove(IPerson person)
		=> _persons.Remove(person);
}
