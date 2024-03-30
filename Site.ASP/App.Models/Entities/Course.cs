using System.ComponentModel.DataAnnotations;

namespace App.Models.Entities
{
    public class Course
    {
        [Key]
        public Guid Course_ID { get; set; }


        public string Course_Name { get; set; }

        public string Course_Description { get; set; }

        public List<Group>? Groups { get; set; }

    }
}
