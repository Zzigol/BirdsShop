using BirdsShop.DAL.Interfaces;
using BirdsShop.Domain.Entity;
using BirdsShop.Domain.ViewModels.Bird;
using BirdsShop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdsShop.Controllers
{
    public class BirdController : Controller
    {
        private readonly IBirdService birdService;

        public BirdController(IBirdService birdService)
        {
            this.birdService = birdService;
        }

        // GET: BirdController
        [HttpGet]
        public async Task<IActionResult> GetBirds()
        {
            var response = await birdService.GetBirds();
            
            if (response.StatusCode== Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList()) ;
            }
            return View("Error", $"{response.Description}");
        }
        

        [HttpGet]
        public async Task<IActionResult> GetBird(int id)
        {
            var response = await birdService.GetBird(id);
            if (response.StatusCode==Domain.Enum.StatusCode.OK) 
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await birdService.DeleteBird(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetBirds");
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) 
            {
                return View();
            }
            var response = await birdService.GetBird(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(BirdViewModel model)
        {
            if (ModelState.IsValid) 
            { 
                if (model.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                    }
                    await birdService.Create(model, imageData);                
                }
                else 
                {
                    await birdService.Edit(model.Id, model);
                }
            }
            return View();
        }
    }
    
}
