using Microsoft.EntityFrameworkCore;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.DbContexts;
using System;
using System.Linq;
using System.Linq.Expressions;
using ProjectCars.Repository.Helpers;

namespace ProjectCars.Repository.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region FIELDS

        internal ProjectCarsContext Context;

        #endregion FIELDS

        #region CONSTRUCTORS

        public GenericRepository(ProjectCarsContext context)
        {
            Context = context;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public virtual PagedList<TEntity> GetAll(int pageNumber,
                                                 int pageSize,
                                                 Expression<Func<TEntity, bool>> filter = null,
                                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                 string includeProperties = "")
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return PagedList<TEntity>.Create(query, pageNumber, pageSize);
        }

        public virtual TEntity GetOne(object id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        
        public virtual void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Context.Set<TEntity>().Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = Context.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entityToDelete);
            }
            Context.Set<TEntity>().Remove(entityToDelete);
        }

        #endregion METHODS
    }
}