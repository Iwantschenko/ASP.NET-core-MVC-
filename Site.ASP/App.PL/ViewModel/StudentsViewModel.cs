using App.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.PL.ViewModel
{
    public class StudentsViewModel
    {
        public StudentModel studentModel { get; set; }
        public SelectList? Groups { get; set; }
    }
}
