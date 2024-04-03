using App.BLL;
using App.DAL.Infrastructure;
using App.Models.Entities;
using App.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.PL.Controllers
{
    public class CourseViewController : Controller
    {
        private readonly ServiceRepository<Course, CourseModel> _courseService;
        public CourseViewController(ServiceRepository<Course, CourseModel> courseService)
        {
            _courseService = courseService;
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
        public IActionResult Create(Guid id)
        {
            return View("Edit", new CourseModel() { Course_ID = id}); 
        }

        [HttpPost]
        public IActionResult ResultEdition(CourseModel course)
        {
            if (ModelState.IsValid)
            {
                if (_courseService.IsNotNull(course.Course_ID))
                {
                    _courseService.Update(course);
                }
                else
                {
                    _courseService.Add(course);
                    
                }

                _courseService.SaveChanges();


                return RedirectToAction("Index", new { id = course.Course_ID });
            }
            else
            {
                return View("Edit", course);
            }

        }

        public IActionResult Delete(Guid id)
        {
            _courseService.RemoveEntity(id);
            _courseService.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
