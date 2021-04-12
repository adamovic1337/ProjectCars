using Microsoft.EntityFrameworkCore.Storage;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.DbContexts;
using System;

namespace ProjectCars.Repository.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        #region FIELDS

        private readonly ProjectCarsContext context;
        private readonly IDbContextTransaction transaction;

        #endregion FIELDS

        #region CONSTRUCTORS

        public UnitOfWork(ProjectCarsContext context)
        {
            this.context = context;
            transaction ??= context.Database.BeginTransaction();
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public int Commit()
        {
            var result = 0;
            try
            {
                result = context.SaveChanges();
                transaction?.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine(ex.Message); //log error
            }
            return result;
        }

        public void Rollback()
        {
            try
            {
                transaction?.Rollback();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //log error
            }
        }

        #endregion METHODS
    }
}