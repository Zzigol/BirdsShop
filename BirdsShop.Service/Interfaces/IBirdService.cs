using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.Service.Interfaces
{
    public interface IBirdService
    {
        Task<IBaseResponse<IEnumerable<Bird>>> GetBird();
    }
}
