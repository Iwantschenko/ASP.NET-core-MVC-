﻿using Microsoft.EntityFrameworkCore;
using Site.DAL.DB;

namespace Site.DAL.Infrastructure
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        public BaseRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }
        public void Delete(Guid id)
        {
            var item = GetId(id);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
            }
        }
        public void RemoveEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public List<T> GetAll() => _context.Set<T>().ToList();

        public T GetId(Guid id) => _context.Set<T>().Find(id);


        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
