using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Biglietto;
using ProgettoSettimanale3_BU2.DTOs.Evento;
using ProgettoSettimanale3_BU2.Models.Biglietteria;
using ProgettoSettimanale3_BU2.Services;
using System.Security.Claims;

namespace ProgettoSettimanale3_BU2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TicketService> _logger;
        private readonly TicketService _ticketService;

        public TicketController(ApplicationDbContext context, ILogger<TicketService> logger, TicketService ticketService)
        {
            _context = context;
            _logger = logger;
            _ticketService = ticketService;
        }

        [HttpPost("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddTicket(int id, [FromBody] CreateTicketRequestDto ticket)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newTicket = await _ticketService.CreateTicketAsync(ticket, id, userId);

            if (newTicket == null)
            {
                return BadRequest(new
                {
                    message = "Failed to create a new ticket!!!"
                }
                );
            }

            var result = await _ticketService.AddTicketAsync(newTicket);


            return result ? Ok(new CreateTicketResponseDto()
            {
                Message = "Ticket correctly added!",
            }) : BadRequest(new CreateTicketResponseDto()
            {
                Message = "Something went wrong!"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            try
            {
                List<Ticket> tickets = await _ticketService.GetTicketsAsync();

                if (tickets == null)
                {
                    return BadRequest(new GetTicketsResponseDto()
                    {
                        Message = "Something went wrong",
                        Tickets = null
                    });
                }

                if (!tickets.Any())
                {
                    return NotFound(new GetTicketsResponseDto()
                    {
                        Message = "No ticket found!",
                        Tickets = null
                    });
                }

                var ticketsDto = await _ticketService.GetTicketsDtosAsync(tickets);

                return Ok(new GetTicketsResponseDto()
                {
                    Message = "Ticket correctly get",
                    Tickets = ticketsDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong!");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getTicketById(int id)
        {
            var result = await _ticketService.GetTicketDtoByIdAsync(id);

            return result != null ? Ok(new GetTicketByIdResponseDto()
            {
                Message = "Ticket correctly found!",
                Ticket = result
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _ticketService.DeleteTicketAsync(id);

            return result ? Ok(new
            {
                message = "Ticket correctly removed!",
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] UpdateTicketRequestDto ticketId)
        {
            var result = await _ticketService.UpdateTicketAsync(id, ticketId);

            return result ? Ok(new { Message = "Ticket correctly updated!" })
                          : BadRequest(new { Message = "Something went wrong!" });
        }
    }
}
