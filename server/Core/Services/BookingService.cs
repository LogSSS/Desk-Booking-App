using Core.DTOs;
using Core.IRepositories;
using Core.Services.IServices;
using Shared.Constants;

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

        public async Task<BookingDTO?> CreateAsync(BookingDTO booking)
        {
            if (!await IsBookingAvailable(booking))
                return null;
            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<BookingDTO?> UpdateAsync(int id, BookingDTO booking)
        {
            if (await _bookingRepository.GetByIdAsync(id) == null)
                return null;

            booking.Id = id;
            if (!await IsBookingAvailable(booking))
                return null;

            var updatedBooking = await _bookingRepository.UpdateAsync(id, booking);
            return updatedBooking;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookingRepository.DeleteAsync(id);
        }

        private async Task<bool> IsBookingAvailable(BookingDTO booking)
        {
            if (booking.EndDate <= booking.StartDate)
                return false;

            if (booking.EndDate.ToUniversalTime() <= DateTime.UtcNow)
                return false;
            var workspaceId = booking.WorkspaceId - 1;
            if (
                workspaceId
                is (int)Shared.Enums.WorkspaceType.OpenSpace
                    or (int)Shared.Enums.WorkspaceType.PrivateRooms
            )
            {
                if (
                    (booking.EndDate - booking.StartDate)
                    > TimeSpan.FromDays(Constants.OpenSpaceAndPrivateRoomMaxDays)
                )
                    return false;
            }
            else if (workspaceId is (int)Shared.Enums.WorkspaceType.MeetingRooms)
            {
                if (booking.StartDate.Date != booking.EndDate.Date)
                    return false;
            }

            if (!await _bookingRepository.IsBookingAvailable(booking))
                return false;
            return true;
        }
    }
}
