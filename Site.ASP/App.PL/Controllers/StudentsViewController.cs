using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using App.DAL.Models;
using App.BLL;
using System.Net;
using App.PL.Models;

namespace App.PL.Controllers
{
    public class StudentsViewController : Controller
    {
        private readonly ServiceRepository<Student> _studentService;
        private readonly ServiceRepository<Group> _groupService;
        public StudentsViewController(ServiceRepository<Group> groupService, ServiceRepository<Student> studentService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }
        private StudentsViewModel GetStudentViewModel(Student student)
        {
            var selectListGroups = new List<SelectListItem>();
            foreach (var group in _groupService.GetAll())
            {
                selectListGroups.Add(new SelectListItem() { Text = group.Group_Name, Value = group.Group_Id.ToString() });
            }
            return new StudentsViewModel
            {
                Student_Id = student.Student_Id,
                First_Name = student.First_Name,
                Last_Name = student.Last_Name,
                GroupId = student.GroupId,
                Groups = selectListGroups
            };
        }
        public IActionResult Index()
        {
            AllStudentInfo allStudentInfo = new AllStudentInfo()
            {
                Students = _studentService.GetAll(),
                Groups = _groupService.GetAll(),
            };

            return View(allStudentInfo);
        }
        public IActionResult GroupDetails(Guid findGroupID)
        {
            AllStudentInfo allStudentInfo = new AllStudentInfo()
            {
                Students = _studentService.GetAll().Where(x => x.GroupId == findGroupID).ToList(),
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

            return RedirectToAction("Edition", new Student { Student_Id = id });
        }
        public IActionResult Edition(Student student)
        {
            return View(GetStudentViewModel(student));
        }
        public IActionResult ResultEdition(StudentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = _studentService.GetId(model.Student_Id);
                if (student != null)
                {
                    student.First_Name = model.First_Name;
                    student.Last_Name = model.Last_Name;
                    student.GroupId = model.GroupId;

                    _studentService.Update(student);
                }
                else
                {
                    _studentService.Add(new Student
                    {
                        Student_Id=model.Student_Id,
                        First_Name=model.First_Name,
                        Last_Name=model.Last_Name,
                        GroupId=model.GroupId
                    });
                }
                    
                _groupService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Edition", GetStudentViewModel(new Student
                {
                    Student_Id = model.Student_Id,
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    GroupId = model.GroupId
                }));

        }
        public IActionResult Delete(Guid id)
        {
            _studentService.RemoveEntity(_studentService.GetId(id));
            _studentService.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
