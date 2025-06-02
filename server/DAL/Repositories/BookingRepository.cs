using AutoMapper;
using Core.DTOs;
using Core.IRepositories;
using DAL.Data;
using DAL.Entities;

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
            throw new NotImplementedException("This method is not implemented yet.");
        }

        public async Task<BookingDTO> CreateAsync(BookingDTO booking)
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }

        public async Task<BookingDTO?> UpdateAsync(BookingDTO booking)
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }
    }
}
