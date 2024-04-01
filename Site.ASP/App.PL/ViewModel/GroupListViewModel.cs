using App.Models.Models;

namespace App.PL.ViewModel
{
    public class GroupListViewModel
    {
        public List<GroupModel> Groups { get; set; }
        public List<CourseModel> Courses { get; set; }
        public List<TeacherModel> Teachers{ get; set; }
    }
}
