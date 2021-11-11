using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CapitalTest
{
    public class Tests
    {
        private IWebDriver _webDriver;
        private WebDriverWait _webDriverWait;
        
        private const string TestEmail = "ttEpamTestLabs4@gmail.com";
        private const string Password = "P@$$w0rd";

        private const string ExpectedFavoritedMarketName = "Bitcoin / USD";
        
        [SetUp]
        public void Setup()
        {
            _webDriver = new FirefoxDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://capital.com/");

            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(35));
            
            var tryDemoButton = _webDriver.FindElement(By.CssSelector(".outlined-light"));
            tryDemoButton.Click();
            
            _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.Name("ff0")));
            
            var emailInputField = _webDriver.FindElement(By.Name("ff0"));
            emailInputField.SendKeys(TestEmail);

            var passwordInputField = _webDriver.FindElement(By.Name("ff1"));
            passwordInputField.SendKeys(Password);

            _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".s2_btn")));

            var continueButton = _webDriver.FindElement(By.CssSelector(".s2_btn"));
            continueButton.Click();

            _webDriverWait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='checkbox-theme__btn']")));
        }

        [Test]
        public void AddMarketToFavoriteTest()
        {
            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            var mostTradedMarketsButton = _webDriver.FindElements(By.TagName("i"))[2];
            mostTradedMarketsButton.Click();
            mostTradedMarketsButton.Click();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//div[@class='col favorites']//add-instrument-to-watchlist-button//i")));

            var addToFavoriteButton = _webDriver.FindElements(By.XPath("//div[@class='col favorites']//add-instrument-to-watchlist-button//i"))[0];
            addToFavoriteButton.Click();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            var addToFavoritesConfirmationButton =
                _webDriver.FindElement(By.XPath("//div[@class='popover-add-watchlist__footer']//button[@class='button-main button-main--medium']"));
            addToFavoritesConfirmationButton.Click();
            
            var favoriteMarketsButton = _webDriver.FindElements(By.TagName("i"))[1];
            favoriteMarketsButton.Click();
            favoriteMarketsButton.Click();
            
            String actualFavoritedMarketName = _webDriver.FindElements(By.XPath("//div[@class='col market']"))[1].Text;

            Assert.AreEqual(ExpectedFavoritedMarketName, actualFavoritedMarketName);
        }
        
        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
