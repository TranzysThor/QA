using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace CapitalPageObjectModel.Page
{
    public class PageFactoryBase
    {
        protected readonly IWebDriver Driver;
        protected WebDriverWait Wait;

        protected PageFactoryBase(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement FindElementToBeClickable(By elementLocator, double waitTime)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime));
            return Wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }
    }
}