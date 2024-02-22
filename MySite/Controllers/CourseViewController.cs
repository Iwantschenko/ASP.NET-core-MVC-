using Microsoft.AspNetCore.Mvc;
using MySite.Infrastructure;
using MySite.Models;

namespace MySite.Controllers
{
    public class CourseViewController : Controller
    {
        private readonly ServiceRepository<Course> _courseService;
        public CourseViewController(ServiceRepository<Course> service)
        {
            _courseService = service;
        }
        public IActionResult Index()
        {
            var list = _courseService.GetAll().ToList();
            ViewBag.List = list;
            ViewData["Courses"] = list;
            return View(list);
            
        }
        public IActionResult Edit(Guid id)
        {
            var find = _courseService.FindForId(id);
            return View(find);
        }

    }
}
