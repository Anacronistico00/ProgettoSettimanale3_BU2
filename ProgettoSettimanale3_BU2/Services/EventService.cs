using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Evento;
using ProgettoSettimanale3_BU2.Models.Biglietteria;

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

        public async Task<Event?> CreateEventAsync(CreateEventRequestDto artist)
        {
            try
            {
                var newEvent = new Event()
                {
                    Titolo = artist.Titolo,
                    Data = artist.Data,
                    Luogo = artist.Luogo,
                    ArtistaId = artist.ArtistaId,
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
    }
}
