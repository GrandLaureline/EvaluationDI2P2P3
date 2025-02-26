using BLL.DTOs;
using BLL.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await _applicationService.GetApplicationsAsync();
            return Ok(applications);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ApplicationDto application)
        {
            var createdApp = await _applicationService.AddApplicationAsync(application);
            return createdApp != null ? CreatedAtAction(nameof(GetAll), new { }, createdApp) : BadRequest();
        }
    }
}
