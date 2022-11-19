
namespace GetStartedWinForms.Components;

/// <summary>
/// VS2019 or VS2022 there is no BindingNavigator, here you go :-)
/// </summary>
public class CoreBindingNavigator : BindingNavigator
{
    public CoreBindingNavigator()
    {
        AddStandardItems();
    }
}