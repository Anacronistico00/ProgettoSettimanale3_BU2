using Microsoft.AspNetCore.Identity;
using ProgettoSettimanale3_BU2.Models.Biglietteria;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale3_BU2.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required DateOnly BirthDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Ticket> Biglietti { get; set; }
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
