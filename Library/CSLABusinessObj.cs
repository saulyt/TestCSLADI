using Csla;
using Serilog;

namespace TestCSLADI.Library
{
    [Serializable]
    public class CSLABusinessObj : Csla.BusinessBase<CSLABusinessObj>
    {
        private readonly ILogger<CSLABusinessObj> _logger;

        [Fetch]
        private async Task FetchAsync([Inject] ITestDI testDI, [Inject] ILogger<CSLABusinessObj> _logger)
        {
            _logger.LogInformation("Create Time in CSLABusinessObj is:{c}", testDI.GetCreateTime().ToString("hh:mm:ss.fff tt"));
        }
    }
}
