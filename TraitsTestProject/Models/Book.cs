#nullable disable
using System.ComponentModel.DataAnnotations;
using TraitsTestLibrary.Classes;
// ReSharper disable InconsistentNaming

namespace TraitsTestProject.Models;
public class Book
{
    [Required(ErrorMessage = "{0} is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public string ISBN { get; set; }

    [RequiredEnum(ErrorMessage = "{0} is required")]
    public BookCategory? Category { get; set; }

    [ListHasElements(ErrorMessage = "{0} must contain at least one note")]
    public List<string> NotesList { get; set; }

}