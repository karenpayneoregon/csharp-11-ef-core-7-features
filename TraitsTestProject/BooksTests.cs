using NFluent;
using TraitsTestLibrary.Classes;
using TraitsTestProject.Base;
using TraitsTestProject.Models;
using static TraitsTestProject.Base.Trait;

namespace TraitsTestProject;

[TestClass]
public partial class BooksTests : TestBase
{

    [TestMethod]
    [TestTraits(Books)]
    public void ValidateBook_Good_Test()
    {
        // arrange
        Book book = GoneWithTheWindBook;
            
        // act
        EntityValidationResult validationResult = Model.Validate(book);

        // assert
        Check.That(validationResult.HasError).IsFalse();
    }

    [TestMethod]
    [TestTraits(Books)]
    public void ValidateBook_Good_1_Test()
    {
        // arrange
        Book book = GoneWithTheWindBook;

        // act
        var response = SimpleValidator.Validate(book);

        // assert
        Check.That(response.IsValid).IsTrue();
    }

    [TestMethod]
    [TestTraits(Books)]
    public void ValidateBook_NoCategory_Test()
    {
        // arrange
        Book book = GoneWithTheWindBook;
        book.Category = null;
        const string expected = "Category is required";

        // act
        EntityValidationResult result = Model.Validate(book);

        // assert
        Check.That(result.Errors.Any(validationResult => 
                validationResult.ErrorMessage!.Contains(expected)))
            .IsTrue();
    }

    [TestMethod]
    [TestTraits(Books)]
    public void ValidateBook_NoCategory_1_Test()
    {
        // arrange
        Book book = GoneWithTheWindBook;
        book.Category = null;

        // act
        var response = SimpleValidator.Validate(book);

        // assert
        Check.That(response.IsValid).IsFalse();

    }
    [TestMethod]
    [TestTraits(Books)]
    public void ValidateBook_NoIsbn_Test()
    {
        // arrange
        Book book = GoneWithTheWindBook;
        book.ISBN = "";
        const string expected = "ISBN is required";

        // act
        EntityValidationResult result = Model.Validate(book);

        // assert
        Check.That(result.Errors.Any(validationResult => 
                validationResult.ErrorMessage!.Contains(expected)))
            .IsTrue();

    }
    [TestMethod]
    [TestTraits(Books)]
    public void ValidateBook_EmptyBook_Test()
    {
        // arrange
        Book book = new ();

        // act
        EntityValidationResult result = Model.Validate(book);


        // assert
        Check.That(result.Errors.Count).Equals(4);

    }

}