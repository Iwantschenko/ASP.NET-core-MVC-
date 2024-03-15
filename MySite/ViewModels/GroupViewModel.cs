using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MySite.ViewModels
{
    public class GroupViewModel
    {
        public MySite.Models.Group group { get; set; }
        
        public List<SelectListItem> courseSelectList {  get; set; }

        public List<SelectListItem> teacherSelectList { get; set; }
    }
}
