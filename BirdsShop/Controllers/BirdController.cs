using BirdsShop.DAL.Interfaces;
using BirdsShop.Domain.Entity;
using BirdsShop.Service.Interfaces;
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
            var response = await birdService.GetBird();
            
            if (response.StatusCode== Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }                
    }
}
