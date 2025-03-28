using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.DTOs.Artista
{
    public class CreateArtistRequestDto
    {
        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public required string Genere { get; set; }

        [Required]
        [StringLength(255)]
        public required string Biografia { get; set; }
    }
}
