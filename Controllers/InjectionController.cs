using Csla;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestCSLADI.Library;

namespace TestCSLADI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InjectionController : ControllerBase
    {
        ITestDI _testDI;

        private readonly ILogger<InjectionController> _logger;

        public InjectionController(ITestDI testDI, ILogger<InjectionController> logger)
        {
            _logger = logger;
            _testDI = testDI;
        }

        [HttpGet]
        public async Task Get()
        {

            _logger.LogInformation("Create Time in InjectionController is:{c}", _testDI.GetCreateTime().ToString("hh:mm:ss.fff tt"));
            var obj = await DataPortal.FetchAsync<CSLABusinessObj>();
        }
    }
}