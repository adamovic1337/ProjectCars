using Microsoft.EntityFrameworkCore;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.DbContexts;
using System;
using System.Linq;
using System.Linq.Expressions;
using ProjectCars.Repository.Helpers;
using ProjectCars.Model.DTO.Search;

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

        public virtual PaginationData<TEntity> GetPaginationData(BaseSearch search,
                                                                 Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }            

            return PaginationData<TEntity>.Create(query, search.PageNumber, search.PageSize);
        }

        public virtual TEntity GetForUpdate(int id)
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