using App.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.PL.ViewModel
{
    public class GroupViewModel
    {
        public GroupModel groupModel { get; set; }
        [BindNever]
        public SelectList? courseSelectList { get; set; }
        [BindNever]
        public SelectList? teacherSelectList { get; set; }
    }
}
