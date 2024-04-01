using App.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.PL.ViewModel
{
    public class GroupViewModel
    {
        public GroupModel groupModel { get; set; }
        public List<SelectListItem> courseSelectList { get; set; }

        public List<SelectListItem> teacherSelectList { get; set; }

    }
}
