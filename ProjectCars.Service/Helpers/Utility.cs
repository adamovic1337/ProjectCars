using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCars.Model.Entities;
using ProjectCars.Service.Exceptions;

namespace ProjectCars.Service.Helpers
{
    public static class Utility
    {
        public static TEntity EntityNotFoundCheck<TEntity>(this TEntity entity)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return entity;
        }
    }
}
