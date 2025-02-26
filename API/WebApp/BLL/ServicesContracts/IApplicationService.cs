using BLL.DTOs;

namespace BLL.ServicesContracts
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationDto>> GetApplicationsAsync();

        Task<ApplicationDto?> AddApplicationAsync(ApplicationDto appDto);
    }
}
