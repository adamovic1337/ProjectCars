using ProjectCars.Model.DTO.Search;
using ProjectCars.Repository.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectCars.Repository.Common.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all pagination data
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns>Returns collection of <see cref="TEntity"/></returns>
        PaginationData<TEntity> GetPaginationData(BaseSearch search,
                                                  Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Get one record by id for update
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns one <see cref="TEntity"/> object</returns>
        TEntity GetForUpdate(int id);

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