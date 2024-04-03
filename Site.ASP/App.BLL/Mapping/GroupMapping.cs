using App.Models;
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
        public override Guid GetModelId(GroupModel model) => model.Group_Id;

        public override void UpdateEntity(GroupModel model, Group entity)
        {
            entity.Group_Name = model.Group_Name;
            entity.CourseId = model.CourseId;
            entity.TeacherId = model.TeacherId;
        }

        public override List<ShortModel> GetShortData(List<Group> list)
        {
            return list.Select(x=> new ShortModel() { ID =x.Group_Id , Info_Model = x.Group_Name}).ToList();
        }

        public override List<Group> GetSuccessorsForId(List<Group> list, Guid id)
        {
            return list.Where(x => x.CourseId == id).ToList();
        }
    }
}
