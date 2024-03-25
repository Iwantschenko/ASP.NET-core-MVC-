using System.ComponentModel.DataAnnotations;

namespace App.DAL.Models
{
    public class Teacher
    {
        [Key]
        public Guid Teacher_Id { get; set; }
        [Required(ErrorMessage = "Select Name")]
        public string Teacher_Name { get; set; }
        [Required(ErrorMessage = "Select surname")]
        public string Teacher_Surname { get; set; }

        public List<Group>? Groups { get; set; }


    }
}
