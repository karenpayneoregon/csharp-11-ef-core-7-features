using NFluent;
using TraitsTestLibrary.Classes;
using TraitsTestProject.Base;
using TraitsTestProject.Models;

namespace TraitsTestProject;

/// <summary>
/// Example using upper-cased rule
/// </summary>
[TestClass]
public partial class MobileDevicesTests : TestBase
{
    [TestMethod]
    [TestTraits(Trait.Mobile)]
    public void MobileDevicesValidTest()
    {
        MobileDeviceCodes mobileDevice = new()
        {
            Code = 'P',
            Description = "Phone"
        };

        EntityValidationResult result = Model.Validate(mobileDevice);
        Check.That(result.IsValid).IsTrue();

    }

    [TestMethod]
    [TestTraits(Trait.Mobile)]
    public void MobileDeviceInvalidCodeTest()
    {
        MobileDeviceCodes mobileDevice = new()
        {
            Code = 'p',
            Description = "Phone"
        };

        EntityValidationResult result = Model.Validate(mobileDevice);
            
        Check.That(result.IsValid).IsFalse();

    }
}