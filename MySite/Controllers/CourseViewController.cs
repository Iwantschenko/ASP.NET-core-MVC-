using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
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

        [HttpGet]
        public IActionResult Index()
        {
            var list = _courseService.GetAll().ToList();
            ViewBag.List = list;
            ViewData["Courses"] = list;
            return View(list);
            
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var find = _courseService.GetId(id);
            return View(find);
        }

        [HttpPost]
        public IActionResult Edit(Course model)
        {
            if (ModelState.IsValid)
            {
                _courseService.Update(model);
                _courseService.SaveChanges();
                

                return RedirectToAction("Index", new { id = model.Course_ID });
            }
            else 
            { 
                return View(model); 
            }
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            Course course = new Course()
            {
                Course_ID = Guid.NewGuid(),
                Course_Name = string.Empty,
                Course_Description = string.Empty,
            };
            return View(course);
        }
        [HttpPost]
        public IActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {
                _courseService.Add(model);
                _courseService.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View(model); 
            }
        }
        
        public IActionResult Delete(Guid id) 
        {
            _courseService.RemoveEntity(_courseService.GetId(id));
            _courseService.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
