using BirdsShop.DAL.Interfaces;
using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Enum;
using BirdsShop.Domain.Response;
using BirdsShop.Domain.ViewModels.Bird;
using BirdsShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly IBaseRepository<Bird> _birdRepository;

        public BirdService(IBaseRepository<Bird> birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<IBaseResponse<Bird>> Create(BirdViewModel birdViewModel, byte[] imageData)
        {
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
                return new BaseResponse<Bird>()
                {
                    StatusCode = StatusCode.OK,
                    Data = bird
                };    

            }
            catch (Exception ex)
            {
                return new BaseResponse<Bird>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError

                };
            }

        }
        public async Task<IBaseResponse<bool>> DeleteBird(int id)
        { 
            try
            {
                var bird = await _birdRepository.GetAll().FirstOrDefaultAsync(x=>x.Id == id);
                if (bird == null) 
                {
                    return new BaseResponse<bool>() 
                    { 
                        Data= false,
                        Description = "Попугай не найден",
                        StatusCode = StatusCode.BirdNotFound
                    };                    
                }
                await _birdRepository.Delete(bird);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
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
            try
            {
                var bird = await _birdRepository.GetAll().FirstOrDefaultAsync(x=>x.Id == id);
                if (bird == null)
                {
                    return new BaseResponse<Bird>()
                    {
                        Description = "Попугай не найден",
                        StatusCode = StatusCode.BirdNotFound
                    };
                }
                bird.Name = model.Name;
                bird.Description = model.Description;
                bird.Size = model.Size;
                bird.Price = model.Price;
                bird.DataCreate = DateTime.Now;
                //bird.Species = (SpeciesBirds)Convert.ToInt32(model.Species);
                await _birdRepository.Update(bird);

                return new BaseResponse<Bird>()
                {
                    Data = bird,
                    StatusCode = StatusCode.OK
                };

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
            try
            {
                var bird = await _birdRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (bird == null)
                {
                    return new BaseResponse<BirdViewModel>()
                    {
                        Description = "Попугай не найден",
                        StatusCode = StatusCode.BirdNotFound
                    };
                } 
                
                var data = new BirdViewModel()
                {
                    DataCreate = bird.DataCreate,
                    Description = bird.Description,
                    Species = bird.Species.ToString(),
                    Size = bird.Size,
                    Name = bird.Name
                };
                return new BaseResponse<BirdViewModel>()
                {
                    Data = data,
                    StatusCode = StatusCode.OK
                };
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
            try
            {
                var bird = await _birdRepository.GetAll().FirstOrDefaultAsync(x=>x.Name == name);
                if (bird == null)
                {
                    return new BaseResponse<Bird>()
                    {
                        Description = "Попугай не найден",
                        StatusCode = StatusCode.BirdNotFound
                    };
                }
                return new BaseResponse<Bird>()
                {
                    Data = bird,
                    StatusCode = StatusCode.BirdNotFound
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Bird>()
                {
                    Description = $"[GetBirdByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }
        public async Task<IBaseResponse<IEnumerable<Bird>>> GetBirds()

        {
            try 
            {
                var birds = _birdRepository.GetAll();
                if (!birds.Any())
                {
                    return new BaseResponse<IEnumerable<Bird>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<IEnumerable<Bird>>()
                {
                    Data = birds,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex) 
            { 
                return new BaseResponse<IEnumerable<Bird>>()
                { 
                    Description = $"[GetBirds] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };            
            }
        }
    }
}
