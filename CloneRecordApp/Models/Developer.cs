using CloneRecordApp.Interfaces;

namespace CloneRecordApp.Models;

public record Developer : Person, IDeveloper
{
    public string MainLanguage { get; set; }
}