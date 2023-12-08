using GenericMathLibrary;

namespace NaturalSortApp.Classes;
internal class BogusOperations
{

    /// <summary>
    /// Create a list of file names
    /// </summary>
    /// <param name="count">How many file names to return</param>
    public static List<string> FileNames(int count = 20)
    {
        var numberList = Enumerable.Range(0, 100).Select(x => x).ToArray();
        List<string> list = new List<string>();

        for (int index = 0; index < count; index++)
        {
            Random.Shared.Shuffle<int>(numberList);
            var dataSet = new Bogus.DataSets.System();

            list.Add(index.IsEven()
                ? $"{numberList.First()}{dataSet.FileName()}.{dataSet.FileExt()}"
                : $"{dataSet.FileName()} {numberList.First()}.{dataSet.FileExt()}");
        }

        return list;
;
    }
}
