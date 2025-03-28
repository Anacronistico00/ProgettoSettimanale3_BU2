using ProgettoSettimanale3_BU2.DTOs.Artista;
using ProgettoSettimanale3_BU2.Models.Biglietteria;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Evento
{
    public class EventTicketDto
    {
        [Required]
        [StringLength(200)]
        public required string Titolo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(100)]
        public required string Luogo { get; set; }

        public ArtistDto Artista { get; set; }
    }
}
