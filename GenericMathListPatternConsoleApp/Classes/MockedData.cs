namespace GenericMathListPatternConsoleApp.Classes;
internal class MockedData
{
    public static string FileDataForIntegers()
    {
        var lines = 
            """
            Karen,Payne,1,2,3
            May,Jones,4,b,x
            Jack,Smith,6,7,c
            ,,56,76,9
            """;

        return lines;
    }

    public static string FileDataForDecimals()
    {
        var lines =
            """
            Karen,Payne,10.5,2.3,3.45
            May,Jones,4.33,b,x
            Jack,Smith,16.8,7.48,c
            ,,56.88,76.4,9.999
            """;

        return lines;
    }
}
