using Framework.Base;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using Davies.Tests.Pages;
using Framework.Extensions;

namespace Davies.Tests.Hooks
{
    public class Hook
    {
        protected ParallelConfig _parallelConfig;
        int timeout = 30;

        [SetUp]
        public void InitializeSettings()
        {
            _parallelConfig = new ParallelConfig();
            ChromeOptions copt = new ChromeOptions();
            copt.AddArguments("--ignore-certificate-errors");
            copt.AddArguments("--incognito");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _parallelConfig.Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), copt, TimeSpan.FromSeconds(timeout));
            _parallelConfig.Driver.Manage().Window.Maximize();
            _parallelConfig.Driver.Navigate().GoToUrl("https://davies-group.com/");
            _parallelConfig.Driver.WaitForPageLoaded();

            _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
            _parallelConfig.CurrentPage.As<HomePage>().AllowAllCookies();
        }

        [TearDown]
        public void FinishTest() => _parallelConfig.Driver.Quit();
    }
}
