using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace CapitalPageObjectModel.Page
{
    public class CapitalHomePage : PageFactoryBase
    {
        private const string TestEmail = "ttEpamTestLabs5@gmail.com";
        private const string Password = "P@$$w0rd";

        private WebDriverWait _webDriverWait;
        
        [FindsBy(How = How.CssSelector, Using = ".outlined-light")]
        private IWebElement _tryDemoButton;

        [FindsBy(How = How.Name, Using = "ff0")]
        private IWebElement _emailInputField;

        [FindsBy(How = How.Name, Using = "ff1")]
        private IWebElement _passwordInputField;

        [FindsBy(How = How.CssSelector, Using = ".s2_btn")]
        private IWebElement _continueButton;

        public CapitalHomePage(IWebDriver driver) : base(driver) { }

        public void LogIn()
        {
            _tryDemoButton.Click();
        }

        public void InputEmail()
        {
            _emailInputField.SendKeys(TestEmail);
        }

        public void InputPassword()
        {
            _passwordInputField.SendKeys(Password);
        }

        public void LogInSubmission()
        {
            _continueButton.Click();
        }
        
        public void FindEmailInputFieldToBeClickable(double waitTime)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime));
            Wait.Until(ExpectedConditions.ElementToBeClickable(_emailInputField));
        }

        public void WaitUntilTradingPageIsLoaded(double waitTime)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime));
            Wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(".hasScroll > div:nth-child(1) > trade-category:nth-child(3) > div:nth-child(1)")));
        }
    }
}