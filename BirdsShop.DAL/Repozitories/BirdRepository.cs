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
    public class BirdRepository : IBaseRepository<Bird>
    {
        private readonly ApplicationDbContext _db;

        public BirdRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Bird entity)
        {
            await _db.Birds.AddAsync(entity);
            await _db.SaveChangesAsync();            
        }

        public async Task Delete(Bird entity)
        {
            _db.Birds.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Bird> GetAll()
        {
            return _db.Birds;
        }

        public async Task<Bird> Update(Bird entity)
        {
            _db.Birds.Update(entity);
            await _db.SaveChangesAsync();  
            return entity;
        }
    }
}
