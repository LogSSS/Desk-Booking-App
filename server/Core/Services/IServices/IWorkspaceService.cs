using Core.DTOs;

namespace Core.Services.IServices
{
    public interface IWorkspaceService
    {
        Task<List<WorkspaceDTO>> GetAllAsync();
    }
}
