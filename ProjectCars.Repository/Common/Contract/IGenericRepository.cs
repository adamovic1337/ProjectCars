using ProjectCars.Repository.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectCars.Repository.Common.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all records for selected entity based on user filters
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns>Returns collection of <see cref="TEntity"/></returns>
        PagedList<TEntity> GetAll(int pageNumber,
                                  int pageSize,
                                  Expression<Func<TEntity, bool>> filter = null,
                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                  string includeProperties = "");

        /// <summary>
        /// Get one record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns one <see cref="TEntity"/> object</returns>
        TEntity GetOne(object id);

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity"></param>
        void Create(TEntity entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(TEntity entityToUpdate);

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);

        /// <summary>
        /// Delete entity using <see cref="TEntity"/> object
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(TEntity entityToDelete);
    }
}