using System.Runtime.ExceptionServices;

namespace ExceptionDispatchInfoApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        var (lines, exceptionDispatchInfo) = ReadAllLines();
        exceptionDispatchInfo?.Throw();
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
        Console.ReadLine();
    }

    private static (string[] lines, ExceptionDispatchInfo exceptionDispatchInfo) ReadAllLines()
    {
        string[] lines = null;
        ExceptionDispatchInfo exceptionDispatchInfo = null;
        try
        {
            lines = File.ReadAllLines("NonExistingFile.txt");
        }
        catch (Exception localException)
        {
            exceptionDispatchInfo = ExceptionDispatchInfo.Capture(localException);
        }
        return (lines, exceptionDispatchInfo);
    }

    private static void HandleExceptionWithDispatchInfo()
    {
        void Toss() => throw new InvalidOperationException("Toss");

        Exception original = null;
        ExceptionDispatchInfo dispatchInfo = null;
        try
        {
            try
            {
                Toss();
            }
            catch (Exception ex)
            {
                original = ex;
                dispatchInfo = ExceptionDispatchInfo.Capture(ex);
                throw ex;
            }
        }
        catch (Exception ex2)
        {
            // ex2 is the same object as ex. But with a mutated StackTrace.
            Console.WriteLine(ex2 == original);  // True
        }

        // So now "original" has lost the StackTrace containing "Foo":
        Console.WriteLine(original.StackTrace.Contains("Toss"));  // False

        // But dispatchInfo still has it:
        try
        {
            dispatchInfo.Throw();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace.Contains("Toss"));   // True
        }
    }
}