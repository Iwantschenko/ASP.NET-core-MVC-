using System.Text.RegularExpressions;
using App.DAL.Models;
namespace App.PL.Models
{
    public class AllStudentInfo
    {
        public List<Student> Students { get; set; }
        public List<DAL.Models.Group> Groups { get; set; }
    }
}
