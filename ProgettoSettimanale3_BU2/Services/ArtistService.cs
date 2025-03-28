using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Artista;
using ProgettoSettimanale3_BU2.Models.Biglietteria;

namespace ProgettoSettimanale3_BU2.Services
{
    public class ArtistService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService(ApplicationDbContext context, ILogger<ArtistService> logger)
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

        public async Task<Artist?> CreateArtistAsync(CreateArtistRequestDto artist)
        {
            try
            {
                var newArtist = new Artist()
                {
                    Nome = artist.Nome,
                    Genere = artist.Genere,
                    Biografia = artist.Biografia,
                };
                return newArtist;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> AddArtistAsync(Artist artist)
        {
            try
            {
                _context.Artists.Add(artist);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<List<Artist>> GetArtistsAsync()
        {
            try
            {
                return await _context.Artists.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<ArtistDto>?> GetArtistsDtoAsync(List<Artist> students)
        {
            try
            {
                List<ArtistDto> ArtistsDto = students.Select(s =>
                    new ArtistDto()
                    {
                        ArtistaId = s.ArtistaId,
                        Nome = s.Nome,
                        Genere = s.Genere,
                        Biografia = s.Biografia,
                    }
                ).ToList();
                return ArtistsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<ArtistDto?> GetArtistDtoByIdAsync(int id)
        {
            try
            {
                var artist = await _context.Artists.Include(s => s.Eventi).FirstOrDefaultAsync(s => s.ArtistaId == id);

                var artistDto = new ArtistDto()
                {
                    ArtistaId = artist.ArtistaId,
                    Nome = artist.Nome,
                    Genere = artist.Genere,
                    Biografia = artist.Biografia,
                };
                return artistDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteArtistAsync(int id)
        {
            try
            {
                var existingArtist = await _context.Artists.Include(s => s.Eventi).FirstOrDefaultAsync(s => s.ArtistaId == id);

                if (existingArtist == null)
                {
                    return false;
                }

                _context.Artists.Remove(existingArtist);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateArtistAsync(int id, UpdateArtistRequestDto artistDto)
        {
            try
            {
                var existingArtist = await _context.Artists.Include(s => s.Eventi).FirstOrDefaultAsync(s => s.ArtistaId == id);

                if (existingArtist == null)
                {
                    return false;
                }

                existingArtist.Nome = artistDto.Nome;
                existingArtist.Genere = artistDto.Genere;
                existingArtist.Biografia = artistDto.Biografia;


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
