using Microsoft.AspNetCore.Identity;

namespace ProgettoSettimanale3_BU2.Models.Auth
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
