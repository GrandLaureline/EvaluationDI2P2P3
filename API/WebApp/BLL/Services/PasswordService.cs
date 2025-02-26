using BLL.DTOs;
using BLL.ServicesContracts;
using DAL.Entities;
using DAL.RepositoriesContracts;

namespace BLL.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;

        public PasswordService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        public async Task<IEnumerable<PasswordDto>> GetPasswordsAsync()
        {
            var passwords = await _passwordRepository.GetAllAsync();
            return passwords.Select(p => new PasswordDto
            {
                Id = p.Id,
                Value = p.Value,
                NomCompte = p.NomCompte,
                ApplicationId = p.ApplicationId,
                Application = p.Application == null ? null : new ApplicationDto
                {
                    Id = p.Application.Id,
                    Name = p.Application.Name,
                }
            });
        }

        public async Task<PasswordDto?> GetPasswordByIdAsync(int id) 
        {
            var p = await _passwordRepository.GetByIdAsync(id) ?? null;
            return new PasswordDto
            {
                Id = p.Id,
                Value = p.Value,
                NomCompte = p.NomCompte,
                ApplicationId = p.ApplicationId,
                Application = p.Application == null ? null : new ApplicationDto
                {
                    Id = p.Application.Id,
                    Name = p.Application.Name,
                }
            };
        }

        public async Task<PasswordDto?> AddPasswordAsync(PasswordDto password)
        {
            var newPassword = new Password
            {
                Value = password.Value,
                NomCompte = password.NomCompte,
                ApplicationId = password.ApplicationId,
            };

            var createdPassword = await _passwordRepository.AddAsync(newPassword);

            return new PasswordDto
            {
                Id = createdPassword.Id,
                Value = createdPassword.Value,
                NomCompte = createdPassword.NomCompte,
                ApplicationId = createdPassword.ApplicationId,
            };
        }

        public async Task DeletePasswordAsync(int id)
        {
            await _passwordRepository.DeleteAsync(id);
        }
    }
}
