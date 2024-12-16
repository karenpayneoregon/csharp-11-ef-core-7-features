using InterfaceExtensionApp.Classes;

namespace InterfaceExtensionApp;

internal partial class Program
{
    private static void Main()
    {

        var humans = MockedData.GetHumans();
        
        foreach (var human in humans)
        {
            human.Print();
            Console.WriteLine(); 
        }

        Console.ReadLine();
    }
}