using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Libraries.Abstraction.Models;

namespace Libraries.Abstraction.Interfaces
{
    public interface IRepository<T> where T : Entity<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        T GetById(int id);
        List<T> GetAll();
        List<T> Find(Expression<Func<T, bool>> predicate);
    }
}