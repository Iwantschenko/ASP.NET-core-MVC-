using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using App.DAL.Models;
namespace App.PL.Models
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public List<SelectListItem> Groups { get; set; }
    }
}
