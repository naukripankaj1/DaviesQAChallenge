using Framework.Base;
using Framework.Extensions;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace Davies.Tests.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region Map of elements        
        IWebElement Logo => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("a[title='Davies']"));
        IWebElement AllowCookies => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("a#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        IWebElement TwiterLink => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("ul.footer__socials a").First());
        IWebElement LinkedInLink => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("ul.footer__socials a").Last());

        //Menu
        IWebElement MainMenu(string parentMenu) => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("#main-menu li:contains('" + parentMenu + "'):visible"));

        #endregion

        #region Methods        
        public void ClickTwiterLink() => TwiterLink.JavaScriptClick(_parallelConfig.Driver);

        public void ClickLinkedInLink() => LinkedInLink.JavaScriptClick(_parallelConfig.Driver);

        public bool SwitchTabAndValidateUrl(string url)
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            _parallelConfig.Driver.SwitchToOtherTab(1);
            return _parallelConfig.Driver.UrlContains(url); ;
        }

        public bool ValidateScreenTitle(string title) => _parallelConfig.Driver.TitleContains(title);

        public void ClickMenu(string parentMenu)
        {
            _parallelConfig.Driver.ElementToBeClickable(MainMenu(parentMenu)).Click();
            switch (parentMenu)
            {
                case "Solutions":
                    _parallelConfig.CurrentPage = new SolutionsPage(_parallelConfig);
                    break;
                    //to be implemented for other pages
            }
        }

        public void ClickMenu(string parentMenu, string childMenu)
        {
            _parallelConfig.Driver.ElementToBeClickable(MainMenu(parentMenu));
            _parallelConfig.Action = new Actions(_parallelConfig.Driver);
            _parallelConfig.Action.MoveToElement(MainMenu(parentMenu)).Perform();
            MainMenu(parentMenu).FindElement(By.XPath("//a[contains(text(),'" + childMenu + "')]")).JavaScriptClick(_parallelConfig.Driver);
            switch (childMenu)
            {
                case "Locations":
                    _parallelConfig.CurrentPage = new LocationsPage(_parallelConfig);
                    break;
                    //to be implemented for other pages
            }
        }

        public void AllowAllCookies()
        {
            try
            {
                AllowCookies.JavaScriptClick(_parallelConfig.Driver);
            }
            catch (Exception)
            { }
        }
        #endregion

    }
}
