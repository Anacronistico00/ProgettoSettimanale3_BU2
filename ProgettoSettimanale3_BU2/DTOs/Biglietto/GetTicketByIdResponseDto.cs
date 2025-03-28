using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Biglietto
{
    public class GetTicketByIdResponseDto
    {
        [Required]
        public required string Message { get; set; }

        public GetTicketDto Ticket { get; set; }
    }
}
