namespace ProjectCars.Model.DTO.Create
{
    public class CreateEngineDto
    {
        public string Name { get; set; }
        public int CubicCapacity { get; set; }
        public int Power { get; set; }
        public int FuelTypeId { get; set; }
    }
}
