using ProgettoSettimanale3_BU2.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.Models.Biglietteria
{
    public class Ticket
    {
        [Key]
        public int BigliettoId { get; set; }

        [ForeignKey("Evento")]
        public int EventoId { get; set; }

        public Event Evento { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }
    }
}
