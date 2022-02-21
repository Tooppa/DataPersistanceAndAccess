using System;

namespace CustomerDB.Repositories
{
    public  interface IRepository<T>
    {
        /// <summary>
        /// Gets an element from the repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// returns the elements
        /// </returns>
        T GetById(int id);
        /// <summary>
        /// Gets all the elements from the repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// returns a list of the elements
        /// </returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Creates a new element to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Return true if succesfull
        /// </returns>
        bool Create(T entity);
        /// <summary>
        /// Updates a existing element in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Return true if succesfull
        /// </returns>
        bool Update(T entity);
        /// <summary>
        /// Has not been implemented
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>NotImplementedException</returns>
        bool Delete(T entity);

    }
}
