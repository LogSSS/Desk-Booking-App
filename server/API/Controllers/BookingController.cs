using API.Entities;
using AutoMapper;
using Core.DTOs;
using Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var bookings = await _bookingService.GetAllAsync();

            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] UpsertBookingRequest upsertBookingRequest
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(
                    string.Join(
                        ", ",
                        ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    )
                );

            var bookingDTO = _mapper.Map<BookingDTO>(upsertBookingRequest);
            var createdBooking = await _bookingService.CreateAsync(bookingDTO);

            return Ok(createdBooking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(
            int id,
            [FromBody] UpsertBookingRequest upsertBookingRequest
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(
                    string.Join(
                        ", ",
                        ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    )
                );
            var bookingDTO = _mapper.Map<BookingDTO>(upsertBookingRequest);
            var updatedBooking = await _bookingService.UpdateAsync(bookingDTO);

            if (updatedBooking == null)
                return BadRequest();
            return Ok(updatedBooking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isBookingDeleted = await _bookingService.DeleteAsync(id);
            if (!isBookingDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
