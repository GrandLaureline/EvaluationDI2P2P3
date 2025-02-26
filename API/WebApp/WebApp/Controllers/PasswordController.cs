using BLL.ServicesContracts;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passwords = await _passwordService.GetPasswordsAsync();
            return Ok(passwords);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Password password)
        {
            var createdPassword = await _passwordService.AddPasswordAsync(password);
            return createdPassword != null ? CreatedAtAction(nameof(GetAll), new { }, password) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _passwordService.DeletePasswordAsync(id);
            return NoContent();
        }
    }
}
