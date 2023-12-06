using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComplexTypesSampleApp.Models;
public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Address Address { get; set; }
    public List<Order> Orders { get; } = new();
}