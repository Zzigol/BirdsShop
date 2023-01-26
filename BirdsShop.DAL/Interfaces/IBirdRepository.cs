using BirdsShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.DAL.Interfaces
{
    public interface IBirdRepository:IBaseRepository<Bird>
    {
        Task<Bird> GetByName(string name);

    }
}
