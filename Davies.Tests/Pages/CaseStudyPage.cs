using Framework.Base;
using Framework.Extensions;
using Framework.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Davies.Tests.Pages
{
    public class CaseStudyPage : HomePage
    {
        public CaseStudyPage(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region Map of elements
        IList<IWebElement> CaseStudyHeadings => _parallelConfig.Driver.FindElements(JQueryHelper.jQuery("div.dg-cases-section__post-heading"));
        IWebElement PostCounter => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("span.post-counter"));
        IWebElement TotalPosts => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("span.found-posts"));
        IWebElement LoadMoreCaseStudies => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("button.case-archive__load-more"));
        IWebElement SingleCaseStudyHeader => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("div.case-hero__wrapper h1"));
        IWebElement SingleCaseStudyResult => _parallelConfig.Driver.FindElement(JQueryHelper.jQuery("div.case-single-desc__flex p").Eq(1));
        #endregion

        #region Page Methods
        public void FindCaseStudyAndClick(string caseStudy)
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            while (!CaseStudyHeadings.Any(x => x.Text.Trim().Equals(caseStudy)))
            {
                LoadMoreCaseStudies.JavaScriptClick(_parallelConfig.Driver);
                _parallelConfig.Driver.WaitForPageLoaded();
                _parallelConfig.Driver.WaitForAction();
            }
            CaseStudyHeadings.FirstOrDefault(x => x.Text.Equals(caseStudy)).JavaScriptClick(_parallelConfig.Driver);
        }

        public bool ValidateSingleCaseStudypageDisplayed(string caseStudy)
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            return _parallelConfig.Driver.ElementToBeClickable(SingleCaseStudyHeader).Text.Equals(caseStudy);
        }

        public string GetCaseStudyResult()
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            return _parallelConfig.Driver.ElementToBeClickable(SingleCaseStudyResult).Text;
        }
        #endregion
    }
}
