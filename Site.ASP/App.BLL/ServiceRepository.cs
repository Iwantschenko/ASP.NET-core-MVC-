
using App.DAL.Infrastructure;
using App.BLL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    public class ServiceRepository<TEntity,TModel> 
        where TEntity : class 
        where TModel : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapping<TEntity, TModel> _mapping;
        public ServiceRepository(IRepository<TEntity> repository , IMapping<TEntity, TModel> mapping)
        {
            _repository = repository;
            _mapping = mapping;
        }

        public void Add(TModel model) => _repository.Add(_mapping.ToEntity(model));
        public void AddRange(List<TModel> collection) => _repository.AddRange(_mapping.ToListEntity(collection));
        public void Delete(TModel model) => _repository.Delete(_mapping.ToEntity(model));
        public void RemoveEntity(TModel model) => _repository.RemoveEntity(_mapping.ToEntity(model));
        public void Update(TModel model) => _repository.Update(_mapping.ToEntity(model));
        public List<TModel> GetAll() => _mapping.ToListModel(_repository.GetAll());
        public TModel GetId(Guid Id) => _mapping.ToModel( _repository.GetId(Id));
        public void SaveChanges() => _repository.Save();
    }


}
