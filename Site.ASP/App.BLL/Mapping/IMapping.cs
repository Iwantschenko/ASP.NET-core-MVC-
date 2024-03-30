using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Mapping
{
    public abstract class IMapping<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        public abstract TEntity ToEntity(TModel model);
        public abstract TModel ToModel(TEntity entity);
        public List<TModel> ToListModel(List<TEntity> list)
        {
            List<TModel> modelList = new List<TModel>();
            foreach (var item in list)
            {
                modelList.Add(ToModel(item));
            }
            return modelList;
        }
        public List<TEntity> ToListEntity(List<TModel> list)
        {
            List<TEntity> entityList = new List<TEntity>();
            foreach (var item in list)
            {
                entityList.Add(ToEntity(item));
            }
            return entityList;
        }
    }
}
