using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Libraries.Abstraction.Interfaces;
using Libraries.Abstraction.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : Entity<T>
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity) => _dbContext.Set<T>().Add(entity);

        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

        public List<T> GetAll() => _dbContext.Set<T>().ToList();

        public T GetById(int id) => _dbContext.Set<T>().Find(id);

        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save() => _dbContext.SaveChanges();
    }
}