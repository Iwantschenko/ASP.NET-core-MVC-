using App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using App.BLL;
using App.Models.Models;
namespace App.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceRepository<Course, CourseModel> _courseService;
        public HomeController(ServiceRepository<Course, CourseModel> service)
        {
            _courseService = service;
        }

        public IActionResult Index()
        {
            _courseService.GetAll();
            return View();
        }
    }
}
