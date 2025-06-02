using Core.DTOs;
using Core.IRepositories;
using Core.Services.IServices;

namespace Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingDTO?> GetByIdAsync(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task<List<BookingDTO>> GetAllAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<BookingDTO> CreateAsync(BookingDTO booking)
        {
            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<BookingDTO?> UpdateAsync(BookingDTO booking)
        {
            return await _bookingRepository.UpdateAsync(booking);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookingRepository.DeleteAsync(id);
        }
    }
}
