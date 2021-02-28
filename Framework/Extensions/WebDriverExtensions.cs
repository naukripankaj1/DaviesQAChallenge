using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers;

namespace Framework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static IWebElement ElementToBeClickable(this IWebDriver driver, IWebElement element, int time = 15)
        {
            return driver.Wait(time).Until(ExpectedConditions.ExpectedConditions.ElementToBeClickable(element));
        }

        public static bool TitleContains(this IWebDriver driver, string title, int time = 15)
        {
            return driver.Wait(time).Until(ExpectedConditions.ExpectedConditions.TitleContains(title));
        }

        public static bool UrlContains(this IWebDriver driver, string fraction, int time = 15)
        {
            return driver.Wait(time).Until(ExpectedConditions.ExpectedConditions.UrlContains(fraction));
        }

        public static void WaitForAction(this IWebDriver driver, int timeinsec = 2)
        {
            Thread.Sleep(new TimeSpan(0, 0, timeinsec));
        }

        public static void SwitchToOtherTab(this IWebDriver driver, int tab)
        {
            ReadOnlyCollection<string> handle = driver.WindowHandles;
            {
                driver.SwitchTo().Window(handle[tab]);
            }
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };

            Stopwatch stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                    break;
            }
        }

        public static IWait<IWebDriver> Wait(this IWebDriver driver, int time)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, new TimeSpan(0, 0, time));
            return wait;
        }
    }
}
