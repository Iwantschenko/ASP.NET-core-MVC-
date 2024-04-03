using App.Models.Entities;
using App.Models.Models;
using Microsoft.AspNetCore.Mvc;
using App.BLL;
namespace App.PL.Controllers
{
    public class TeachersViewController : Controller
    {
        private readonly ServiceRepository<Teacher,TeacherModel> _teacherService;
        public TeachersViewController(ServiceRepository<Teacher,TeacherModel> teacherService)
        {
            _teacherService = teacherService;
        }

        public ActionResult Index()
        {
            var teachers = _teacherService.GetAll().ToList();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (_teacherService.IsNotNull(id))
            {
                return View(_teacherService.GetId(id));
            }
            else
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create(Guid id)
        {

            return View("Edit", new TeacherModel() { Teacher_Id = id});
        }

        [HttpPost]
        public IActionResult ResultEdition(TeacherModel teacher)
        {
            if (ModelState.IsValid)
            {
                
                if (_teacherService.IsNotNull(teacher.Teacher_Id))
                {
                    _teacherService.Update(teacher);
                }
                else
                    _teacherService.Add(teacher);

                _teacherService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit",teacher);
            }

        }

        public IActionResult Delete(Guid id)
        {
            _teacherService.RemoveEntity(id);
            _teacherService.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
