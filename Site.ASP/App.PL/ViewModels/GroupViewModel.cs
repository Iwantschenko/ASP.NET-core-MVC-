using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using App.DAL.Models;
namespace App.PL.Models
{
    public class GroupViewModel
    {
        public DAL.Models.Group group { get; set; }

        public List<SelectListItem> courseSelectList { get; set; }

        public List<SelectListItem> teacherSelectList { get; set; }
    }
}
