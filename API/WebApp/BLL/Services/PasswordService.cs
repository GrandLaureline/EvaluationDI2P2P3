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

        public async Task<IEnumerable<Password>> GetPasswordsAsync()
        {
            return await _passwordRepository.GetAllAsync();
        }

        public async Task<Password?> GetPasswordByIdAsync(int id) 
        { 
            return await _passwordRepository.GetByIdAsync(id); 
        }

        public async Task<Password?> AddPasswordAsync(Password password)
        {
            return await _passwordRepository.AddAsync(password);
        }

        public async Task DeletePasswordAsync(int id)
        {
            await _passwordRepository.DeleteAsync(id);
        }
    }
}
