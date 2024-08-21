using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TablesToDivs.Models;

namespace TablesToDivs.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {

    }

    [TempData]
    public string Name { get; set; }

    public void OnPost(Person person)
    {
        Name = $"Name: {person.FirstName} {person.LastName}";
        ViewData["JavaScript"] = "window.location = '" + Url.Page("Index") + "'";
    }
}
