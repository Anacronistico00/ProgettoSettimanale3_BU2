using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Artista;
using ProgettoSettimanale3_BU2.DTOs.Evento;
using ProgettoSettimanale3_BU2.Models.Biglietteria;
using ProgettoSettimanale3_BU2.Services;
using System.Security.Claims;

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

        [HttpPost("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddArtist(int id, [FromBody] CreateEventRequestDto Event)
        {
            var newEvent = await _eventService.CreateEventAsync(Event, id);

            if (newEvent == null)
            {
                return BadRequest(new
                {
                    message = "Failed to create a new event!!!"
                }
                );
            }

            var result = await _eventService.AddEventAsync(newEvent);


            return result ? Ok(new CreateEventResponseDto()
            {
                Message = "event correctly added!",
            }) : BadRequest(new CreateEventResponseDto()
            {
                Message = "Something went wrong!"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetEvent()
        {
            try
            {

                List<Event> events = await _eventService.GetEventsAsync();

                if (events == null)
                {
                    return BadRequest(new GetEventResponseDto()
                    {
                        Message = "Something went wrong",
                        Events = null
                    });
                }

                if (!events.Any())
                {
                    return NotFound(new GetEventResponseDto()
                    {
                        Message = "No Artists found!",
                        Events = null
                    });
                }

                var eventsDto = await _eventService.GetEventsDtosAsync(events);

                return Ok(new GetEventResponseDto()
                {
                    Message = "Artist correctly get",
                    Events = eventsDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong!");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getEventById(int id)
        {
            var result = await _eventService.GetEventDtoByIdAsync(id);

            return result != null ? Ok(new GetEventByIdResponseDto()
            {
                Message = "Artist correctly found!",
                Event = result
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEventAsync(id);

            return result ? Ok(new
            {
                message = "Artist correctly removed!",
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] UpdateEventRequestDto eventDto)
        {
            var result = await _eventService.UpdateEventAsync(id, eventDto);

            return result ? Ok(new { Message = "Artist correctly updated!" })
                          : BadRequest(new { Message = "Something went wrong!" });
        }
    }
}
