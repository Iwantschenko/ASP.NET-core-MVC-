using Microsoft.AspNetCore.Mvc;
using MySite.Models;
using System.Diagnostics;

namespace MySite.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       

       
    }
}
