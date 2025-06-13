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
            //check if availability of the booking (check time)
            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<BookingDTO?> UpdateAsync(int id, BookingDTO booking)
        {
            //check if availability of the booking (check time)
            var updatedBooking = await _bookingRepository.UpdateAsync(id, booking);
            return updatedBooking;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookingRepository.DeleteAsync(id);
        }
    }
}
