﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

namespace StringSyntaxWithEntityFrameworkCore.Models;

public partial class BirthDay
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    // computed column
    public int? YearsOld { get; set; }
}