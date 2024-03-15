using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    public class Group
    {
        [Key]
        public Guid Group_Id { get; set; }
        [Required(ErrorMessage = "Enter Name is invalid")]
        public string Group_Name { get; set; }
        [Required(ErrorMessage = "Select Course")]
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        [Required(ErrorMessage = "Select Teacher")]
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        
        public List<Student>? Students { get; set; }

    }
}
