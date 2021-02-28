using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Framework.Base
{
    public class ParallelConfig
    {
        public IWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
        public Actions Action { get; set; }
    }
}
