using ProjectCars.Model.DTO.View;

namespace ProjectCars.Repository.Contracts
{
    public interface ICarRepository
    {
        CarDto GetOne(int userId, int carId);
    }
}