using Core.DTOs;

namespace Core.IRepositories
{
    public interface IWorkspaceRepository
    {
        Task<List<WorkspaceDTO?>> GetAllAsync();
    }
}
