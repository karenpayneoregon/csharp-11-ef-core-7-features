using KP_WindowsFormsNET9.EFCore.Sample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_WindowsFormsNET9.EFCore.Sample1.Classes;
public class MockedData
{
    /// <summary>
    /// Retrieves a collection of sample data objects for use in DbContext.AddRange
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> containing sample data objects.</returns>
    public static IEnumerable<object> GetSampleData()
    {
        return new List<object>
        {
            new Store
            {
                Customers = { new CustomerWithStores { Name = "Smokey", Region = "Germany" } },
                Region = "Germany",
                StoreAddress = new("L1", null, "Ci1", "Co1", "P1")
            },
            new Customer
            {
                Name = "Smokey",
                CustomerInfo = new("EF")
                {
                    HomeAddress = new("L2", null, "Ci2", "Co2", "P2"), WorkAddress = new("L3", null, "Ci3", "Co3", "P3")
                },
            },
            new CustomerTpt
            {
                Name = "Willow",
                CustomerInfo = new("EF")
                {
                    HomeAddress = new("L5", null, "Ci5", "Co5", "P5"), WorkAddress = new("L6", null, "Ci6", "Co6", "P6")
                },
            },
            new SpecialCustomerTpt
            {
                Name = "Olive",
                CustomerInfo = new("EF")
                {
                    HomeAddress = new("L7", null, "Ci7", "Co7", "P7"), WorkAddress = new("L8", null, "Ci8", "Co8", "P8")
                }
            }
        };
    }

}
