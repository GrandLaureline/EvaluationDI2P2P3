using BLL.DTOs;

namespace BLL.ServicesContracts
{
    public interface IPasswordService
    {
        Task<IEnumerable<PasswordDto>> GetPasswordsAsync();

        Task<PasswordDto?> GetPasswordByIdAsync(int id);

        Task<PasswordDto?> AddPasswordAsync(PasswordDto password);

        Task DeletePasswordAsync(int id);
    }
}

