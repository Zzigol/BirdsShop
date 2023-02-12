using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Enum;
using BirdsShop.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbSet<Bird> Birds { get; set; } = null!;
    
        public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasData(new User
            {
                Id = 1,
                Name = "ITHomester",
                Password = HashPasswordHelper.HashPassowrd("123456"),
                Role = Role.Admin
            });

            builder.ToTable("Users").HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        });
    }
}
}
