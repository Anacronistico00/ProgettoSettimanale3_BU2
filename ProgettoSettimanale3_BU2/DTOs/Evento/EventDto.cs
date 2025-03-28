using ProgettoSettimanale3_BU2.DTOs.Biglietto;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Evento
{
    public class EventDto
    {
        [Required]
        [StringLength(200)]
        public required string Titolo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(100)]
        public required string Luogo { get; set; }
        public ICollection<TicketDto>? Biglietti { get; set; }

    }
}
