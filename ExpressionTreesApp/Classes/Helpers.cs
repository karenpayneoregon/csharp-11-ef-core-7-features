using System.Collections.ObjectModel;
using System.Linq.Expressions;
using static ExpressionTreesApp.Classes.SpectreConsoleHelpers;

namespace ExpressionTreesApp.Classes;
internal static class Helpers
{
    public static void ViewAfter<T>(Expression<Func<T>> expression)
    {
        PrintCyan();

        if (expression.Body is not MemberExpression) return;
        var compiled = expression.Compile();
        T container = compiled();

        foreach (var prop in container!.GetType().GetProperties())
        {
            var value = prop.GetValue(container);
            Console.WriteLine($"{prop.Name,-12}: {value}");
        }
    }
    public static void ViewFromCreation<T>(Expression<Func<T>> expression)
    {
        PrintCyan();

        if (expression.Body is not MemberInitExpression exp) return;

        foreach (MemberBinding mb in exp.Bindings)
        {
            if (mb is MemberAssignment ma)
            {
                if (ma.Expression.Type.Name == "DateOnly")
                {

                    if (ma.Expression is not NewExpression newExpression) continue;

                    ReadOnlyCollection<Expression> dateParts = newExpression.Arguments;

                    var year = dateParts[0].ToInt();
                    var month = dateParts[1].ToInt();
                    var day = dateParts[2].ToInt();

                    Console.WriteLine($"{ma.Member.Name,-12} = " +
                                      $"{new DateOnly(year, month, day),-12} " +
                                      $"{ma.Expression.Type.Name} -> {ma.Expression}");
                }
                else if (ma.Expression.Type.Name == "String")
                {
                    string expressionString = ma.Expression.ToString().RemoveQuotes();
                    Console.WriteLine($"{ma.Member.Name,-12} = {expressionString,-12} {ma.Expression.Type.Name} ");
                }
                else
                {
                    Console.WriteLine($"{ma.Member.Name,-12} = {ma.Expression,-12} {ma.Expression.Type.Name} ");
                }
            }
        }
    }

    private static string RemoveQuotes(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        if (input.Length >= 2 && input[0] == '"' && input[^1] == '"')
            return input.Substring(1, input.Length - 2);

        return input;
    }
}
