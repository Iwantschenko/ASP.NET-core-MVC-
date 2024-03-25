using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace App.PL.Models
{
    public class StudentsViewModel
    {
        public Guid Student_Id { get; set; }
        [Required(ErrorMessage = "Input Name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Input Surname")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Select Group")]
        public Guid GroupId { get; set; }

        public List<SelectListItem> Groups { get; set; }
    }
}
