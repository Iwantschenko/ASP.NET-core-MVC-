
using App.DAL.Infrastructure;
using App.BLL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;


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

        public void Add(TModel model) 
        {
            if (model != null)
            {
                _repository.Add(_mapping.ToEntity(model));
            }
            else
                return;
        }

        public void AddRange(List<TModel> collection) 
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentNullException(nameof(collection), "Collection cannot be null or empty.");
            }

            _repository.AddRange(_mapping.ToListEntity(collection));
        }
        public void Delete(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }
            _repository.RemoveEntity(_mapping.ToEntity(model)); 
        } 
        public void RemoveEntity(Guid Id)
        {
            _repository.Delete(Id);
        }
        public void Update(TModel model)
        {
            if (model == null)
                return;
            var entity = _repository.GetId(_mapping.GetModelId(model));
            _mapping.UpdateEntity(model ,entity);
            _repository.Update(entity);
            
        }
        public List<TModel> GetAll() 
        {
            var list = _repository.GetAll();
            if (list == null)
            {
                return new List<TModel>();
            }
            else
                return _mapping.ToListModel(list);
        } 
        public TModel GetId(Guid Id) 
        {
            var entity = _repository.GetId(Id);
            if (entity != null)
            {
                return _mapping.ToModel(entity);
            }
            else
                return null;
             
        }
        public bool IsNotNull(Guid id)
        {
            var entity = _repository.GetId(id);
            if (entity != null)
            {
                return true;
            }
            else 
                return false;
        }
        public List<TModel> GetLinkedDataListForId(Guid id)
        {
            var list = _mapping.GetSuccessorsForId(_repository.GetAll() ,id);
            if (list != null)
            {
                return _mapping.ToListModel(list);
            }
            else 
                return new List<TModel>();
        }
        public List<ShortModel> GetShortsData()
        {
            var shortDataList = _mapping.GetShortData(_repository.GetAll());
            if (shortDataList != null)
            {
                return shortDataList;
            }
            else
            {
                return new List<ShortModel>(); 
            }
        }
        public void SaveChanges() => _repository.Save();
    }


}
