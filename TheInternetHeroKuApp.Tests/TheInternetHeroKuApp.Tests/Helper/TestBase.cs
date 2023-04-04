namespace TheInternetHeroKuApp.Tests.Helper
{
    public class TestBase : IDisposable
    {
        public ReportHelper reportHelper;

        public TestBase()
        {
            reportHelper = new ReportHelper();
        }

        public void Dispose()
        {
            reportHelper.FlushReport();
        }
    }
}
