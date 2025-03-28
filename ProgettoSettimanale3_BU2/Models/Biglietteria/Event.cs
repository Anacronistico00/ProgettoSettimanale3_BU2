using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.Models.Biglietteria
{
    public class Event
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

        [ForeignKey("Artista")]
        public int ArtistaId { get; set; }

        public Artist Artista { get; set; }

        public ICollection<Ticket>? Biglietti { get; set; }
    }
}
