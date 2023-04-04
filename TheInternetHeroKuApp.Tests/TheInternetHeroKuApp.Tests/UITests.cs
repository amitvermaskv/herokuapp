using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TheInternetHeroKuApp.Tests.Helper;
using TheInternetHeroKuApp.Tests.PageRepository;

namespace TheInternetHeroKuApp.Tests
{
    public class UITests : IClassFixture<TestBase>, IDisposable
    {
        TestBase _testBase;
        IWebDriver _driver;
        readonly bool isGitHubActions = false;

        public UITests(TestBase testBase)
        {
            _testBase = testBase;
            ChromeOptions options = new ChromeOptions();
            isGitHubActions = Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
            if (isGitHubActions == true) options.AddArguments("--headless");
            _driver = new ChromeDriver(options);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        public void VerifyAddElements(int numberOfElementsToAdd)
        {
            var test = _testBase.reportHelper.CreateTest($"VerifyAddElements - {numberOfElementsToAdd}");
            try
            {
                test.Info("Navigating to Add / Removew Elements page");
                AddRemoveElements addRemoveElements = new AddRemoveElements(_driver);
                addRemoveElements.NavigateTo();

                test.Info($"Adding {numberOfElementsToAdd} # of elements on page");
                addRemoveElements.AddElements(numberOfElementsToAdd);
                var addedElements = addRemoveElements.BtnAddedElements;

                Assert.Equal(numberOfElementsToAdd, addedElements.Count);

                test.Pass("Test is executed successfully");
            }
            catch (Exception ex)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, $"StackTrace - {ex.StackTrace}");
                test.Fail(ex.ToString());
                throw;
            }
        }

        public void Dispose()
        {
            if (isGitHubActions) _driver.Quit();
            else _driver.Close();
            _driver.Dispose();
        }
    }
}