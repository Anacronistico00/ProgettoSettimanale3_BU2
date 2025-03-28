using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Artista;
using ProgettoSettimanale3_BU2.DTOs.Biglietto;
using ProgettoSettimanale3_BU2.DTOs.Evento;
using ProgettoSettimanale3_BU2.Models.Biglietteria;
using Serilog;

namespace ProgettoSettimanale3_BU2.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventService> _logger;

        public EventService(ApplicationDbContext context, ILogger<EventService> logger)
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

        public async Task<Event?> CreateEventAsync(CreateEventRequestDto artist, int id)
        {
            try
            {
                var newEvent = new Event()
                {
                    Titolo = artist.Titolo,
                    Data = artist.Data,
                    Luogo = artist.Luogo,
                    ArtistaId = id,
                };
                return newEvent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> AddEventAsync(Event addEvent)
        {
            try
            {
                _context.Events.Add(addEvent);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            try
            {
                return await _context.Events.Include(b => b.Biglietti).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<GetEventDto>?> GetEventsDtosAsync(List<Event> events)
        {
            try
            {
                List<GetEventDto> eventDtos = events.Select(e =>
                new GetEventDto()
                {
                    EventoId = e.EventoId,
                    Titolo = e.Titolo,
                    Data = e.Data,
                    Luogo= e.Luogo,
                    ArtistaId = e.ArtistaId,
                    Biglietti = e.Biglietti != null
                        ? e.Biglietti.Select(b => new TicketDto()
                        {
                            UserId = b.UserId,
                            DataAcquisto = b.DataAcquisto,
                        }).ToList()
                        : null,
                }).ToList();

                return eventDtos;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<GetEventDto?> GetEventDtoByIdAsync(int id)
        {
            try
            {
                var eventById = await _context.Events.Include(b => b.Biglietti).FirstOrDefaultAsync(s => s.EventoId == id);
                if(eventById != null)
                {
                    var eventDto = new GetEventDto()
                    {
                        EventoId = eventById.EventoId,
                        Titolo = eventById.Titolo,
                        Data = eventById.Data,
                        Luogo = eventById.Luogo,
                        ArtistaId = eventById.ArtistaId,
                        Biglietti = eventById.Biglietti != null
                        ? eventById.Biglietti.Select(b => new TicketDto()
                        {
                            UserId = b.UserId,
                            DataAcquisto = b.DataAcquisto,
                        }).ToList()
                        : null,
                    };
                return eventDto;
                }

                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            try
            {
                var existingEvent = await _context.Events.FirstOrDefaultAsync(s => s.EventoId == id);

                if (existingEvent == null)
                {
                    return false;
                }

                _context.Events.Remove(existingEvent);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateEventAsync(int id, UpdateEventRequestDto eventDto)
        {
            try
            {
                var existingEvent = await _context.Events.FirstOrDefaultAsync(s => s.EventoId == id);

                if (existingEvent == null)
                {
                    return false;
                }

                existingEvent.Titolo = eventDto.Titolo;
                existingEvent.Data = eventDto.Data;
                existingEvent.Luogo = eventDto.Luogo;
                existingEvent.ArtistaId = eventDto.ArtistaId;


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
