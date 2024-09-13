

// ReSharper disable once CheckNamespace
namespace TraitsTestProject
{
    public partial class MobileDevicesTests
    {
        [TestInitialize]
        public void Initialization()
        {

        }

        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }

    }

}