using BirdsShop.DAL.Interfaces;
using BirdsShop.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdsShop.Controllers
{
    public class BirdController : Controller
    {
        private readonly IBirdRepository _birdRepository;

        public BirdController(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        // GET: BirdController
        [HttpGet]
        public async Task<ActionResult> GetBirds()
        {
            var response = await _birdRepository.Select();
            var response1 = await _birdRepository.GetByName("Аратинга");
            var response2 = await _birdRepository.Get(5);
            var sinica = new Bird () { Name = "ПТИЦА СИНИЦА", Price = 34, Size = 6, Species = 0, DataCreate = DateTime.Now };
            
            await _birdRepository.Create(sinica);
            await _birdRepository.Delete(sinica);
            return View(response);
        }

        // GET: BirdController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BirdController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BirdController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BirdController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BirdController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BirdController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BirdController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
