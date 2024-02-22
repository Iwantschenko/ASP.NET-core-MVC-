using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    public class Group
    {
        [Key]
        public Guid Group_Id { get; set; }
        public string Group_Name { get; set; }
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        
        public List<Student> Students { get; set; }

    }
}
