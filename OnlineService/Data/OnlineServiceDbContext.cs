using Microsoft.EntityFrameworkCore;
using OnlineService.Models;

namespace OnlineService.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=onlineserver;Username=adilet;Password=qwertyui;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Categoria)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Specialists)
                .WithMany(sp => sp.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "ServiceSpecialist",
                    j => j.HasOne<Specialist>().WithMany().OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Service>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Orders)
                .WithOne(o => o.Service)
                .HasForeignKey(o => o.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Specialist>()
                .HasMany(s => s.Orders)
                .WithOne(o => o.Specialist)
                .HasForeignKey(o => o.SpecialistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


