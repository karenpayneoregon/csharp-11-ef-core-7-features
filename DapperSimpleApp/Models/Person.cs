using System;

namespace DapperSimpleApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString() => $"{FirstName} {LastName}";

    }
}

