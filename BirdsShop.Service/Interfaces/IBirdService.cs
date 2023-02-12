using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Enum;
using BirdsShop.Domain.Response;
using BirdsShop.Domain.ViewModels.Bird;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BirdsShop.Service.Interfaces
{
    public interface IBirdService
    {
        Task<IBaseResponse<IEnumerable<Bird>>> GetBirds();
        Task<IBaseResponse<BirdViewModel>> GetBird(int id);
        Task<IBaseResponse<Bird>> Create(BirdViewModel bird, byte[] imageData);
        
        Task<IBaseResponse<bool>> DeleteBird(int id);
        
        Task<IBaseResponse<Bird>> GetBirdByName(string name);
        Task<IBaseResponse<Bird>> Edit(int id, BirdViewModel model);

    }
}
