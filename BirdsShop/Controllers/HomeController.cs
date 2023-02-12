
using BirdsShop.Domain.Entity;
using BirdsShop.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BirdsShop.DAL.Interfaces;

namespace BirdsShop.Controllers
{
    public class HomeController : Controller
    {        
        public async Task<IActionResult> Index()=> View();
        
    }
}