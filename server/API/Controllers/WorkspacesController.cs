using API.Entities;
using AutoMapper;
using Core.DTOs;
using Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkspacesController : ControllerBase
    {
        private readonly IWorkspaceService _workspaceService;

        public WorkspacesController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workspaces = await _workspaceService.GetAllAsync();
            return Ok(workspaces);
        }
    }
}
