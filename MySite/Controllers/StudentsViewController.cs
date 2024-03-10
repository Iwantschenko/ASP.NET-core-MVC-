using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MySite.Infrastructure;
using MySite.Models;

namespace MySite.Controllers
{
    public class StudentsViewController : Controller
    {
        private readonly ServiceRepository<Student> _studentService;
        public StudentsViewController(ServiceRepository<Student> studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(id);

        }

        [HttpPost]
        public IActionResult Edit()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Create(Guid id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return View();
        }

    }
}
