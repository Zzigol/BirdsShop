using BirdsShop.DAL.Interfaces;
using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Enum;
using BirdsShop.Domain.Response;
using BirdsShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.Service.Implementations
{
    public class BirdService : IBirdService
    {
        private readonly IBirdRepository _birdRepository;

        public BirdService(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Bird>>> GetBird()

        {
            var baseResponse=new BaseResponse<IEnumerable<Bird>>();
            try 
            {
                var birds = await _birdRepository.Select();
                if (birds.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK; 
                    return baseResponse;
                }

                baseResponse.Data = birds;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex) 
            { 
                return new BaseResponse<IEnumerable<Bird>>()
                { 
                    Description = $"[GetBird] : {ex.Message}"               
                };
            
            }
        }
    }
}
