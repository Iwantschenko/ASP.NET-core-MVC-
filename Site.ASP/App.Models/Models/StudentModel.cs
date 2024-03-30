﻿using System.ComponentModel.DataAnnotations;

namespace App.Models.Models
{
    public class StudentModel
    {
        [Key]
        public Guid Student_Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }
        public Guid GroupId { get; set; }
        public GroupModel? GroupStudent { get; set; }

    }
}
