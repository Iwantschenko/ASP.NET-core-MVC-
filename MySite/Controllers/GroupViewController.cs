using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MySite.Infrastructure;
using MySite.Models;
using MySite.ViewModels;
using System.Diagnostics;

namespace MySite.Controllers
{
    
    public class GroupViewController : Controller
    {
        private readonly ServiceRepository<Group> _groupService;
        private readonly ServiceRepository<Course> _courseService;
        private readonly ServiceRepository<Teacher> _teacherService;
        public GroupViewController(
            ServiceRepository<Group> groupService, 
            ServiceRepository<Course> courseService, 
            ServiceRepository<Teacher> teacherService)
        {
            _groupService = groupService;
            _courseService = courseService;
            _teacherService = teacherService;
        }
        
        private GroupViewModel GetGroupViewModel(Group group)
        {
            var courseSelectList = new List<SelectListItem>();
            var teacherSelectList = new List<SelectListItem>();
            foreach (var course in _courseService.GetAll())
            {
                courseSelectList.Add(new SelectListItem() { Text = course.Course_Name, Value = course.Course_ID.ToString() });
            }
            foreach (var teacher in _teacherService.GetAll())
            {
                teacherSelectList.Add(new SelectListItem() { Text = teacher.Teacher_Name + " " + teacher.Teacher_Surname, Value = teacher.Teacher_Id.ToString() });
            }
            return new GroupViewModel()
            {
                group = group,
                courseSelectList = courseSelectList,
                teacherSelectList = teacherSelectList
            };
        }
        public IActionResult Index()
        {
            AllGroupsInfo groupsViewModel = new AllGroupsInfo()
            {
                Groups = _groupService.GetAll(),
                Courses = _courseService.GetAll(),
                Teachers = _teacherService.GetAll(),
            };
            return View(groupsViewModel);
        }
        public IActionResult Edit(Guid id)
        {
            var item = _groupService.GetId(id);
            if (item != null)
            {
                return RedirectToAction("Edition", item);
            }
            else
                return RedirectToAction("Index");
            
        }
        public IActionResult Create()
        {
            return RedirectToAction("Edition", new Group() { Group_Id = Guid.NewGuid()});
        }
        public IActionResult Edition(Group group)
        {
            return View(GetGroupViewModel(group));
        }

        [HttpPost]
        public IActionResult ResultEdition(GroupViewModel groupModel)
        {
            var group = groupModel.group;
            if (ModelState.IsValid )
            {
                if (_groupService.GetId(group.Group_Id) != null)
                {
                    _groupService.Update(group);
                }
                else
                    _groupService.Add(group);
                _groupService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Edition", GetGroupViewModel(group));

        }

        public IActionResult Delete(Guid id)
        {
            _groupService.RemoveEntity(_groupService.GetId(id));
            _groupService.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
