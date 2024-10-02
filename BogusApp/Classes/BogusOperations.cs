using BogusApp.DataSets;
using BogusApp.Models;

namespace BogusApp.Classes;

internal class BogusOperations
{
    public static List<FileContainer> Items(int count = 10)
    {
        return FolderDataSet.File().Generate(count);
    }
}