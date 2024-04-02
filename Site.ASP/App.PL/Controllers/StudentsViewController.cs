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
            var selectListGroups = new List<SelectListItem>();
            var studentModel = new StudentModel()
            {
                Student_Id = student.Student_Id,
                First_Name = student.First_Name,
                Last_Name = student.Last_Name,
                GroupId = student.GroupId,
            };
            foreach (var group in _groupService.GetAll())
            {
                selectListGroups.Add(new SelectListItem() { Text = group.Group_Name, Value = group.Group_Id.ToString() });
            }
            return new StudentsViewModel
            {
                studentModel = student,
                Groups = selectListGroups
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
                Students = _studentService.GetAll().Where(x => x.GroupId == findGroupID).ToList(),
                Groups = _groupService.GetAll()
            };
            return View("Index", allStudentInfo);
        }
        public IActionResult Edit(Guid id)
        {
            var student = _studentService.GetId(id);
            if (student == null) 
            {
                return RedirectToAction("Edition",new StudentModel() { Student_Id = id});
            }
            else 
                return RedirectToAction("Edition", student);
        }

        
        public IActionResult Edition(StudentModel student)
        {
            return View(GetStudentViewModel(student));
        }
        public IActionResult ResultEdition(StudentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_studentService.GetId(model.studentModel.Student_Id) != null)
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
