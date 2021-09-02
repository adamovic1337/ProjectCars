using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Repository
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        #region CONSTRUCTORS

        public StatusRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<StatusDto> GetAll(SearchStatusDto searchStatus)
        {
            var orderBy = searchStatus.OrderBy.Split(new[] { '-' })[0];
            var direction = searchStatus.OrderBy?.Split(new[] { '-' })[1];

            return (from s in Context.Status
                    where s.Name.Contains(searchStatus.StatusName.Trim())
                    select new StatusDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchStatus.PageNumber - 1) * searchStatus.PageSize)
                      .Take(searchStatus.PageSize).ToList();
        }

        public StatusDto GetOne(int id)
        {
            return Context.Status.Where(s => s.Id == id).Select(s => new StatusDto{ Id = s.Id, Name = s.Name }).FirstOrDefault();
        }

        #endregion
    }
}