using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorHasData.Classes;
using RazorHasData.Data;
using RazorHasData.Models;
using Serilog;

namespace RazorHasData.Pages;
public class IndexModel(Context context) : PageModel
{
    private readonly Context _context = context;
    public List<ProductGroup> GroupedProducts { get; set; } = new();
    public async Task OnGet()
    {
        await MockedData.CreateIfNeeded(_context);

        var products = _context
            .Products
            .Include(x => x.Category)
            .ToList();

        GroupedProducts = products
            .GroupBy(p => p.Category)
            .Select(group => 
                new ProductGroup(group.Key, group.OrderBy(x => x.Name).ToList()))
            .OrderBy(x => x.Category.Name)
            .ToList();
    }
}