using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Biglietto
{
    public class GetTicketsResponseDto
    {
        [Required]
        public required string Message { get; set; }

        public List<GetTicketDto> Tickets { get; set; }
    }
}
