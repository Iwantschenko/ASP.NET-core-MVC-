using System.ComponentModel.DataAnnotations;

namespace App.Models.Models
{
    public class GroupModel
    {
        [Key]
        public Guid Group_Id { get; set; }
        public string Group_Name { get; set; }
        public Guid CourseId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
