using System.ComponentModel.DataAnnotations;

namespace App.DAL.Models
{
    public class Course
    {
        [Key]
        public Guid Course_ID { get; set; }

        [Required(ErrorMessage = "Select Name")]
        public string Course_Name { get; set; }
        [Required(ErrorMessage = "Enter Description")]
        public string Course_Description { get; set; }

        public List<Group>? Groups { get; set; }

    }
}
