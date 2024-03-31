using App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using App.BLL;
using App.Models.Models;
namespace App.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
