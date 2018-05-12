using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMProject.DAL.Interfaces
{
    //Wrapper to get access to entities
    public interface IRepository<T> where T : class
    {
        // Get all elements from entity
        Task<IEnumerable<T>> GetAll();
        
        // Find element with certain id
        Task<T> Find(int id);
        
        // Get element through predicate
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

        // Create new element
        Task Create(T element);
        
        // Update some element
        Task Update(T element);
        
        // Delete some element
        Task Delete(T element);

        // include some properties
        Task<IEnumerable<T>> Include(params Expression<Func<T, object>>[] includeParams);

        // include some properties using predicate
        Task<IEnumerable<T>> Include(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeParams);
    }
}
