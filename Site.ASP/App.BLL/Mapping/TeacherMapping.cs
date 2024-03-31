using App.Models.Entities;
using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Mapping
{
    public class TeacherMapping : IMapping<Teacher, TeacherModel>
    {
        
        public override Teacher ToEntity(TeacherModel model)
        {
            return new Teacher()
            {
                Teacher_Id = model.Teacher_Id,
                Teacher_Name = model.Teacher_Name,
                Teacher_Surname = model.Teacher_Surname,
            };
        }

        public override TeacherModel ToModel(Teacher entity)
        {
            return new TeacherModel()
            {
                Teacher_Id = entity.Teacher_Id,
                Teacher_Surname = entity.Teacher_Surname,
                Teacher_Name = entity.Teacher_Name,
            };
        }
        public override Guid GetModelId(TeacherModel model) => model.Teacher_Id;

        public override void UpdateEntity(TeacherModel model, Teacher entity)
        {
            entity.Teacher_Name = model.Teacher_Name;
            entity.Teacher_Surname = model.Teacher_Surname;
        }
    }
}
