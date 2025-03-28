using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Artista
{
    public class GetArtistResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public List<ArtistDto> Artists { get; set; }
    }
}
