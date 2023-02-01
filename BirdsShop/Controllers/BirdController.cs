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
        public async Task<ActionResult> GetBirds()
        {
            var response = await birdService.GetBirds();
            
            if (response.StatusCode== Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList()) ;
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<ActionResult> GetBird(int id)
        {
            var response = await birdService.GetBird(id);
            if (response.StatusCode==Domain.Enum.StatusCode.OK) 
            {
                return View(response);
            }
            return RedirectToAction("Error");
        }

        [Authorize (Roles ="Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await birdService.DeleteBird(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetBirds");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Save(int id)
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
            return RedirectToAction("Error");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Save(BirdViewModel model)
        {
            if (ModelState.IsValid) 
            { 
                if (model.Id == 0) 
                { 
                    await birdService.CreateBird(model);                
                }
                else 
                {
                    await birdService.Edit(model.Id, model);
                }
            }
            return RedirectToAction("GetBirds");
        }
    }
    
}
