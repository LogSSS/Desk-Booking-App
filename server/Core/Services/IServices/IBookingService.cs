using Core.DTOs;

namespace Core.Services.IServices
{
    public interface IBookingService
    {
        Task<BookingDTO?> GetByIdAsync(int id);
        Task<List<BookingDTO>> GetAllAsync();
        Task<BookingDTO> CreateAsync(BookingDTO booking);
        Task<BookingDTO?> UpdateAsync(BookingDTO booking);
        Task<bool> DeleteAsync(int id);
    }
}
