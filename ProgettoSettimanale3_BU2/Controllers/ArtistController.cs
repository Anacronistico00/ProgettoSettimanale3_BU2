using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanale3_BU2.Data;
using ProgettoSettimanale3_BU2.DTOs.Artista;
using ProgettoSettimanale3_BU2.Models.Biglietteria;
using ProgettoSettimanale3_BU2.Services;
using System.Security.Claims;

namespace ProgettoSettimanale3_BU2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ArtistService> _logger;
        private readonly ArtistService _artistService;

        public ArtistController(ApplicationDbContext context, ILogger<ArtistService> logger, ArtistService artistService)
        {
            _context = context;
            _logger = logger;
            _artistService = artistService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddArtist([FromBody] CreateArtistRequestDto artist)
        {
            var newArtist = await _artistService.CreateArtistAsync(artist);

            if (newArtist == null)
            {
                return BadRequest(new
                {
                    message = "Failed to create a new artist!!!"
                }
                );
            }

            var result = await _artistService.AddArtistAsync(newArtist);


            return result ? Ok(new CreateArtistResponseDto()
            {
                Message = "Artist correctly added!",
            }) : BadRequest(new CreateArtistResponseDto()
            {
                Message = "Something went wrong!"
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetArtist()
        {
            try
            {

                List<Artist> artists = await _artistService.GetArtistsAsync();

                if (artists == null)
                {
                    return BadRequest(new GetArtistResponseDto()
                    {
                        Message = "Something went wrong",
                        Artists = null
                    });
                }

                if (!artists.Any())
                {
                    return NotFound(new GetArtistResponseDto()
                    {
                        Message = "No Artists found!",
                        Artists = null
                    });
                }

                var artistsDto = await _artistService.GetArtistsDtoAsync(artists);

                return Ok(new GetArtistResponseDto()
                {
                    Message = "Artist correctly get",
                    Artists = artistsDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong!");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> getArtistById(int id)
        {
            var result = await _artistService.GetArtistDtoByIdAsync(id);

            return result != null ? Ok(new GetArtistByIdResponseDto()
            {
                Message = "Artist correctly found!",
                Artist = result
            }) : BadRequest(new
            {
                message = "Something went wrong!"
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var result = await _artistService.DeleteArtistAsync(id);

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
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] UpdateArtistRequestDto studentDto)
        {
            var result = await _artistService.UpdateArtistAsync(id, studentDto);

            return result ? Ok(new { Message = "Artist correctly updated!" })
                          : BadRequest(new { Message = "Something went wrong!" });
        }
    }
}
