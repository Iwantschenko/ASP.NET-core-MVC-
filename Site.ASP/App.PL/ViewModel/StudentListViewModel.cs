using App.Models.Models;

namespace App.PL.ViewModel
{
    public class StudentListViewModel
    {
        public List<StudentModel> Students { get; set; }
        public List<GroupModel> Groups { get; set; }
    }
}
