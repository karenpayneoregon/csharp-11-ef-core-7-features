using KeyedServiceProject1.Classes;
using KeyedServiceProject1.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace KeyedServiceProject1.Pages;
public class IndexModel : PageModel
{
    public async void OnGet([FromKeyedServices(ServiceKeys.FirstDemo)] INotificationService notificationService)
    {
        try
        {
            var message = await notificationService.NotifyAsync("First Service call");
            if (message != null) Log.Information(message);
        }
        catch (Exception e)
        {
            Log.Error(e,$"Error occurred while notifying using {nameof(ServiceKeys.FirstDemo)}");
        }
    }
}

