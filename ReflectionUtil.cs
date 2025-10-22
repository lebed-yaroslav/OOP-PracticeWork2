using System.Reflection;

namespace PracticeWork2;

public static class ReflectionUtil {
	public static IEnumerable<String> GetPublicPropertyNames(this Type type)
		=> type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name);
}
