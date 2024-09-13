
using TraitsTestProject.Models;

// ReSharper disable once CheckNamespace
namespace TraitsTestProject;

public partial class BooksTests
{
    [TestInitialize]
    public void Initialization() { }

    [ClassInitialize()]
    public static void ClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
    }

    /// <summary>
    /// Mocked up, valid <see cref="Book"/>
    /// </summary>
    public static Book GoneWithTheWindBook => new ()
    {
        Title = "Gone with the wind",
        ISBN = "9780024894403",
        Category = BookCategory.Romance,
        NotesList =
        [
            "Few books evoke the Civil War-era South " +
            "so powerfully, compellingly, and iconically."
        ]
    };

}