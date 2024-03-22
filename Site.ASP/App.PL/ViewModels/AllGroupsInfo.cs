using App.DAL.Models;
namespace App.PL.Models
{
    public class AllGroupsInfo
    {
        public List<Group> Groups { get; set; }
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
