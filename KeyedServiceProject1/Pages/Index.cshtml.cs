using KeyedServiceProject1.Classes;
using KeyedServiceProject1.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace KeyedServiceProject1.Pages;
public class IndexModel : PageModel
{
    public async void OnGet([FromKeyedServices(ServiceKeys.First)] INotificationService notificationService)
    {
        var message = await notificationService.NotifyAsync("First Service call");
        Log.Information(message);
    }
}

