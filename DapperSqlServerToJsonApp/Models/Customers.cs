using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSqlServerToJsonApp.Models;
internal class Customers
{
    public int CustomerIdentifier { get; set; }
    public string CompanyName { get; set; }
    public int ContactId { get; set; }
    public int ContactTypeIdentifier { get; set; }
    public string ContactTitle { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CountryIdentifier { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}
