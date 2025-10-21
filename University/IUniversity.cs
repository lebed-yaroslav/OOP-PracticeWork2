using PracticeWork2.Person;

namespace PracticeWork2.University; 

public interface IUniversity {
	IEnumerable<IPerson> Persons { get; }
	IEnumerable<Student> Students { get; }
	IEnumerable<Teacher> Teachers {  get; }

	void Add(IPerson person);
	void Remove(IPerson person);

	IEnumerable<IPerson> FindByLastName(string lastName);
	IEnumerable<Student> FindByAveragePoint(float greaterThan);
	IEnumerable<Teacher> FindByDepartment(string department);
}
