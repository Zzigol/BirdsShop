using BirdsShop.DAL.Interfaces;
using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Enum;
using BirdsShop.Domain.Response;
using BirdsShop.Domain.ViewModels.Bird;
using BirdsShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BirdsShop.Service.Implementations
{
    public class BirdService : IBirdService
    {
        private readonly IBirdRepository _birdRepository;

        public BirdService(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<IBaseResponse<BirdViewModel>> CreateBird(BirdViewModel birdViewModel)
        {
            var baseResponse = new BaseResponse<BirdViewModel>();
            try
            {
                var bird = new Bird()
                {
                    Name = birdViewModel.Name,                    
                    Description = birdViewModel.Description,
                    Size = birdViewModel.Size,
                    Price = birdViewModel.Price,
                    DataCreate = DateTime.Now,                    
                    Species = (SpeciesBirds)Convert.ToInt32(birdViewModel.Species)

                };
                await _birdRepository.Create(bird);
                return baseResponse;    

            }
            catch (Exception ex)
            {
                return new BaseResponse<BirdViewModel>()
                {
                    Description = $"[CreateBird] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError

                };
            }

        }
        public async Task<IBaseResponse<bool>> DeleteBird(int id)
        {
            var baseResponse = new BaseResponse<bool>() 
            {
                Data= true
            };
            try
            {
                var bird = await _birdRepository.Get(id);
                if (bird == null) 
                {
                    baseResponse.Description = "Попугай не найден";
                    baseResponse.StatusCode = StatusCode.BirdNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                await _birdRepository.Delete(bird);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteBird] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                    
                };
            }

        }

        public async Task<IBaseResponse<Bird>> Edit(int id, BirdViewModel model)
        {
            var baseResponse = new BaseResponse<Bird>();
            try
            {
                var bird = await _birdRepository.Get(id);
                if (bird == null)
                {
                    baseResponse.Description = "Попугай не найден";
                    baseResponse.StatusCode = StatusCode.BirdNotFound;
                    return baseResponse;
                }
                bird.Name = model.Name;
                bird.Description = model.Description;
                bird.Size = model.Size;
                bird.Price = model.Price;
                bird.DataCreate = DateTime.Now;
                //bird.Species = (SpeciesBirds)Convert.ToInt32(model.Species);
                await _birdRepository.Update(bird);
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Bird>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<BirdViewModel>> GetBird(int id) 
        { 
            var baseResponse = new BaseResponse<BirdViewModel>();
            try
            {
                var bird = await _birdRepository.Get(id);
                if (bird == null)
                {
                    baseResponse.Description = "Попугай не найден";
                    baseResponse.StatusCode = StatusCode.BirdNotFound;
                    return baseResponse;
                }
                var data = new BirdViewModel()
                {
                    DataCreate = bird.DataCreate,
                    Description = bird.Description,
                    Species = bird.Species.ToString(),
                    Size = bird.Size,
                    Name = bird.Name
                };
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<BirdViewModel>()
                {
                    Description = $"[GetBird] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        
        public async Task<IBaseResponse<Bird>> GetBirdByName(string name)
        {
            var baseResponse = new BaseResponse<Bird>();
            try
            {
                var bird = await _birdRepository.GetByName(name);
                if (bird == null)
                {
                    baseResponse.Description = "Попугай не найден";
                    baseResponse.StatusCode = StatusCode.BirdNotFound;
                    return baseResponse;
                }
                baseResponse.Data = bird;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Bird>()
                {
                    Description = $"[GetBirdByName] : {ex.Message}"
                };
            }

        }
        public async Task<IBaseResponse<IEnumerable<Bird>>> GetBirds()

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
                    Description = $"[GetBirds] : {ex.Message}"               
                };
            
            }
        }
    }
}
