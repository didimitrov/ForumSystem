using System;
using System.Collections;
using System.Linq;

namespace ForumSystem.Common.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> All();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        int SaveChanges();
    }
}
