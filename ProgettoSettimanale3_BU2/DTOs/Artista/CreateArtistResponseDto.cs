using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Artista
{
    public class CreateArtistResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
