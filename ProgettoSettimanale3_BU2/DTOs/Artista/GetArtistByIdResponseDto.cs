using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Artista
{
    public class GetArtistByIdResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required GetArtistDto Artist { get; set; }
    }
}
