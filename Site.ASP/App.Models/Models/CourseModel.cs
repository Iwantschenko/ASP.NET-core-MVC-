using App.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Models
{
    public class CourseModel
    {
        [Key]
        public Guid Course_ID { get; set; }

        [Required(ErrorMessage = "Select Name")]
        public string Course_Name { get; set; }
        [Required(ErrorMessage = "Select Info")]
        public string Course_Description { get; set; }

        public List<Group>? Groups { get; set; }

    }
}
