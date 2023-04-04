using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace TheInternetHeroKuApp.Tests.Helper
{
    public class ReportHelper
    {
        private readonly ExtentReports _extentReports;

        public ReportHelper()
        {
            _extentReports = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(AppDomain.CurrentDomain.BaseDirectory + @"\ExtentReport\");
            htmlReporter.Config.DocumentTitle = "TheInternet HeroKuApp - Test Execution Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extentReports.AttachReporter(htmlReporter);
        }

        public ExtentTest CreateTest(string testName)
        {
            return _extentReports.CreateTest(testName);
        }

        public void FlushReport()
        {
            _extentReports.Flush();
        }
    }
}
