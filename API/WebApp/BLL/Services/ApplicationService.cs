using BLL.ServicesContracts;
using DAL.Entities;
using DAL.RepositoriesContracts;

namespace BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            return await _applicationRepository.GetAllAsync();
        }

        public async Task<Application?> AddApplicationAsync(Application app)
        {
            return await _applicationRepository.AddAsync(app);
        }
    }
}
