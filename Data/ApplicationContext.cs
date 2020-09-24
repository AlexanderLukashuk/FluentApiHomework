using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Laptop> Laptops { get; set; }

        private readonly string connectionString;
        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;

            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Пользователь")
                .HasKey(user => user.Id)
                .HasName("Идентификатор");

            modelBuilder.Entity<User>()
                .Property(user => user.Password)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("Пароль");

            modelBuilder.Entity<User>()
                .Property(user => user.Phone)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnName("Номер телефона");

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("Электронная почта");
            
            modelBuilder.Entity<User>()
                .HasOne(user => user.Profile)
                .WithOne(profile => profile.User)
                .HasForeignKey("Profile");

            modelBuilder.Entity<Profile>()
                .HasOne(user => user.User)
                .WithOne(profile => profile.Profile)
                .HasForeignKey("User");

            modelBuilder.Entity<Profile>()
                .Property(profile => profile.Name)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Имя");

            modelBuilder.Entity<Laptop>()
                .ToTable("Ноутбук")
                .HasKey(laptop => laptop.Id)
                .HasName("Идентификатор");

            modelBuilder.Entity<Laptop>()
                .Property(laptop => laptop.Name)
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("Товар");

            modelBuilder.Entity<Laptop>()
                .Property(laptop => laptop.Model)
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnName("Модель");

            modelBuilder.Entity<Laptop>()
                .Property(laptop => laptop.Manufacturer)
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("Производитель");
            base.OnModelCreating(modelBuilder);
        }
    }
}