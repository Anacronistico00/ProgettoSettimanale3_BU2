using ProgettoSettimanale3_BU2.Models.Auth;
using ProgettoSettimanale3_BU2.Models.Biglietteria;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Biglietto
{
    public class UpdateTicketRequestDto
    {
        public int EventoId { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }
    }
}
