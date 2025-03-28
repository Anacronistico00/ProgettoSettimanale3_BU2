using System.ComponentModel.DataAnnotations;
using ProgettoSettimanale3_BU2.DTOs.Artista;
using ProgettoSettimanale3_BU2.DTOs.Biglietto;

namespace ProgettoSettimanale3_BU2.DTOs.Evento
{
    public class GetEventDto
    {
        [Key]
        public int EventoId { get; set; }

        [Required]
        [StringLength(200)]
        public required string Titolo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(100)]
        public required string Luogo { get; set; }

        public int ArtistaId { get; set; }

        public ArtistDto Artista { get; set; }
    }
}
