using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_WindowsFormsNET9.Models;
public partial class Person
{
    private int _id;

    /// <summary>
    /// Gets or sets the unique identifier for the person.
    /// </summary>
    /// <value>
    /// The unique identifier for the person.
    /// </value>
    public partial int Id
    {
        get => _id;
        set => _id = value;
    }

    private string _firstName;
    private string _lastName;

    /// <summary>
    /// Get or set the first name of the person.
    /// </summary>
    /// <value>
    /// A string representing the first name of the person.
    /// </value>
    public partial string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }
    /// <summary>
    /// Get or set the last name of the person.
    /// </summary>
    /// <value>
    /// A string representing the last name of the person.
    /// </value>
    public partial string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    /// <summary>
    /// Get or set the value of the <see cref="FirstName"/> or <see cref="LastName"/> based on the specified index.
    /// </summary>
    /// <param name="index">
    /// The index of the value to get or set. 
    /// Use 0 for <see cref="FirstName"/> and 1 for <see cref="LastName"/>.
    /// </param>
    /// <returns>
    /// The value of the <see cref="FirstName"/> if the index is 0, or the value of the <see cref="LastName"/> if the index is 1.
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">
    /// Thrown when the specified index is not 0 or 1.
    /// </exception>
    public partial string this[int index]
    {
        get => index switch
        {
            0 => FirstName,
            1 => LastName,
            _ => throw new IndexOutOfRangeException("Invalid index")
        };
        set
        {
            switch (index)
            {
                case 0:
                    FirstName = value;
                    break;
                case 1:
                    LastName = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }

}