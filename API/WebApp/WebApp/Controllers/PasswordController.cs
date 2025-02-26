using BLL.DTOs;
using BLL.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IEncryptionService _encryptionService;

        public PasswordController(IPasswordService passwordService, IEncryptionService encryptionService)
        {
            _passwordService = passwordService;
            _encryptionService = encryptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passwords = await _passwordService.GetPasswordsAsync();
            return Ok(passwords);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PasswordDto password, [FromQuery] string appType)
        {
            // Sélectionne la stratégie de chiffrement basée sur le type d'application
            _encryptionService.SetEncryptionStrategy(appType);
            var encryptedPassword = _encryptionService.EncryptPassword(password.Value);
            password.Value = encryptedPassword;
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
