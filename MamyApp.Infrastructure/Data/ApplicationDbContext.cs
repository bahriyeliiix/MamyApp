using MamyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MamyApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Örnek olarak User modeli ekliyoruz. Diğer modelleri burada tanımlayabilirsiniz.
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                // Username alanı boş olamaz ve 50 karakteri aşamaz.
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                // PasswordHash alanı boş olamaz.
                entity.Property(e => e.PasswordHash)
                    .IsRequired();

                // Email alanı boş olamaz ve 100 karakteri aşamaz.
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                // IsEmailVerified varsayılan değeri false.
                entity.Property(e => e.IsEmailVerified)
                    .HasDefaultValue(false);

                // LastLoginDate için, NULL değeri de kabul edilebilir.
                entity.Property(e => e.LastLoginDate)
                    .IsRequired(false); // Nullable olduğu için IsRequired(false) kullanıldı.
            });




        }

    }
}
