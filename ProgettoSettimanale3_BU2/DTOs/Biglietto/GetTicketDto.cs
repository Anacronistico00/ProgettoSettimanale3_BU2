using ProgettoSettimanale3_BU2.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProgettoSettimanale3_BU2.DTOs.Evento;

namespace ProgettoSettimanale3_BU2.DTOs.Biglietto
{
    public class GetTicketDto
    {
        [Key]
        public int BigliettoId { get; set; }

        [ForeignKey("Evento")]
        public int EventoId { get; set; }

        public EventTicketDto Evento { get; set; }

        public string UserId { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }
    }
}
