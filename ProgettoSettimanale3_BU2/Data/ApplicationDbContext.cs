using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale3_BU2.Models.Auth;
using ProgettoSettimanale3_BU2.Models.Biglietteria;

namespace ProgettoSettimanale3_BU2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.User).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.UserId).IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.Role).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.RoleId).IsRequired(true);

            modelBuilder.Entity<Artist>().HasMany(a => a.Eventi).WithOne(e => e.Artista).HasForeignKey(e => e.ArtistaId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>().HasOne(e => e.Artista).WithMany(a => a.Eventi).HasForeignKey(e => e.ArtistaId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Event>().HasMany(e => e.Biglietti).WithOne(b => b.Evento).HasForeignKey(b => b.EventoId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>().HasOne(b => b.Evento).WithMany(e => e.Biglietti).HasForeignKey(b => b.EventoId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ticket>().HasOne(b => b.User).WithMany(u => u.Biglietti).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Biglietti).WithOne(b => b.User).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Cascade);

            var adminId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = adminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminId
                },
                new ApplicationRole
                {
                    Id = userId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = userId
                }
            );
        }
    }
}
