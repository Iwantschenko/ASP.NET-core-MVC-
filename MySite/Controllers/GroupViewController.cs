using Microsoft.AspNetCore.Mvc;
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
        
        public IActionResult Index()
        {
            
        }

       
        [HttpGet]
        public IActionResult Create(Guid id)
        {
           
            
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            
        }
        [HttpPost]
        public IActionResult ResultEdition(Group group)
        {
            

        }
        public IActionResult Delete(Guid id)
        {
            _groupService.RemoveEntity(_groupService.GetId(id));
            _groupService.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
