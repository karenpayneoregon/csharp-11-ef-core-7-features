using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using PeriodicTimerWebApp.Classes;
using PeriodicTimerWebApp.Models;
using Serilog;

namespace PeriodicTimerWebApp.Pages;
public class IndexModel : PageModel
{
    
    [BindProperty]
    public Contacts Contacts { get; set; } = new Contacts();
    private TimerOperations _timerOperations;
    public IOptions<ConnectionOptions> Options { get; }
    public IndexModel(TimerOperations timerOperations, IOptions<ConnectionOptions> options)
    {
        _timerOperations = timerOperations;
        Options = options;
        _timerOperations.ConnectionString = Options.Value.NorthWindConnection;
        _timerOperations.OnShowContactHandler += ShowContact;
    }

    private void ShowContact(Contacts sender)
    {
        Contacts = sender;
        
    }

    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
