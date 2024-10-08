﻿using PropertyChangedApp1.Classes;
using PropertyChangedApp1.Models;

namespace PropertyChangedApp1;

internal partial class Program
{
    static void Main(string[] args)
    {
        Customer customer = new()
        {
            FirstName = "John", 
            LastName = "Doe", 
            BirthDate = new DateOnly(1999, 1, 1)
        };
        
        customer.FirstName = "John";
        customer.FirstName = "Jane";

        var proper1 = "JAN".ProperCased();
        var proper2 = "jAn".ProperCased();
        var proper3 = "jan".ProperCased();

        Console.WriteLine($"{proper1, -10}{proper2,-10}{proper3}");

        Console.ReadLine();
    }
}