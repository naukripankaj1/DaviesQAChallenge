using Davies.Tests.Data;
using Davies.Tests.Hooks;
using Davies.Tests.Pages;
using NUnit.Framework;

namespace Davies.Tests.TestModules
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LocationTests : Hook
    {
        [Test]
        public void GetAddressByCityAndValidate()
        {
            //Test Data
            var expectedAddress = "3rd and 4th Floors, No.2 Smithfields, Stoke-on-Trent ST1 3DH, UK.";

            //Navigate to ‘About’ -> ‘Locations’
            _parallelConfig.CurrentPage.As<HomePage>().ClickMenu("About" , "Locations");

            //Click UK & Ireland button
            _parallelConfig.CurrentPage.As<LocationsPage>().ClickUKAndIrelandButton();

            //Capture Stoke Office address from Map
            var actualAddress = _parallelConfig.CurrentPage.As<LocationsPage>().GetAddressByCity("Stoke");

            //Validate address
            Assert.AreEqual(expectedAddress, actualAddress, "Expected & Actual adrress are not same.");
        }
    }
}
