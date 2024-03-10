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
        [HttpGet]
        public IActionResult Create()
        {
            Course course = new Course()
            {
                Course_ID = Guid.NewGuid(),
                Course_Name = string.Empty,
                Course_Description = string.Empty,
            };
            return View("Edit", course);
        }
        [HttpPost]
        public IActionResult ResultEdition(Course course)
        {
            if (ModelState.IsValid)
            {
                var item = _courseService.GetId(course.Course_ID);
                if (item != null )
                {
                    item.Course_Name = course.Course_Name;
                    item.Course_Description = course.Course_Description;
                    _courseService.Update(item);
                }
                else
                    _courseService.Add(course);
               

                _courseService.SaveChanges();
                

                return RedirectToAction("Index", new { id = course.Course_ID });
            }
            else 
            { 
                return View("Edit" ,course); 
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
