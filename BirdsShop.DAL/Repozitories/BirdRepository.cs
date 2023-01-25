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

        public bool Create(Bird entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Bird entity)
        {
            throw new NotImplementedException();
        }

        public Bird Get(int id)
        {
            throw new NotImplementedException();
        }

        public Bird GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bird>> Select()
        {
            return await _db.Bird.ToListAsync();  
        }

        
    }
}
