using Microsoft.AspNetCore.Mvc.Rendering;
using MySite.Models;
using System.Globalization;

namespace MySite.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public List<SelectListItem> Groups { get; set; }
    }
}
