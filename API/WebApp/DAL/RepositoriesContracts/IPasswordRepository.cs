using DAL.Entities;

namespace DAL.RepositoriesContracts
{
    public interface IPasswordRepository
    {
        Task<IEnumerable<Password>> GetAllAsync();

        Task<Password?> GetByIdAsync(int id);

        Task<Password?> AddAsync(Password password);

        Task DeleteAsync(int id);
    }
}
