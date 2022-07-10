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
    public class ServiceRequestRepository : GenericRepository<ServiceRequest>, IServiceRequestRepository
    {
        #region CONSTRUCTORS

        public ServiceRequestRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<ServiceRequestDto> GetAll(SearchServiceRequestDto searchServiceRequest)
        {
            var orderBy = searchServiceRequest.OrderBy.Split(new[] { '-' })[0];
            var direction = searchServiceRequest.OrderBy?.Split(new[] { '-' })[1];

            return (from sr in Context.ServiceRequest
                    join cs in Context.CarServices on sr.CarServiceId equals cs.Id
                    join uc in Context.UserCars on sr.UserId equals uc.UserId
                    join c in Context.Cars on uc.CarId equals c.Id
                    join cm in Context.CarModels on c.ModelId equals cm.Id
                    join m in Context.Manufacturers on cm.ManufacturerId equals m.Id
                    join u in Context.Users on uc.UserId equals u.Id
                    join s in Context.Status on sr.StatusId equals s.Id
                    where sr.StatusId == searchServiceRequest.StatusId
                    select new ServiceRequestDto
                    {
                        Id = sr.Id,
                        UserDescription = sr.UserDescription,
                        Appointment = sr.Appointment,
                        RepairStart = sr.RepairStart,
                        RepairEnd = sr.RepairEnd,
                        CarManufacturer = m.Name,
                        CarModel = cm.Name,
                        UserFName = u.FirstName,
                        UserLName = u.LastName,
                        UserId = sr.UserId,
                        CarId = sr.CarId,
                        CarServiceId = sr.CarServiceId,
                        CarServiceName = cs.Name,
                        StatusId = sr.StatusId,
                        Status = s.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchServiceRequest.PageNumber - 1) * searchServiceRequest.PageSize)
                      .Take(searchServiceRequest.PageSize).ToList();
        }

        public ServiceRequestDto GetOne(int id)
        {
            return (from sr in Context.ServiceRequest
                    join cs in Context.CarServices on sr.CarServiceId equals cs.Id
                    join uc in Context.UserCars on sr.UserId equals uc.UserId
                    join c in Context.Cars on uc.CarId equals c.Id
                    join cm in Context.CarModels on c.ModelId equals cm.Id
                    join m in Context.Manufacturers on cm.ManufacturerId equals m.Id
                    join u in Context.Users on uc.UserId equals u.Id
                    join s in Context.Status on sr.StatusId equals s.Id
                    where sr.Id == s.Id
                    select new ServiceRequestDto
                    {
                        Id = sr.Id,
                        UserDescription = sr.UserDescription,
                        Appointment = sr.Appointment,
                        RepairStart = sr.RepairStart,
                        RepairEnd = sr.RepairEnd,
                        CarManufacturer = m.Name,
                        CarModel = cm.Name,
                        UserFName = u.FirstName,
                        UserLName = u.LastName,
                        UserId = sr.UserId,
                        CarId = sr.CarId,
                        CarServiceId = sr.CarServiceId,
                        CarServiceName = cs.Name,
                        StatusId = sr.StatusId,
                        Status = s.Name,
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}