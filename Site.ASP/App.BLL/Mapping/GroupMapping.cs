using App.Models.Entities;
using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Mapping
{
    public class GroupMapping : IMapping<Group, GroupModel>
    {
        public override Group ToEntity(GroupModel model)
        {
            return new Group()
            {
                Group_Id = model.Group_Id,
                Group_Name = model.Group_Name,
                CourseId = model.CourseId,
                TeacherId = model.TeacherId,
            };
        }

        public override GroupModel ToModel(Group entity)
        {
            return new GroupModel()
            {
                Group_Name = entity.Group_Name,
                Group_Id = entity.Group_Id,
                CourseId = entity.CourseId,
                TeacherId = entity.TeacherId,
            };
        }
    }
}
