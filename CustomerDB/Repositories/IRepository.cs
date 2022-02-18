using System;

namespace CustomerDB.Repositories
{
    public  interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);

    }
}
