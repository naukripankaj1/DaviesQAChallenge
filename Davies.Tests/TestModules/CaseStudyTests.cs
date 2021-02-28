using Davies.Tests.Hooks;
using Davies.Tests.Pages;
using NUnit.Framework;

namespace Davies.Tests.TestModules
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CaseStudyTests : Hook
    {
        [Test]
        //This test can be executed for other case studies too by changing the data 
        public void ValidateCaseStudySingleView()
        {
            //test data
            string caseStudy = "Fire investigation";
            string caseStudyResultExpected = "The dealership accepted fault and with an outlay to us of £1,495 made a recovery of £46,353.";

            //Click 'Solution' main menu
            _parallelConfig.CurrentPage.As<HomePage>().ClickMenu("Solutions");

            //Click 'View All' button for case study 
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<SolutionsPage>().ClickViewAllCaseStudy();

            //Find case study 'Fire investigation' and click on it
            _parallelConfig.CurrentPage.As<CaseStudyPage>().FindCaseStudyAndClick(caseStudy);

            //Validate single case study page displayed for 'Fire investigation'
            Assert.IsTrue(_parallelConfig.CurrentPage.As<CaseStudyPage>().ValidateSingleCaseStudypageDisplayed(caseStudy), "User does not navigated to case study page for - " + caseStudy);

            //Capture the result section and validate same
            Assert.AreEqual(caseStudyResultExpected, _parallelConfig.CurrentPage.As<CaseStudyPage>().GetCaseStudyResult(),"Case Study result does not displayed as - " + caseStudyResultExpected);
        }
    }
}
