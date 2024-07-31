using System.Collections.Frozen;
using Dumpify;
using Ganss.Excel;
using ISetSamples.Classes;
using ISetSamples.Models;
using static ISetSamples.Classes.SpectreConsoleHelpers;
// ReSharper disable CollectionNeverQueried.Local

// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
#pragma warning disable CA1859
#pragma warning disable CA1859

namespace ISetSamples;

internal partial class Program
{

    static async Task Main(string[] args)
    {

        SetIntOperations1();
        SetIntOperations2();
        SetIntOperations3();

        var frozen = PeopleExceptWith();
        frozen.Dump(tableConfig: _tableConfig);

        frozen = PeopleUnionWith();
        frozen.Dump(tableConfig: _tableConfig);

        frozen = PeopleAdd();
        frozen.Dump(tableConfig: _tableConfig);

        Remove();

        await ReadFromExcel();

        PersonSortedByLastNameExample();

        ExitPrompt();
    }

    /// <summary>
    /// Create a list of people and then convert to a set.
    /// </summary>
    private static void ListToSet()
    {
        ShowExecutingMethodName();

        ISet<Person> peopleSet = new HashSet<Person>(PeopleData());
    }

    /// <summary>
    /// HashSet to a list of person
    /// </summary>
    private static void SetToList()
    {
        ShowExecutingMethodName();

        ISet<Person> peopleSet = new HashSet<Person>(PeopleData());
        List<Person> peopleList = [.. peopleSet];
    }


    /// <summary>
    /// Create a frozen set of people and then use the UnionWith method to add new people with duplicates.
    /// </summary>
    private static FrozenSet<Person> PeopleUnionWith()
    {
        ShowExecutingMethodName();

        var peopleSet = PeopleData();

        peopleSet.UnionWith([
            new() { Id = 1, FirstName = "Karen", LastName = "Payne",
                BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 2, FirstName = "Sam", LastName = "Smith",
                BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 3, FirstName = "Frank", LastName = "Adams",
                BirthDate = new DateOnly(1966,3,4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne",
                BirthDate = new DateOnly(1956,9,24) }
        ]);


        return peopleSet.ToFrozenSet();
    }

    private static void Remove()
    {
        ShowExecutingMethodName1();

        var peopleSet = PeopleData();
        Person person = new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976, 3, 4) };

        var result = peopleSet.Remove(person);
        AnsiConsole.MarkupLine(result ? $"{person} [yellow]removed[/]" : $"{person} [red]not removed[/]");

        // does not exist, so will not be removed and no runtime exception
        result = peopleSet.Remove(person);
        AnsiConsole.MarkupLine(result ? $"{person} [yellow]removed[/]" : $"{person} [red]not removed[/]");
    }

    /// <summary>
    /// From peopleSet, remove people that are in the exceptWith list
    /// </summary>
    private static FrozenSet<Person> PeopleExceptWith()
    {
        ShowExecutingMethodName();

        var peopleSet = PeopleData();

        peopleSet.ExceptWith([
            new() { Id = 2, FirstName = "Sam", LastName = "Smith",
                BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 3, FirstName = "Frank", LastName = "Adams",
                BirthDate = new DateOnly(1966,3,4) },
        ]);


        return peopleSet.ToFrozenSet();
    }


    /// <summary>
    /// Adds new people to the frozen set using Add method for the list.
    /// Duplicates will not be added
    /// </summary>
    private static FrozenSet<Person> PeopleAdd()
    {
        ShowExecutingMethodName();

        var peopleSet = PeopleData();

        peopleSet.Add(new()
        {
            Id = 3,
            FirstName = "Frank",
            LastName = "Adams",
            BirthDate = new DateOnly(1966, 3, 4)
        });
        peopleSet.Add(new()
        {
            Id = 4,
            FirstName = "Karen",
            LastName = "Payne",
            BirthDate = new DateOnly(1956, 9, 24)
        });

        return peopleSet.ToFrozenSet();
    }

    private static ISet<Person> PeopleData()
    {
        ISet<Person> peopleSet = new HashSet<Person>([

            new() { Id = 1, FirstName = "Karen", LastName = "Payne",
                BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 2, FirstName = "Sam", LastName = "Smith",
                BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne",
                BirthDate = new DateOnly(1956,9,24) }
        ]);

        return peopleSet;
    }

    private static List<Person> PeopleDataList()
    {
        List<Person> peopleList =
        [
            new() { Id = 1, FirstName = "Mike", LastName = "Williams",
                BirthDate = new DateOnly(1956,9,24)},
            new()
            {
                Id = 1, FirstName = "Karen", LastName = "Payne",
                BirthDate = new DateOnly(1956, 9, 24)
            },

            new()
            {
                Id = 2, FirstName = "Sam", LastName = "Smith",
                BirthDate = new DateOnly(1976, 3, 4)
            },

            new()
            {
                Id = 1, FirstName = "Karen", LastName = "Payne",
                BirthDate = new DateOnly(1956, 9, 24)
            }
        ];

        return peopleList.OrderBy(x => x.LastName).ToList();
    }

    /// <summary>
    /// Here we use the SymmetricExceptWith method to remove duplicates from the set.
    /// </summary>
    private static void SetIntOperations1()
    {

        ShowExecutingMethodName1();

        ISet<int> set1 = new HashSet<int> { 1, 2, 3 };
        ISet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Symmetric Difference
        set1.SymmetricExceptWith(set2); // set1 now contains {1, 2, 4, 5}

        set1.Dump();
    }

    /// <summary>
    /// Here we are doing too much work by first checking if a value is in the set and then adding it if it is not.
    /// All that is needed is to use .Add which will not add a duplicate.
    /// </summary>
    private static void SetIntOperations2()
    {

        ShowExecutingMethodName1();

        ISet<int> set = new HashSet<int> { 1, 2, 3 };

        int[] array = [3, 4, 5];

        foreach (var item in array)
        {
            // ReSharper disable once CanSimplifySetAddingWithSingleCall
            if (!set.Contains(item))
            {
                set.Add(item);
            }
        }

        set.Dump();

    }

    private static void SetIntOperations3()
    {

        ShowExecutingMethodName1();

        ISet<int> set = new HashSet<int> { 1, 2, 3 };

        int[] array = [3, 4, 5];

        foreach (var item in array)
        {
            set.Add(item);
        }

        set.Dump();

    }

    private static void PersonSortedByLastNameExample()
    {
        ShowExecutingMethodName1();

        var list = PeopleDataList();

        SortedSet<Person> people = new(new PersonComparer());

        people.AddRange(list);

        people.Dump(tableConfig: _tableConfig);

    }


    /// <summary>
    /// Here a worksheet is read from an Excel file which contains duplicates.
    ///
    /// Duplicate are evaluated from Equals method in the Customers class.
    /// 
    /// 1. Read entire sheet into a list
    /// 2. Convert list to a set
    /// 3. Into a list
    /// </summary>
    private static async Task ReadFromExcel()
    {
        
        ShowExecutingMethodName1();

        const string excelFile = "ExcelFiles\\Customers.xlsx";
        ExcelMapper excel = new();

        var customers = (await excel.FetchAsync<Customers>(excelFile, nameof(Customers)))
            .ToList();

        AnsiConsole.MarkupLine($"[cyan]Read {customers.Count}[/]");

        /*
         * There are two duplicates so the next count is two less
         */
        ISet<Customers> customersSet = new HashSet<Customers>(customers);
        AnsiConsole.MarkupLine($"[cyan]Afterwards {customersSet.Count}[/]");

        List<Customers> customersList = [.. customersSet];

    }
}