using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Framework.Extensions
{
    public static class JQueryExtension
    {
        public static IWebElement FindElement(this IWebDriver driver, JQueryHelper.JQueryBy by, int timeOut = 10)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeOut);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element : " + by.Selector + " to be searched not found";
            return fluentWait.Until(x => x.GetElement(by));

        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, JQueryHelper.JQueryBy by, int timeOut = 10, bool forIsDisplayed = false)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeOut);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elements : " + by.Selector + " to be searched not found";
            return fluentWait.Until(x => x.GetElements(by));
        }

        public static ReadOnlyCollection<IWebElement> GetElements(this IWebDriver driver, JQueryHelper.JQueryBy by)
        {
            ReadOnlyCollection<IWebElement> collection = ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery" + by.Selector + ".get()") as
                    ReadOnlyCollection<IWebElement>;
            if (collection == null)
                return null;
            return collection;
        }
        public static IWebElement GetElement(this IWebDriver driver, JQueryHelper.JQueryBy by)
        {
            ReadOnlyCollection<IWebElement> collection = ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery" + by.Selector + ".get()") as
                    ReadOnlyCollection<IWebElement>;
            if (collection == null)
                return null;
            return collection[0];
        }

    }
}
