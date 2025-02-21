using System.Collections.Generic;
using System.Linq;
using KarenConsoleApplication.Data;
using KarenConsoleApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace KarenConsoleApplication.Classes
{
    /// <summary>
    /// Provides operations for interacting with the database, including retrieving customer data 
    /// with associated contact type and gender information.
    /// </summary>
    /// <remarks>
    /// This class is designed to facilitate database operations by utilizing an instance of the 
    /// <see cref="Context"/> class. It includes methods for fetching and processing data from the database.
    /// </remarks>
    public class DataOperations
    {
        /// <summary>
        /// An instance of the <see cref="Context"/> class that provides access to the database.
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataOperations"/> class with the specified database context.
        /// </summary>
        /// <param name="context">
        /// An instance of the <see cref="Context"/> class that provides access to the database.
        /// </param>
        /// <remarks>
        /// This constructor is used to set up the <see cref="DataOperations"/> class with a specific 
        /// <see cref="Context"/> instance, enabling database operations.
        /// </remarks>
        public DataOperations(Context context)
        {
            _context = context;
        }
        /// <summary>
        /// Retrieves a list of customers with their associated contact type and gender information.
        /// </summary>
        /// <remarks>
        /// This method fetches up to two customers from the database, including their related 
        /// <see cref="Customer.ContactTypeIdentifierNavigation"/> and <see cref="Customer.GenderIdentifierNavigation"/> entities.
        /// </remarks>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Customer"/> objects, each containing customer details 
        /// and their associated contact type and gender information.
        /// </returns>
        public List<Customer> GetCustomers()
        {
            return _context
                .Customers
                .Include(c => c.ContactTypeIdentifierNavigation)
                .Include(c => c.GenderIdentifierNavigation)
                .Take(2)
                .ToList();
        }
    }
}
