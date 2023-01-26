using BirdsShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public DbSet<Bird> Bird { get; set; } = null!;
    }
}
