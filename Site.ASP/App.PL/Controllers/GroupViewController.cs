using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.DAL.Models;
using App.BLL;
using System.Diagnostics;
using App.PL.Models;

namespace App.PL.Controllers
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
                Group_Id = group.Group_Id,
                Group_Name = group.Group_Name,
                CourseId = group.CourseId, 
                TeacherId = group.TeacherId,
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
        public IActionResult CourseDetails(Guid idFindCourse)
        {
            AllGroupsInfo groupsViewModel = new AllGroupsInfo()
            {
                Groups = _groupService.GetAll().Where(x => x.CourseId == idFindCourse).ToList(),
                Courses = _courseService.GetAll(),
                Teachers = _teacherService.GetAll(),
            };

            return View("Index", groupsViewModel);
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
            return RedirectToAction("Edition", new Group() { Group_Id = Guid.NewGuid() });
        }
        public IActionResult Edition(Group group)
        {
            return View(GetGroupViewModel(group));
        }

        [HttpPost]
        public IActionResult ResultEdition(GroupViewModel groupModel)
        {

            if (ModelState.IsValid)
            {
                var findGroup = _groupService.GetId(groupModel.Group_Id);
                if (findGroup != null)
                {
                    findGroup.Group_Name = groupModel.Group_Name;
                    findGroup.CourseId = groupModel.CourseId;
                    findGroup.TeacherId = groupModel.TeacherId;

                    _groupService.Update(findGroup);
                }
                else
                {
                    _groupService.Add(new Group()
                    {
                        Group_Id = groupModel.Group_Id,
                        Group_Name = groupModel.Group_Name,
                        CourseId = groupModel.CourseId,
                        TeacherId = groupModel.TeacherId

                    });
                }
                    
                _groupService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Edition", GetGroupViewModel(new Group()
                {
                    Group_Id = groupModel.Group_Id,
                    Group_Name = groupModel.Group_Name,
                    CourseId = groupModel.CourseId,
                    TeacherId = groupModel.TeacherId

                }));

        }

        public IActionResult Delete(Guid id)
        {
            _groupService.RemoveEntity(_groupService.GetId(id));
            _groupService.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
