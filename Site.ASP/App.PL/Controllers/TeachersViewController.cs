using App.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using App.DAL.Models;
using App.BLL;

namespace App.PL.Controllers
{
    public class TeachersViewController : Controller
    {
        private readonly ServiceRepository<Teacher> _teacherService;
        public TeachersViewController(ServiceRepository<Teacher> teacherService)
        {
            _teacherService = teacherService;
        }

        public ActionResult Index()
        {

            List<Teacher> teachers = _teacherService.GetAll().ToList();
            ViewBag.Teachers = teachers;
            return View(teachers);
        }
        [HttpGet]
        public IActionResult Create(Guid id)
        {
            Teacher teacher = new Teacher()
            {
                Teacher_Id = id,
                Teacher_Name = string.Empty,
                Teacher_Surname = string.Empty,
            };
            return View("Edit", teacher);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var teacher = _teacherService.GetId(id);
            return View(teacher);
        }

        [HttpPost]
        public IActionResult ResultEdition(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var item = _teacherService.GetId(teacher.Teacher_Id);
                if (item != null)
                {
                    item.Teacher_Name = teacher.Teacher_Name;
                    item.Teacher_Surname = teacher.Teacher_Surname;

                    _teacherService.Update(item);
                }
                else
                    _teacherService.Add(teacher);


                _teacherService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Delete(Guid id)
        {
            _teacherService.RemoveEntity(_teacherService.GetId(id));
            _teacherService.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
