using BLL.DTOs;
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

        public async Task<IEnumerable<ApplicationDto>> GetApplicationsAsync()
        {
            var applications = await _applicationRepository.GetAllAsync();
            return applications.Select(a => new ApplicationDto
            {
                Id = a.Id,
                Name = a.Name,
                Type = a.Type,
            });
        }

        public async Task<ApplicationDto?> AddApplicationAsync(ApplicationDto appDto)
        {
            var newApplication = new Application
            {
                Id = appDto.Id,
                Name = appDto.Name,
                Type = appDto.Type,
            };

            var createdApplication = await _applicationRepository.AddAsync(newApplication);

            return new ApplicationDto
            {
                Id = createdApplication.Id,
                Name = createdApplication.Name,
                Type = createdApplication.Type,
            };
        }
    }
}
