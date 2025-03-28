using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Evento;
using ProgettoSettimanale3_BU2.Services;

namespace ProgettoSettimanale3_BU2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventService> _logger;
        private readonly EventService _eventService;

        public EventController(ApplicationDbContext context, ILogger<EventService> logger, EventService eventService)
        {
            _context = context;
            _logger = logger;
            _eventService = eventService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddArtist([FromBody] CreateEventRequestDto Event)
        {
            var newEvent = await _eventService.CreateEventAsync(Event);

            if (newEvent == null)
            {
                return BadRequest(new
                {
                    message = "Failed to create a new student!!!"
                }
                );
            }

            var result = await _eventService.AddEventAsync(newEvent);


            return result ? Ok(new CreateEventResponseDto()
            {
                Message = "Artist correctly added!",
            }) : BadRequest(new CreateEventResponseDto()
            {
                Message = "Something went wrong!"
            });
        }
    }
}
