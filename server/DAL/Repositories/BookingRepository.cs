using AutoMapper;
using Core.DTOs;
using Core.IRepositories;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
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
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return null;

            return _mapper.Map<BookingDTO>(booking);
        }

        public async Task<List<BookingDTO>> GetAllAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return _mapper.Map<List<BookingDTO>>(bookings);
        }

        public async Task<BookingDTO> CreateAsync(BookingDTO booking)
        {
            var bookingEntity = _mapper.Map<Booking>(booking);
            _context.Bookings.Add(bookingEntity);
            bookingEntity.CreatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDTO>(bookingEntity);
        }

        public async Task<BookingDTO?> UpdateAsync(int id, BookingDTO booking)
        {
            var existingEntity = await _context.Bookings.FindAsync(id);
            if (existingEntity == null)
                return null;

            _mapper.Map(booking, existingEntity);
            _context.Bookings.Update(existingEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDTO>(existingEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bookingEntity = await _context.Bookings.FindAsync(id);
            if (bookingEntity == null)
                return false;

            bookingEntity.Status = Status.Deleted;
            _context.Bookings.Update(bookingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
