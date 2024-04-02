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
            if(find == null)
            {
                return View(new CourseModel() {Course_ID = id});
            }
            else 
                return View(find);
        }
        
        
        [HttpPost]
        public IActionResult ResultEdition(CourseModel course)
        {
            if (ModelState.IsValid)
            {
                if (_courseService.GetId(course.Course_ID) != null)
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
