using DAL.Entities;

namespace BLL.ServicesContracts
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetApplicationsAsync();

        Task<Application?> AddApplicationAsync(Application appDto);
    }
}
