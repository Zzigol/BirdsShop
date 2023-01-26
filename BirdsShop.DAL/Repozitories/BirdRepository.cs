using BirdsShop.DAL.Interfaces;
using BirdsShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.DAL.Repozitories
{
    public class BirdRepository : IBirdRepository
    {
        private readonly ApplicationDbContext _db;

        public BirdRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Bird entity)
        {
            _db.Bird.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Bird entity)
        {
            _db.Bird.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Bird> Get(int id) => await _db.Bird.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Bird> GetByName(string name) => await _db.Bird.FirstOrDefaultAsync( x => x.Name == name);
        
        public async Task<List<Bird>> Select() => await _db.Bird.ToListAsync(); 
        

        
    }
}
