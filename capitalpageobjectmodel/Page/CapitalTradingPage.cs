using System;
using OpenQA.Selenium;

namespace CapitalPageObjectModel.Page
{
    public class CapitalTradingPage : PageFactoryBase
    {
        private readonly By _mostTradedMarketsButton =
            By.CssSelector(".hasScroll > div:nth-child(1) > trade-category:nth-child(3) > div:nth-child(1)");

        private readonly By _addToFavoriteButton =
            By.CssSelector(
                "trade-instruments-button.selected > div:nth-child(1) > div:nth-child(7) > add-instrument-to-watchlist-button:nth-child(2) > i:nth-child(1)");

        private readonly By _addToFavoritesConfirmationButton = By.CssSelector(".button-main");

        private readonly By _favoriteMarketsButton =
            By.CssSelector(
                "scroll-pane.hasScroll):nth-child(2) > div:nth-child(1) > trade-category:nth-child(2) > div:nth-child(1)");

        private readonly By _deleteFromFavoriteButton = By.CssSelector("div.col:nth-child(7) > add-instrument-to-watchlist-button:nth-child(2) > i:nth-child(1)");
        
        private readonly By _expectedFavoriteMarketName = By.CssSelector("trade-instruments-button.selected > div:nth-child(1) > div:nth-child(2) > div:nth-child(1)");
        
        private readonly By _actualFavoriteMarketName = By.CssSelector("div.market:nth-child(2) > div:nth-child(1)");
        
        public CapitalTradingPage(IWebDriver driver) : base(driver) { }

        public void SwitchToMostTradedMarketsTab()
        {
            var mostTradedMarketsButton = Driver.FindElement(_mostTradedMarketsButton);
            mostTradedMarketsButton.Click();
            mostTradedMarketsButton.Click();
        }

        public void AddMarketToFavorite()
        {
            var addToFavoriteButton = Driver.FindElement(_addToFavoriteButton);
            addToFavoriteButton.Click();
        }

        public void AddMarketToFavoriteConfirmation()
        {
            var addToFavoritesConfirmationButton = Driver.FindElement(_addToFavoritesConfirmationButton);
            addToFavoritesConfirmationButton.Click();
        }

        public void SwitchToFavoriteMarketsTab()
        {
            var favoriteMarketsButton = Driver.FindElement(_favoriteMarketsButton);
            favoriteMarketsButton.Click();
        }

        public void DeleteMarketFromFavorites()
        {
            var deleteFromFavoriteButton = Driver.FindElement(_deleteFromFavoriteButton);
            deleteFromFavoriteButton.Click();
        }

        public String GetExpectedFavoriteMarketName()
        {
            var expectedFavoriteMarketName = Driver.FindElement(_expectedFavoriteMarketName).Text;
            return expectedFavoriteMarketName;
        }

        public String GetActualFavoriteMarketName()
        {
            var actualFavoriteMarketName = Driver.FindElement(_actualFavoriteMarketName).Text;
            return actualFavoriteMarketName;
        }
    }
}