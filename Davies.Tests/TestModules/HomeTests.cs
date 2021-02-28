using Davies.Tests.Data;
using Davies.Tests.Hooks;
using Davies.Tests.Pages;
using NUnit.Framework;

[assembly: LevelOfParallelism(4)]
namespace Davies.Tests.TestModules
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HomeTests : Hook
    {
        [Test]
        public void ValidateTwiterNavigation()
        {
            //Click on Twitter icon 
           _parallelConfig.CurrentPage.As<HomePage>().ClickTwiterLink();
            Assert.Multiple(() =>
            {
                //validate twitter launched in new tab
                Assert.IsTrue(_parallelConfig.CurrentPage.As<HomePage>().SwitchTabAndValidateUrl(Constants.TwitterUrl), "Does not navigated to Url - " + Constants.TwitterUrl);

                //Validate page title displayed containing 'Twitter'
                Assert.IsTrue(_parallelConfig.CurrentPage.As<HomePage>().ValidateScreenTitle(Constants.DaviesTwitterTitle), "Screen title does not displayed containing - " + Constants.DaviesTwitterTitle);
            });
        }

        [Test]
        public void ValidateLinkedInNavigation()
        {
            //Click on Twitter icon 
            _parallelConfig.CurrentPage.As<HomePage>().ClickLinkedInLink();
            Assert.Multiple(() =>
            {
                //validate linkedin launched in new tab
                Assert.IsTrue(_parallelConfig.CurrentPage.As<HomePage>().SwitchTabAndValidateUrl(Constants.LinkedinUrl), "Does not navigated to Url - " + Constants.LinkedinUrl);

                ///Validate page title displayed containing 'LinkedIn'
                Assert.IsTrue(_parallelConfig.CurrentPage.As<HomePage>().ValidateScreenTitle(Constants.DaviesLinkedInTitle), "Screen title does not displayed containing - " + Constants.DaviesLinkedInTitle);
            });
        }
    }
}
