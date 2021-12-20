using System;
using System.Drawing;
using CapitalPageObjectModel.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CapitalPageObjectModel.Test
{
    public class Tests
    {
        private IWebDriver _driver;
        private CapitalHomePage _capitalHomePage;
        private CapitalTradingPage _capitalTradingPage;
        
        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Size = new Size(1920, 1080);
            _driver.Navigate().GoToUrl("https://capital.com/");
            _capitalHomePage = new CapitalHomePage(_driver);
            _capitalHomePage.LogIn();
            _capitalHomePage.FindEmailInputFieldToBeClickable(20);
            _capitalHomePage.InputEmail();
            _capitalHomePage.InputPassword();
            _capitalHomePage.LogInSubmission();
            _capitalHomePage.WaitUntilTradingPageIsLoaded(20);
        }

        [Test]
        public void AddMarketToFavoriteTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _capitalTradingPage.SwitchToMostTradedMarketsTab();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            String expectedMarketName = _capitalTradingPage.GetExpectedFavoriteMarketName();
            _capitalTradingPage.AddMarketToFavorite();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _capitalTradingPage.AddMarketToFavoriteConfirmation();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _capitalTradingPage.SwitchToFavoriteMarketsTab();
            String actualMarketName = _capitalTradingPage.GetActualFavoriteMarketName();
            Assert.AreEqual(expectedMarketName, actualMarketName);
            _capitalTradingPage.DeleteMarketFromFavorites();
        }

        [Test]
        public void AddGraphToGraphsTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _capitalTradingPage.SwitchToMostTradedMarketsTab();
            String expectedGraphMarketName = _capitalTradingPage.GetExpectedGraphMarketName();
            _capitalTradingPage.AddMarketGraphToGraphs();
            _capitalTradingPage.SwitchToFavoriteGraphsTab();
            String actualGraphMarketName = _capitalTradingPage.GetActualGraphMarketName();
            Assert.AreEqual(expectedGraphMarketName, actualGraphMarketName);
            _capitalTradingPage.DeleteGraphFromGraphs();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}