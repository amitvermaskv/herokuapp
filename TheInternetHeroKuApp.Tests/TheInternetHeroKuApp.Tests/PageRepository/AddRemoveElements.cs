using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace TheInternetHeroKuApp.Tests.PageRepository
{
    public class AddRemoveElements
    {
        private IWebDriver _driver;
        private const string pageURL = "https://the-internet.herokuapp.com/add_remove_elements/";
        public AddRemoveElements(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public IWebElement LblPageHeader => _driver.FindElement(By.TagName("h3"));
        public IWebElement BtnAddElement => _driver.FindElement(By.XPath("//button[contains(text(),'Add Element')]"));
        public ReadOnlyCollection<IWebElement> BtnAddedElements => _driver.FindElements(By.ClassName("added-manually"));

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(pageURL);
            Assert.Equal("The Internet", _driver.Title);
            Assert.Equal("Add/Remove Elements", LblPageHeader.Text);
            Assert.NotNull(BtnAddElement);
        }

        public void AddElements(int numberOfElements = 1)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                BtnAddElement.Click();
                Thread.Sleep(10);
            }
        }

    }
}
