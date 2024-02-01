#nullable enable
#pragma warning disable CS8602 // Dereference of a possibly null reference.
using PrimaryConstructorIComparerApp.Models;

namespace PrimaryConstructorIComparerApp.Comparers;

public class StudentGradeComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x.Grade > y.Grade)
        {
            return 1;
        }
        else if (x.Grade < y.Grade)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}