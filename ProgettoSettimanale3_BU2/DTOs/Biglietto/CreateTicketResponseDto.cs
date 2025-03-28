using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Biglietto
{
    public class CreateTicketResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
