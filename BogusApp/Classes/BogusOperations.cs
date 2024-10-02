using BogusApp.DataSets;
using BogusApp.Models;

namespace BogusApp.Classes;

internal class BogusOperations
{
    public static List<FileContainer> Items(int count = 10)
    {
        return Folders.File().Generate(count);
    }
}