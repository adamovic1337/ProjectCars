using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Repository
{
    public class MaintenanceRepository : GenericRepository<Maintenance>, IMaintenanceRepository
    {
        #region CONSTRUCTORS

        public MaintenanceRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<MaintenanceDto> GetAll(int userId, int carId, SearchMaintenanceDto searchMaintenance)
        {
            var orderBy = searchMaintenance.OrderBy.Split(new[] { '-' })[0];
            var direction = searchMaintenance.OrderBy?.Split(new[] { '-' })[1];

            return (from m in Context.Maintenance
                    join cs in Context.CarServices on m.CarServiceId equals cs.Id
                    join c in Context.Cars on m.CarId equals c.Id
                    join cm in Context.CarModels on c.ModelId equals cm.Id
                    join man in Context.Manufacturers on cm.ManufacturerId equals man.Id
                    join uc in Context.UserCars on c.Id equals uc.CarId
                    join u in Context.Users on uc.UserId equals u.Id
                    where u.Id == userId && c.Id == carId && man.Name.Contains(searchMaintenance.ManufacturerName.Trim())

                    select new MaintenanceDto
                    {
                        Id = m.Id,
                        Repairs = m.Repairs,
                        Mileage = m.Mileage,
                        RepairDate = m.RepairDate.Date.ToString(),
                        CarId = m.CarId,
                        ManufactrurerName = man.Name,
                        ModelName = cm.Name,
                        CarServiceId = m.CarServiceId,
                        CarServiceName = cs.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchMaintenance.PageNumber - 1) * searchMaintenance.PageSize)
                      .Take(searchMaintenance.PageSize).ToList();
        }

        public List<MaintenanceDto> GetAll(int carServiceId, SearchMaintenanceDto searchMaintenance)
        {
            var orderBy = searchMaintenance.OrderBy.Split(new[] { '-' })[0];
            var direction = searchMaintenance.OrderBy?.Split(new[] { '-' })[1];

            return (from m in Context.Maintenance
                    join cs in Context.CarServices on m.CarServiceId equals cs.Id
                    join c in Context.Cars on m.CarId equals c.Id
                    join cm in Context.CarModels on c.ModelId equals cm.Id
                    join man in Context.Manufacturers on cm.ManufacturerId equals man.Id
                    join uc in Context.UserCars on c.Id equals uc.CarId
                    join u in Context.Users on uc.UserId equals u.Id
                    where u.Id == carServiceId && man.Name.Contains(searchMaintenance.ManufacturerName.Trim())

                    select new MaintenanceDto
                    {
                        Id = m.Id,
                        Repairs = m.Repairs,
                        Mileage = m.Mileage,
                        RepairDate = m.RepairDate.Date.ToString(),
                        CarId = m.CarId,
                        ManufactrurerName = man.Name,
                        ModelName = cm.Name,
                        CarServiceId = m.CarServiceId,
                        CarServiceName = cs.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchMaintenance.PageNumber - 1) * searchMaintenance.PageSize)
                      .Take(searchMaintenance.PageSize).ToList();
        }

        public PaginationData<Maintenance> GetPaginationData(int userId, int carId, SearchMaintenanceDto searchMaintenance)
        {
            var query = (from m in Context.Maintenance
                         join cs in Context.CarServices on m.CarServiceId equals cs.Id
                         join c in Context.Cars on m.CarId equals c.Id
                         join cm in Context.CarModels on c.ModelId equals cm.Id
                         join man in Context.Manufacturers on cm.ManufacturerId equals man.Id
                         join uc in Context.UserCars on c.Id equals uc.CarId
                         join u in Context.Users on uc.UserId equals u.Id
                         where u.Id == userId && c.Id == carId && man.Name.Contains(searchMaintenance.ManufacturerName.Trim())

                         select new Maintenance
                         {
                             Id = m.Id,
                             Repairs = m.Repairs,
                             Mileage = m.Mileage,
                             RepairDate = m.RepairDate,
                             CarId = m.CarId,
                             CarServiceId = m.CarServiceId,
                         });

            return PaginationData<Maintenance>.Create(query, searchMaintenance.PageNumber, searchMaintenance.PageSize);
        }

        public PaginationData<Maintenance> GetPaginationData(int carServiceId, SearchMaintenanceDto searchMaintenance)
        {
            var query = (from m in Context.Maintenance
                         join cs in Context.CarServices on m.CarServiceId equals cs.Id
                         join c in Context.Cars on m.CarId equals c.Id
                         join cm in Context.CarModels on c.ModelId equals cm.Id
                         join man in Context.Manufacturers on cm.ManufacturerId equals man.Id
                         join uc in Context.UserCars on c.Id equals uc.CarId
                         join u in Context.Users on uc.UserId equals u.Id
                         where u.Id == carServiceId && man.Name.Contains(searchMaintenance.ManufacturerName.Trim())
                         select new Maintenance
                         {
                             Id = m.Id,
                             Repairs = m.Repairs,
                             Mileage = m.Mileage,
                             RepairDate = m.RepairDate,
                             CarId = m.CarId,
                             CarServiceId = m.CarServiceId,
                         });

            return PaginationData<Maintenance>.Create(query, searchMaintenance.PageNumber, searchMaintenance.PageSize);
        }

        public MaintenanceDto GetOne(int carServiceId, int maintenanceId)
        {
            return (from m in Context.Maintenance
                    join cs in Context.CarServices on m.CarServiceId equals cs.Id
                    join c in Context.Cars on m.CarId equals c.Id
                    join cm in Context.CarModels on c.ModelId equals cm.Id
                    join man in Context.Manufacturers on cm.ManufacturerId equals man.Id
                    join uc in Context.UserCars on c.Id equals uc.CarId
                    join u in Context.Users on uc.UserId equals u.Id
                    where cs.Id == carServiceId && m.Id == maintenanceId

                    select new MaintenanceDto
                    {
                        Id = m.Id,
                        Repairs = m.Repairs,
                        Mileage = m.Mileage,
                        RepairDate = m.RepairDate.Date.ToString(),
                        CarId = m.CarId,
                        ManufactrurerName = man.Name,
                        ModelName = cm.Name,
                        CarServiceId = m.CarServiceId,
                        CarServiceName = cs.Name,
                    }).FirstOrDefault();
        }

        public Maintenance GetEntity(int carServiceId, int maintenanceId)
        {
            return (from m in Context.Maintenance
                    join cs in Context.CarServices on m.CarServiceId equals cs.Id
                    join c in Context.Cars on m.CarId equals c.Id
                    join uc in Context.UserCars on c.Id equals uc.CarId
                    join u in Context.Users on uc.UserId equals u.Id
                    where cs.Id == carServiceId && m.Id == maintenanceId

                    select new Maintenance
                    {
                        Id = m.Id,
                        Repairs = m.Repairs,
                        Mileage = m.Mileage,
                        RepairDate = m.RepairDate,
                        CarId = m.CarId,
                        CarServiceId = m.CarServiceId,
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}