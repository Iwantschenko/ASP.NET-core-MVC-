using MySite.Models;
using System.Text.RegularExpressions;

namespace MySite.ViewModels
{
    public class AllStudentInfo
    {
        public List<Student> Students { get; set; }
        public List<MySite.Models.Group> Groups {  get; set; } 
    }
}
