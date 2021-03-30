using System;
using System.Collections.Generic;

namespace TechTest.Models
{
    interface IRepositoryDb<T>
    {
        public IEnumerable<T> findAll();
        public IEnumerable<T> findById(Guid id);
        public IEnumerable<T> findByParameters(T entity);
        public T add(T entity);
        public T update(Guid id, T entity);
        public void delete(Guid id);
    }
}
