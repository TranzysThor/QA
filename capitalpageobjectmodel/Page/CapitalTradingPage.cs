using System;
using OpenQA.Selenium;

namespace CapitalPageObjectModel.Page
{
    public class CapitalTradingPage : PageFactoryBase
    {
        private readonly By _mostTradedMarketsButton =
            By.XPath("/html/body/app-root/div/left-side-panel/div[1]/div/div[2]/trade-view/div/div/div[1]/div/trade-categories/scroll-pane/div[1]/trade-category[3]/div");

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

        private readonly By _expectedGraphMarketName = By.CssSelector(".trade-instruments-content > trade-instruments-list:nth-child(2) > scroll-pane:nth-child(1) > div:nth-child(1) > trade-instruments-button:nth-child(1) > div:nth-child(1) > div:nth-child(2)");
        private readonly By _actualGraphMarketName = By.CssSelector(".state-item-button > div:nth-child(1)");
        private readonly By _addToGraphsButton =
            By.CssSelector(
                "trade-instruments-button.selected > div:nth-child(1) > div:nth-child(7) > spotlight-button:nth-child(1) > span:nth-child(1)");
        private readonly By _graphsButton = By.CssSelector("div.side-nav__item:nth-child(3) > span:nth-child(2)");

        private readonly By _deleteGraphFromGraphsButton =
            By.CssSelector(".state-item-button > icon-button:nth-child(2) > font-icon:nth-child(1)");


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

        public void AddMarketGraphToGraphs()
        {
            var marketGraphButton = Driver.FindElement(_addToGraphsButton);
            marketGraphButton.Click();
        }

        public void SwitchToFavoriteGraphsTab()
        {
            var favoriteGraphsButton = Driver.FindElement(_graphsButton);
            favoriteGraphsButton.Click();
        }

        public String GetExpectedGraphMarketName()
        {
            var expectedGraphMarketName = Driver.FindElement(_expectedGraphMarketName).Text;
            return expectedGraphMarketName;
        }
        
        public String GetActualGraphMarketName()
        {
            var actualGraphMarketName = Driver.FindElement(_actualGraphMarketName).Text;
            return actualGraphMarketName;
        }

        public void DeleteGraphFromGraphs()
        {
            var deleteGraphFromGraphsButton = Driver.FindElement(_deleteGraphFromGraphsButton);
            deleteGraphFromGraphsButton.Click();
        }
    }
}