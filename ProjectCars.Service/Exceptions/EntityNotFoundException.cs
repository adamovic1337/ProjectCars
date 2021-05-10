using System;

namespace ProjectCars.Service.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
            : base($"Entity not found.")
        {
        }
    }
}