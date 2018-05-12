using System;
using System.Collections.Generic;
using System.Linq;
using Tasks = System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using CRMProject.DAL.Interfaces;
using CRMProject.DAL.Entities;

namespace CRMProject.DAL.Repositories
{
    // repository with shared actions
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        // access to EF entities
        protected CRMEntities db;

        // current object dbset
        protected DbSet<T> dbSet;

        public BaseRepository(CRMEntities entities)
        {
            if (entities != null)
            {
                db = entities;
                dbSet = db.Set<T>();                // get current DbSet
            }
            else
            {
                throw new ArgumentNullException("", "Context can't be null");
            }
        }

        // add new element
        public virtual Tasks.Task Create(T element)
        {
            dbSet.Add(element);
            return Tasks.Task.FromResult(0);
        }

        // update some element
        public virtual Tasks.Task Update(T element)
        {
            db.Entry(element).State = EntityState.Modified;
            return Tasks.Task.FromResult(0);
        }

        // delete some element
        public virtual Tasks.Task Delete(T element)
        {
            //dbSet.Remove(element);
            db.Entry(element).State = EntityState.Deleted;
            return Tasks.Task.FromResult(0);
        }

        // find element by id
        public virtual async Tasks.Task<T> Find(int id)
        {
            return await dbSet.FindAsync(id);
        }

        // get element using specific predicate
        public virtual async Tasks.Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        // get all items
        public virtual async Tasks.Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        // list of items with included properties
        public virtual async Tasks.Task<IEnumerable<T>> Include(params Expression<Func<T, object>>[] includeParams)
        {
            return await IncludeProperties(includeParams).ToListAsync();
        }

        public virtual async Tasks.Task<IEnumerable<T>> Include(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeParams)
        {
            var query = IncludeProperties(includeParams).Where(predicate);
            return await query.ToListAsync();
        }

        // include specified properties
        private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeParams)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            return includeParams.Aggregate(query, (current, parameter) => current.Include(parameter));          // include specified properties
        }
    }
}
