using PeriodicTimerWebApp.Models;
using Serilog;

namespace PeriodicTimerWebApp.Classes;

public class EmailOperations
{
    public static void SendEmail(Contacts contacts)
    {
        // Send fake email
        string message = 
            $"""
                          
             Hello {contacts.FirstName} {contacts.LastName},

             This is a test email from the Periodic Timer Web App.
             Best regards,
              
             The Periodic Timer Web App Team
             """ ;

        Log.Information("{Message}", message);
    }
}
