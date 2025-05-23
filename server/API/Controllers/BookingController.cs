using API.Entities;
using AutoMapper;
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
            throw new NotImplementedException("This method is not implemented yet.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] UpsertBookingRequest upsertBookingRequest
        )
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(
            int id,
            [FromBody] UpsertBookingRequest upsertBookingRequest
        )
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }
    }
}
