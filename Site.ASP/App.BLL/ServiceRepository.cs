﻿using App.DAL.Infrastructure;
namespace App.BLL
{
    public class ServiceRepository<T>
    {
        private IRepository<T> _repository { get; set; }
        public ServiceRepository(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity) => _repository.Add(entity);
        public void AddRange(IEnumerable<T> collection) => _repository.AddRange(collection);
        public void Delete(T entity) => _repository.Delete(entity);
        public void RemoveEntity(T entity) => _repository.RemoveEntity(entity);
        public void Update(T entity) => _repository.Update(entity);
        public List<T> GetAll() => _repository.GetAll();
        public T GetId(Guid Id) => _repository.GetId(Id);
        public void SaveChanges() => _repository.Save();
    }
}
