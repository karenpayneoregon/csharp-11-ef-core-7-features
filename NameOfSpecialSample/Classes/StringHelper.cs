using System.Linq.Expressions;

namespace NameOfSpecialSample.Classes;

    internal static class StringHelper
    {
     
        public static string NameOf<T>(Expression<Func<T>> pathExpression, bool removeParent = true)
        {
            var members = new Stack<string>();
            for (var memberExpression = pathExpression.Body as MemberExpression; memberExpression != null; memberExpression = memberExpression.Expression as MemberExpression)
            {
                members.Push(memberExpression.Member.Name);
            }

            if (!removeParent) return FirstCharToUpper(string.Join(".", members));
            members.Pop();
            return string.Join(".", members);

        }

        public static string NameOf<T>(Expression<Func<T, object>> sender, bool removeParent = true)
        {
            return removeParent
                ? string.Join(".", sender.ToString().Split('.').Skip(1))
                : typeof(T).Name + "." + string.Join(".", sender.ToString().Split('.').Skip(1));
        }

    
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
    }

