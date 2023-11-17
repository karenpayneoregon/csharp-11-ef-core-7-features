using Microsoft.EntityFrameworkCore;
using NorthWind2023Library.Data;
using NorthWind2023Library.Models;

namespace NorthWind2023App.Classes;
internal class NorthOperations
{
    public static async Task<Orders> GetOrder(int orderIdentifier)
    {
        await using var context = new Context();
        return await context.Orders
            .Include(o => o.Employee)
            .Include(o => o.ShipViaNavigation)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ThenInclude(p => p.Category)
            .FirstOrDefaultAsync(o => o.OrderID == orderIdentifier);
    }
}
