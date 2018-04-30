using System;
using System.Collections.Generic;
using System.Linq;
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
        public virtual void Create(T element)
        {
            dbSet.Add(element);
        }

        // update some element
        public virtual void Update(T element)
        {
            db.Entry(element).State = EntityState.Modified;
        }

        // delete some element
        public virtual void Delete(T element)
        {
            //dbSet.Remove(element);
            db.Entry(element).State = EntityState.Deleted;
        }

        // find element by id
        public virtual T Find(int id)
        {
            return dbSet.Find(id);
        }

        // get element using specific predicate
        public virtual IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        // get all items
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        // list of items with included properties
        public virtual IEnumerable<T> Include(params Expression<Func<T, object>>[] includeParams)
        {
            return IncludeProperties(includeParams).ToList();
        }

        public virtual IEnumerable<T> Include(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeParams)
        {
            var query = IncludeProperties(includeParams);
            return query.Where(predicate).ToList();
        }

        // include specified properties
        private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeParams)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            return includeParams.Aggregate(query, (current, parameter) => current.Include(parameter));          // include specified properties
        }
    }
}
