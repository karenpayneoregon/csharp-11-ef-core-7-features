using Microsoft.EntityFrameworkCore;
using TableSplittingSample.Classes;

namespace TableSplittingSample
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            await ModelBuildingSample.Entity_splitting();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}