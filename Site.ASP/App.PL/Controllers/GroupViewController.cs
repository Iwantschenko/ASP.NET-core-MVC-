using App.Models.Entities;
using App.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.BLL;
using App.PL.ViewModel;
namespace App.PL.Controllers
{
    public class GroupViewController : Controller
    {
        private readonly ServiceRepository<App.Models.Entities.Group , GroupModel> _groupService;
        private readonly ServiceRepository<Course , CourseModel> _courseService;
        private readonly ServiceRepository<Teacher, TeacherModel> _teacherService;
        public GroupViewController(
            ServiceRepository<App.Models.Entities.Group ,GroupModel> groupService,
            ServiceRepository<Course, CourseModel> courseService,
            ServiceRepository<Teacher, TeacherModel> teacherService)
        {
            _groupService = groupService;
            _courseService = courseService;
            _teacherService = teacherService;
        }

        private GroupViewModel GetGroupViewModel(GroupModel group)
        {
            var courseSelectList = new List<SelectListItem>();
            var teacherSelectList = new List<SelectListItem>();
            var groupModel= new GroupModel()
            {
                Group_Id = group.Group_Id,
                Group_Name = group.Group_Name,
                CourseId = group.CourseId,
                TeacherId = group.TeacherId,
            };
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
                groupModel = groupModel,
                courseSelectList = courseSelectList,
                teacherSelectList = teacherSelectList
            };
        }

        public IActionResult Index()
        {
            var groupsViewModel = new GroupListViewModel()
            {
                Groups = _groupService.GetAll(),
                Courses = _courseService.GetAll(),
                Teachers = _teacherService.GetAll(),
            };

            return View(groupsViewModel);
        }
        public IActionResult CourseDetails(Guid idFindCourse)
        {
            var groupsViewModel = new GroupListViewModel()
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
            return RedirectToAction("Edition", new GroupModel() { Group_Id = Guid.NewGuid() });
        }
        public IActionResult Edition(GroupModel group)
        {
            return View(GetGroupViewModel(group));
        }

        [HttpPost]
        public IActionResult ResultEdition(GroupViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_groupService.GetId(model.groupModel.Group_Id)  != null)
                {
                    _groupService.Update(model.groupModel);
                }
                else
                {
                    _groupService.Add(model.groupModel);
                }

                _groupService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Edition", GetGroupViewModel(model.groupModel));

        }

        public IActionResult Delete(Guid id)
        {
            _groupService.RemoveEntity(_groupService.GetId(id));
            _groupService.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
