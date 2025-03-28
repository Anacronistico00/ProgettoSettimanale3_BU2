using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Evento
{
    public class GetEventByIdResponseDto
    {
        [Required]
        public required string Message { get; set; }

        public GetEventDto Event { get; set; }
    }
}
