using BirdsShop.Models;
using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BirdsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Bird bird = new Bird() { Name = "Неразлучник", Species = Species.Medium };
            return View(bird);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}