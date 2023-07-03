using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretManager1.Models;
#pragma warning disable CS8618

namespace SecretManager1.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public string ConnectionString { get; set; }
    private IConfiguration _configuration;
    [BindProperty]
    public MailSettings MailSettings { get; set; }
    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnGet()
    {
        ConnectionString = _configuration["ConnectionStrings:DefaultConnection"]!;
        MailSettings = _configuration.GetSection("MailSettings").Get<MailSettings>()!;
    }
}
