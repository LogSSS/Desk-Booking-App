using AutoMapper;
using Core.DTOs;
using Core.IRepositories;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Constants;
using Shared.Enums;

namespace DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public BookingRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingDTO?> GetByIdAsync(int id)
        {
            var booking = await _context
                .Bookings.Include(b => b.Workspace)
                .ThenInclude(b => b.CapacityOptions)
                .ThenInclude(b => b.RoomAvailabilities)
                .FirstOrDefaultAsync(b => b.Id == id && b.Status == Status.Active);

            if (booking == null)
                return null;

            return _mapper.Map<BookingDTO>(booking);
        }

        public async Task<List<BookingDTO>> GetAllAsync()
        {
            var bookings = await _context
                .Bookings.Where(b =>
                    b.OwnerId == Constants.SuperUserId && b.Status == Status.Active
                )
                .Include(b => b.Workspace)
                .ThenInclude(b => b.Images)
                .ToListAsync();
            return _mapper.Map<List<BookingDTO>>(bookings);
        }

        public async Task<BookingDTO> CreateAsync(BookingDTO booking)
        {
            var bookingEntity = _mapper.Map<Booking>(booking);
            _context.Bookings.Add(bookingEntity);
            bookingEntity.CreatedAt = DateTime.UtcNow;
            bookingEntity.OwnerId = Constants.SuperUserId;
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDTO>(bookingEntity);
        }

        public async Task<BookingDTO?> UpdateAsync(int id, BookingDTO booking)
        {
            var existingEntity = await _context.Bookings.FindAsync(id);
            if (existingEntity == null)
                return null;

            booking.Id = id;

            _mapper.Map(booking, existingEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDTO>(existingEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bookingEntity = await _context.Bookings.FindAsync(id);
            if (bookingEntity == null)
                return false;

            bookingEntity.Status = Status.Cancelled;
            _context.Bookings.Update(bookingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsBookingAvailable(BookingDTO booking)
        {
            var existingBookings = await _context
                .Bookings.Where(b =>
                    b.WorkspaceId == booking.WorkspaceId
                    && b.RoomSize == booking.RoomSize
                    && b.Status == Status.Active
                    && b.Id != booking.Id
                )
                .ToListAsync();

            foreach (var existing in existingBookings)
                if (booking.StartDate < existing.EndDate && booking.EndDate > existing.StartDate)
                    return false;

            return true;
        }
    }
}
