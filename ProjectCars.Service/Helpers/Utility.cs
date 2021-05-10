using ProjectCars.Service.Exceptions;

namespace ProjectCars.Service.Helpers
{
    public static class Utility
    {
        public static TEntity EntityNotFoundCheck<TEntity>(this TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return entity;
        }
    }
}