using DAL.Entities;

namespace DAL.RepositoriesContracts
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAllAsync();

        Task<Application?> AddAsync(Application app);
    }
}
