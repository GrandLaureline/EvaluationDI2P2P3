using DAL.Entities;

namespace BLL.ServicesContracts
{
    public interface IPasswordService
    {
        Task<IEnumerable<Password>> GetPasswordsAsync();

        Task<Password?> GetPasswordByIdAsync(int id);

        Task<Password?> AddPasswordAsync(Password password);

        Task DeletePasswordAsync(int id);
    }
}

