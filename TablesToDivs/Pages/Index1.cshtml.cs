using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spectre.Console;
using TablesToDivs.Models;

namespace TablesToDivs.Pages
{
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
        }

        [TempData]
        public string PersonName { get; set; }

        public void OnPost(Person person)
        {
            PersonName = $"Name: {person.FirstName} {person.LastName}";
            ViewData["JavaScript"] = "window.location = '" + Url.Page("Index1") + "'";
            AnsiConsole.MarkupLine($"[{Color.Pink3}]{person.FirstName} {person.LastName}[/]");
        }

    }
}
