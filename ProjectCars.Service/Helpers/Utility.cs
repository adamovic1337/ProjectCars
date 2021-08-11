using ProjectCars.Service.Exceptions;

namespace ProjectCars.Service.Helpers
{
    public static class Utility
    {
        public static TEntity EntityNotFoundCheck<TEntity>(this TEntity entity) where TEntity : class
        {
            return entity is null ? throw new EntityNotFoundException() : entity;
        }
    }
}