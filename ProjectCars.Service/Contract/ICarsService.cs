using ProjectCars.Model.DTO.View;

namespace ProjectCars.Service.Contract
{
    public interface ICarsService
    {
        CarDto GetCarById(int userId, int carId);
    }
}