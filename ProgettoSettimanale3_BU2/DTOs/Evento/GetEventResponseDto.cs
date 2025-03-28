using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Evento
{
    public class GetEventResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]

        public List<GetEventDto>? Events { get; set; }
    }
}
