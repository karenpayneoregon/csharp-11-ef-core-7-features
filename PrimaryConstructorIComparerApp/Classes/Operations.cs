using PrimaryConstructorIComparerApp.Models;

namespace PrimaryConstructorIComparerApp.Classes;
internal class Operations
{
    /// <summary>
    /// Retrieves a list of predefined students.
    /// </summary>
    /// <returns>A list of <see cref="Student"/> objects, each representing a student with their respective details.</returns>
    public static List<Student> Students()
    {
        List<Student> list = [];
        list.AddRange(
        [
            new Student(1,"Tim","Smith",98),
            new Student(2,"Mary","Adams",71),
            new Student(3,"Jim","Jacobe",55)
        ]);

        return list;
    }
}
