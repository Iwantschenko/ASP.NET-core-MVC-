﻿using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    public class Teacher
    {
        [Key]
        public Guid Teacher_Id { get; set; }
        public string Teacher_Name { get; set; }
        public string Teacher_Surname { get; set; }

        public List<Group> Groups { get; set; }


    }
}
