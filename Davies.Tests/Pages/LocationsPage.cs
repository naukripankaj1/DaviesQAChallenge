using Framework.Base;
using Framework.Extensions;
using Framework.Helpers;
using OpenQA.Selenium;

namespace Davies.Tests.Pages
{
    public class LocationsPage : HomePage
    {
        public LocationsPage(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region Map of elements
        IWebElement UKIrelandButton => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("button:contains('UK & Ireland')"));
        IWebElement LocationDetail(string city) => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("ul.no-dots.location__descriptions li:contains('" + city + "')"));
        #endregion

        #region Page Methods
        public void ClickUKAndIrelandButton()
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            UKIrelandButton.JavaScriptClick(_parallelConfig.Driver);
        }

        public string GetAddressByCity(string city)
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            var address = LocationDetail(city).FindElement(By.TagName("p"));  
            return address.GetAttribute("textContent");
        }

        #endregion
    }
}
