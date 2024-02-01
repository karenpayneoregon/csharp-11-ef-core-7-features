using PrimaryConstructorIComparerApp.Models;

namespace PrimaryConstructorIComparerApp.Classes;
internal class Operations
{
    public static List<Student> Students()
    {
        List<Student> list = [];
        list.AddRange(new []
        {
            new Student("Tim","Smith",98),
            new Student("Mary","Adams",71),
            new Student("Jim","Jacobe",55)
        });

        return list;
    }
}
