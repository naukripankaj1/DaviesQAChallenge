using Framework.Base;
using Framework.Extensions;
using Framework.Helpers;
using OpenQA.Selenium;

namespace Davies.Tests.Pages
{
    public class SolutionsPage : HomePage
    {
        public SolutionsPage(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region Map of elements
        IWebElement ViewAllCaseStudy => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("div.dg-cases-section__footer a"));
        IWebElement ViewAllArticles => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("div.dg-featured-articles__button a"));
        #endregion

        #region Page Methods
        public CaseStudyPage ClickViewAllCaseStudy()
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            ViewAllCaseStudy.JavaScriptClick(_parallelConfig.Driver);
            return new CaseStudyPage(_parallelConfig);
        }
        #endregion
    }
}
