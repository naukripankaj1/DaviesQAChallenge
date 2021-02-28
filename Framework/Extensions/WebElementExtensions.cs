using OpenQA.Selenium;

namespace Framework.Extensions
{
    public static class WebElementExtensions
    {
        public static void JavaScriptClick(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void ScrollIntoView(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}
