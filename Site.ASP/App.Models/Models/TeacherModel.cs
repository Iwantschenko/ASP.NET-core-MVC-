using System.ComponentModel.DataAnnotations;

namespace App.Models.Models
{
    public class TeacherModel
    {
        [Key]
        public Guid Teacher_Id { get; set; }
        [Required(ErrorMessage = "Select Name")]
        public string Teacher_Name { get; set; }
        [Required(ErrorMessage = "Select surname")]
        public string Teacher_Surname { get; set; }

        public override string ToString()
        {
            return Teacher_Name + " " + Teacher_Surname;
        }


    }
}
