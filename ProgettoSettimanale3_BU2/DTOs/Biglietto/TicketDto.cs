using ProgettoSettimanale3_BU2.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoSettimanale3_BU2.DTOs.Biglietto
{
    public class TicketDto
    {
        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }
    }
}
