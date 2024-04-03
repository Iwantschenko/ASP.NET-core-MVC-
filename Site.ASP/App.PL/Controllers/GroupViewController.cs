using App.Models.Entities;
using App.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.BLL;
using App.PL.ViewModel;
using Microsoft.IdentityModel.Tokens;
namespace App.PL.Controllers
{
    public class GroupViewController : Controller
    {
        private readonly ServiceRepository<App.Models.Entities.Group , GroupModel> _groupService;
        private readonly ServiceRepository<Course , CourseModel> _courseService;
        private readonly ServiceRepository<Teacher, TeacherModel> _teacherService;
        private readonly ServiceRepository<Student, StudentModel> _studentService;
        public GroupViewController(
            ServiceRepository<App.Models.Entities.Group ,GroupModel> groupService,
            ServiceRepository<Course, CourseModel> courseService,
            ServiceRepository<Teacher, TeacherModel> teacherService,
            ServiceRepository<Student ,StudentModel> studentService)
        {
            _groupService = groupService;
            _courseService = courseService;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        private GroupViewModel GetGroupViewModel(GroupModel group)
        {
         
            return new GroupViewModel()
            {
                groupModel = group,
                courseSelectList = new SelectList(_courseService.GetShortsData(),"ID", "Info_Model"),
                teacherSelectList = new SelectList(_teacherService.GetShortsData(), "ID", "Info_Model")
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
                Groups = _groupService.GetLinkedDataListForId(idFindCourse),
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
        public IActionResult Create(Guid id)
        {
            return RedirectToAction("Edition", new GroupModel() { Group_Id = id});
        }
        public IActionResult Edition(GroupModel group)
        {
            return View(GetGroupViewModel(group));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var students = _studentService.GetLinkedDataListForId(id);
            if (students.IsNullOrEmpty())
            {
                _groupService.RemoveEntity(id);
                _groupService.SaveChanges();
            }
            else
            {
                TempData["ErrorMessage"] = "There are students in this Group. Do not delete";
            }
            return RedirectToAction("Index");            
        }

    }
}
