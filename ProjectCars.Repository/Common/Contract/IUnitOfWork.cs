namespace ProjectCars.Repository.Common.Contract
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves All pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();

        /// <summary>
        /// Rollback all pending changes
        /// </summary>
        void Rollback();
    }
}