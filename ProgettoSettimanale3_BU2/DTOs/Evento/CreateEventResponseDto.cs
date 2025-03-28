using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Evento
{
    public class CreateEventResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
