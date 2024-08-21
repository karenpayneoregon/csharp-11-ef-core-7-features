using System.Linq.Expressions;

namespace ExpressionTreesApp.Classes;
internal static class Extensions
{
    public static int ToInt(this Expression input) => Convert.ToInt32(input.ToString());
}
