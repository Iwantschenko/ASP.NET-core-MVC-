using System.ComponentModel.DataAnnotations;

namespace MySite.ViewModels
{
    public class GroupViewModel
    {
        [Required(ErrorMessage = "Select Name")]

        public Models.Group Group { get; set; }
        [Required(ErrorMessage = "Select Name")]
        public List<CourseShortModel> Courses { get; set; }
        [Required(ErrorMessage = "Select Name")]
        public List<TeacherShortModel> Teachers { get; set; }
    }
}
