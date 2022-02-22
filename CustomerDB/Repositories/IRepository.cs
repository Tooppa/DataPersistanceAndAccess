using System;

namespace CustomerDB.Repositories
{
    public  interface IRepository<T>
    {
        /// <summary>
        /// Gets an element from the database
        /// </summary>
        /// <param name="id">The id of the element</param>
        /// <returns>
        /// Returns the element with the given id if found
        /// </returns>
        T GetById(int id);
        /// <summary>
        /// Gets all the elements from the database
        /// </summary>
        /// <returns>
        /// Returns a list of all the elements
        /// </returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Creates a new element to the database
        /// </summary>
        /// <param name="entity">The new element to be added</param>
        /// <returns>
        /// Return true if successful
        /// </returns>
        bool Create(T entity);
        /// <summary>
        /// Updates a existing element in the database
        /// </summary>
        /// <param name="entity">The element to be updated</param>
        /// <returns>
        /// Return true if successful
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
