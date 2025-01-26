using System.Collections.ObjectModel;
using System.Linq.Expressions;
using static ExpressionTreesApp.Classes.SpectreConsoleHelpers;

namespace ExpressionTreesApp.Classes;
internal static class Helpers
{
    /// <summary>
    /// Displays the properties and their values of an object created from the provided expression.
    /// </summary>
    /// <typeparam name="T">The type of the object represented by the expression.</typeparam>
    /// <param name="expression">
    /// An expression that represents a function returning an object of type <typeparamref name="T"/>.
    /// </param>
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
    /// <summary>
    /// Displays the member assignments and their values from an object initialization expression.
    /// </summary>
    /// <typeparam name="T">The type of the object being initialized in the expression.</typeparam>
    /// <param name="expression">
    /// An expression that represents an object initialization of type <typeparamref name="T"/>.
    /// </param>
    /// <remarks>
    /// This method processes the <see cref="MemberInitExpression"/> to extract and display
    /// the member assignments, including their types and values. Special handling is provided
    /// for <c>DateOnly</c> and <c>String</c> types.
    /// </remarks>
    public static void ViewFromCreation<T>(Expression<Func<T>> expression)
    {
        PrintCyan();

        if (expression.Body is not MemberInitExpression exp) return;

        foreach (MemberBinding mb in exp.Bindings)
        {
            if (mb is not MemberAssignment ma) continue;
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

    private static string RemoveQuotes(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        if (input.Length >= 2 && input[0] == '"' && input[^1] == '"')
            return input.Substring(1, input.Length - 2);

        return input;
    }
}
