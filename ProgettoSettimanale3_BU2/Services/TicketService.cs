using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Artista;
using ProgettoSettimanale3_BU2.DTOs.Biglietto;
using ProgettoSettimanale3_BU2.DTOs.Evento;
using ProgettoSettimanale3_BU2.Models.Biglietteria;

namespace ProgettoSettimanale3_BU2.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TicketService> _logger;

        public TicketService(ApplicationDbContext context, ILogger<TicketService> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<Ticket?> CreateTicketAsync(CreateTicketRequestDto ticket, int id, string userId)
        {
            try
            {
                var newTicket = new Ticket()
                {
                    UserId = userId,
                    EventoId = id,
                    DataAcquisto = ticket.DataAcquisto,
                };
                return newTicket;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> AddTicketAsync(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ticket: {Message}", ex.Message);
                return false;
            }
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            try
            {
                return await _context.Tickets.Include(e => e.Evento).ThenInclude(a => a.Artista).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<GetTicketDto>?> GetTicketsDtosAsync(List<Ticket> tickets)
        {
            try
            {
                List<GetTicketDto> ticketsDtos = tickets.Select(e =>
                new GetTicketDto()
                {
                    BigliettoId = e.BigliettoId,
                    EventoId = e.EventoId,
                    UserId = e.UserId,
                    DataAcquisto = e.DataAcquisto,
                    Evento = new EventTicketDto()
                    {
                        Titolo = e.Evento.Titolo,
                        Data = e.Evento.Data,
                        Luogo = e.Evento.Luogo,
                        Artista = new ArtistDto()
                        {
                            Nome = e.Evento.Artista.Nome,
                            Genere = e.Evento.Artista.Genere,
                            Biografia = e.Evento.Artista.Biografia,
                        }
                    }
                }).ToList();

                return ticketsDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<GetTicketDto?> GetTicketDtoByIdAsync(int id)
        {
            try
            {
                var ticketById = await _context.Tickets.Include(e => e.Evento).ThenInclude(a => a.Artista).FirstOrDefaultAsync(s => s.BigliettoId == id);

                if (ticketById != null)
                {
                    var ticketDto = new GetTicketDto()
                    {
                        BigliettoId = ticketById.BigliettoId,
                        EventoId = ticketById.EventoId,
                        UserId = ticketById.UserId,
                        DataAcquisto = ticketById.DataAcquisto,
                        Evento = new EventTicketDto()
                        {
                            Titolo = ticketById.Evento.Titolo,
                            Data = ticketById.Evento.Data,
                            Luogo = ticketById.Evento.Luogo,
                            Artista = new ArtistDto()
                            {
                                Nome = ticketById.Evento.Artista.Nome,
                                Genere = ticketById.Evento.Artista.Genere,
                                Biografia = ticketById.Evento.Artista.Biografia,
                            }
                        }
                    };
                    return ticketDto;
                }

                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            try
            {
                var existingTicket = await _context.Tickets.FirstOrDefaultAsync(s => s.BigliettoId == id);

                if (existingTicket == null)
                {
                    return false;
                }

                _context.Tickets.Remove(existingTicket);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateTicketAsync(int id, UpdateTicketRequestDto ticketDto)
        {
            try
            {
                var existingTicket = await _context.Tickets.FirstOrDefaultAsync(s => s.BigliettoId == id);

                if (existingTicket == null)
                {
                    return false;
                }

                existingTicket.EventoId = ticketDto.EventoId;
                existingTicket.DataAcquisto = ticketDto.DataAcquisto;


                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
