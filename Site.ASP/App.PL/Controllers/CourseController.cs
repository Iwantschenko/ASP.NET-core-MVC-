using Microsoft.AspNetCore.Mvc;

namespace App.PL.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
