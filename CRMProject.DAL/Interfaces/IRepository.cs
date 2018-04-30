using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CRMProject.DAL.Interfaces
{
    //Wrapper to get access to entities
    public interface IRepository<T> where T : class
    {
        // Get all elements from entity
        IEnumerable<T> GetAll();
        
        // Find element with certain id
        T Find(int id);
        
        // Get element through predicate
        IEnumerable<T> Get(Func<T, bool> predicate);

        // Create new element
        void Create(T element);
        
        // Update some element
        void Update(T element);
        
        // Delete some element
        void Delete(T element);

        // include some properties
        IEnumerable<T> Include(params Expression<Func<T, object>>[] includeParams);

        // include some properties using predicate
        IEnumerable<T> Include(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeParams);
    }
}
