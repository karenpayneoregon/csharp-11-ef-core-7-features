using Dumpify;
using DumpifySample.Data;
using Microsoft.EntityFrameworkCore;
using static DumpifySample.Classes.SpectreConsoleHelpers;
using Color = System.Drawing.Color;

namespace DumpifySample;

internal partial class Program
{
    static void Main(string[] args)
    {
        
        DumpConfig.Default.ColorConfig.TypeNameColor = new DumpColor(Color.Aqua);
        DumpConfig.Default.ColorConfig.NullValueColor = new DumpColor(Color.Red);
        using var context = new Context();
        var category = context.Categories
            .Include(x => x.Products)
            .ThenInclude(x => x.OrderDetails.Take(1))
            .FirstOrDefault(c => c.CategoryID == 2);

        category.Dump();
        ExitPrompt();
        

    }
}
