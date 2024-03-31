using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Entities;
using App.Models.Models;

namespace App.BLL.Mapping
{
    public class CourseMapping : IMapping<Course, CourseModel>
    {
        
        public override Course ToEntity(CourseModel model)
        {
            return new Course()
            {
                Course_ID = model.Course_ID,
                Course_Name = model.Course_Name,
                Course_Description = model.Course_Description,
            };
        }
        public override CourseModel ToModel(Course entity)
        {
            return new CourseModel()
            {
                Course_ID = entity.Course_ID,
                Course_Name = entity.Course_Name,
                Course_Description = entity.Course_Description,
            };
        }
        public override Guid GetModelId(CourseModel model) => model.Course_ID;

        public override void UpdateEntity(CourseModel model,  Course entity)
        {
            entity.Course_Name = model.Course_Name;
            entity.Course_Description = model.Course_Description;
        }
    }
}
