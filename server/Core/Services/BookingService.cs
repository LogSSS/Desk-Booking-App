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

        public async Task<BookingDTO> CreateAsync(BookingDTO booking)
        {
            await IsBookingAvailable(booking);
            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<BookingDTO?> UpdateAsync(int id, BookingDTO booking)
        {
            if (await _bookingRepository.GetByIdAsync(id) == null)
                return null;

            booking.Id = id;
            await IsBookingAvailable(booking);

            var updatedBooking = await _bookingRepository.UpdateAsync(id, booking);
            return updatedBooking;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookingRepository.DeleteAsync(id);
        }

        private async Task IsBookingAvailable(BookingDTO booking)
        {
            if (booking.EndDate <= booking.StartDate)
                throw new ArgumentException("End date must be after start date.");

            if (booking.StartDate.ToUniversalTime() <= DateTime.UtcNow)
                throw new ArgumentException("Start date must be in the future.");

            if (
                booking.WorkspaceId
                is (int)Shared.Enums.WorkspaceType.OpenSpace
                    or (int)Shared.Enums.WorkspaceType.PrivateRooms
            )
            {
                if (
                    (booking.EndDate - booking.StartDate)
                    > TimeSpan.FromDays(Constants.OpenSpaceAndPrivateRoomMaxDays)
                )
                    throw new ArgumentException(
                        $"Booking duration must be at max {Constants.OpenSpaceAndPrivateRoomMaxDays} days."
                    );
            }
            else if (booking.WorkspaceId is (int)Shared.Enums.WorkspaceType.MeetingRooms)
            {
                if (booking.StartDate.Date != booking.EndDate.Date)
                    throw new ArgumentException(
                        "Meeting room bookings must start and end on the same day."
                    );
            }

            if (!await _bookingRepository.IsBookingAvailable(booking))
                throw new InvalidOperationException("Booking overlaps with an existing booking.");
        }
    }
}
