namespace FieldKeywordSample.Interfaces;

public interface IPerson
{
    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    /// <value>
    /// The unique identifier for the customer.
    /// </value>
    int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the customer.
    /// </summary>
    /// <value>
    /// The first name of the customer, with leading and trailing whitespace removed.
    /// </value>
    string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the customer.
    /// </summary>
    /// <value>
    /// The last name of the customer.
    /// </value>
    string LastName { get; set; }

    /// <summary>
    /// Gets or sets the birthdate of the person.
    /// </summary>
    /// <value>
    /// The birthdate represented as a <see cref="DateOnly"/>.
    /// </value>
    public DateOnly BirthDate { get; set; }
}