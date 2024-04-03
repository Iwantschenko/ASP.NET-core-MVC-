using App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.BLL;
using App.Models.Models;
using App.PL.ViewModel;


namespace App.PL.Controllers
{
    public class StudentsViewController : Controller
    {
        private readonly ServiceRepository<Student , StudentModel> _studentService;
        private readonly ServiceRepository<Group ,GroupModel> _groupService;
        public StudentsViewController(ServiceRepository<Group,GroupModel> groupService, ServiceRepository<Student, StudentModel> studentService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }
        private StudentsViewModel GetStudentViewModel(StudentModel student)
        {
            return new StudentsViewModel
            {
                studentModel = student,
                Groups = new SelectList(_groupService.GetShortsData(), "ID", "Info_Model")
            };
        }
        public IActionResult Index()
        {
            var allStudentInfo = new StudentListViewModel()
            {
                Students = _studentService.GetAll(),
                Groups = _groupService.GetAll(),
            };

            return View(allStudentInfo);
        }
        public IActionResult GroupDetails(Guid findGroupID)
        {
            var allStudentInfo = new StudentListViewModel()
            {
                Students = _studentService.GetLinkedDataListForId(findGroupID),
                Groups = _groupService.GetAll()
            };
            return View("Index", allStudentInfo);
        }
        public IActionResult Edit(Guid id)
        {
            var student = _studentService.GetId(id);
            return RedirectToAction("Edition", student);
        }
        public IActionResult Create(Guid id)
        {
            return RedirectToAction("Edition", new StudentModel { Student_Id = id });
        }

        public IActionResult Edition(StudentModel student)
        {
            return View(GetStudentViewModel(student));
        }
        public IActionResult ResultEdition(StudentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_studentService.IsNotNull(model.studentModel.Student_Id))
                {
                    _studentService.Update(model.studentModel);
                }
                else
                {
                    _studentService.Add(model.studentModel);
                }

                _groupService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Edition", GetStudentViewModel(model.studentModel));

        }
        public IActionResult Delete(Guid id)
        {
            _studentService.RemoveEntity(id);
            _studentService.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
