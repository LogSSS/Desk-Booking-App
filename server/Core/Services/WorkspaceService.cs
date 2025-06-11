using Core.DTOs;
using Core.IRepositories;
using Core.Services.IServices;

namespace Core.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IWorkspaceRepository _workspaceRepository;

        public WorkspaceService(IWorkspaceRepository workspaceRepository)
        {
            _workspaceRepository = workspaceRepository;
        }

        public async Task<List<WorkspaceDTO?>> GetAllAsync()
        {
            return await _workspaceRepository.GetAllAsync();
        }
    }
}
