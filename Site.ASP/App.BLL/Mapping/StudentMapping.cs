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
    public class StudentMapping : IMapping<Student, StudentModel>
    {

        public override Student ToEntity(StudentModel model)
        {
            return new Student()
            {
                Student_Id = model.Student_Id,
                GroupId = model.GroupId,
                First_Name = model.First_Name,
                Last_Name = model.Last_Name,
            };
        }

        public override StudentModel ToModel(Student entity)
        {
            return new StudentModel()
            {
                Student_Id = entity.Student_Id,
                GroupId = entity.GroupId,
                First_Name = entity.First_Name,
                Last_Name = entity.Last_Name,
            };
        }

        public override Guid GetModelId(StudentModel model) => model.Student_Id;
        public override void UpdateEntity(StudentModel model, Student entity)
        {
            entity.First_Name = model.First_Name;
            entity.Last_Name = model.Last_Name;
            entity.GroupId = model.GroupId;
        }

        public override List<ShortModel> GetShortData(List<Student> list)
        {
            return list.Select(x => new ShortModel() { ID =x.Student_Id , Info_Model= x.First_Name+" "+x.Last_Name}).ToList();
        }

        public override List<Student> GetSuccessorsForId(List<Student> list, Guid Id)
        {
            return list.Where(x => x.GroupId == Id).ToList();
        }
    }
}
