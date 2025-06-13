using AutoMapper;
using Core.DTOs;
using Core.IRepositories;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Constants;

namespace DAL.Repositories
{
    public class WorkspaceRepository : IWorkspaceRepository
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public WorkspaceRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkspaceDTO>> GetAllAsync()
        {
            var superUserId = Constants.SuperUserId;
            var currentDate = DateTime.UtcNow;

            var workspaces = await _context
                .Workspaces.Include(w => w.Amenities)
                .Include(w => w.Images)
                .Include(w => w.CapacityOptions)
                .ThenInclude(co => co.RoomAvailabilities)
                .Select(w => new
                {
                    Workspace = w,
                    Booked = _context
                        .Bookings.Where(b =>
                            b.WorkspaceId == w.Id
                            && b.OwnerId == superUserId
                            && b.StartDate >= currentDate
                        )
                        .OrderBy(b => b.StartDate)
                        .FirstOrDefault(),
                })
                .ToListAsync();

            var mappedWorkspaces = workspaces
                .Select(w => _mapper.Map<WorkspaceDTO>(w.Workspace))
                .ToList();

            foreach (var workspace in mappedWorkspaces)
            {
                foreach (var capacityOption in workspace.CapacityOptions)
                    capacityOption.RoomAvailabilities =
                    [
                        .. capacityOption.RoomAvailabilities.OrderBy(r => r.MaxPeople),
                    ];

                var booked = workspaces.FirstOrDefault(w => w.Workspace.Id == workspace.Id)?.Booked;

                if (booked != null)
                    workspace.Booked = _mapper.Map<BookingDTO>(booked);
            }

            return mappedWorkspaces;
        }
    }
}
