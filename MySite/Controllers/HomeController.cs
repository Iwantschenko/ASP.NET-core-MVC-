using Microsoft.AspNetCore.Mvc;
using MySite.Infrastructure;
using MySite.Models;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace MySite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
