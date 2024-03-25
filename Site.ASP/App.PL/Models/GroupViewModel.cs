using App.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace App.PL.Models
{
    public class GroupViewModel
    {
        public Guid Group_Id { get; set; }
        [Required(ErrorMessage = "Input Name")]
        public string Group_Name { get; set; }
        [Required(ErrorMessage = "Select Course")]
        public Guid CourseId { get; set; }
        [Required(ErrorMessage = "Select Teacher")]
        public Guid TeacherId { get; set; }
        public List<SelectListItem> courseSelectList { get; set; }

        public List<SelectListItem> teacherSelectList { get; set; }



    }
}
