    using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    public class Student
    {
        [Key]
        public Guid Student_Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Enter Surname")]
        public string Last_Name { get; set; }
        public Guid GroupId { get; set; }
        public Group ? GroupStudent { get; set; }

    }
}
