using Microsoft.AspNetCore.Mvc;
using App.DAL.Models;
using App.BLL;
using System.Diagnostics;

namespace App.PL.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
