namespace ProjectCars.Model.DTO.View
{
    public class EngineDto : BaseViewDTO
    {
        public string Name { get; set; }
        public int? CubicCapacity { get; set; }
        public int Power { get; set; }
        public int FuelTypeId { get; set; }
        public string FuelTypeName { get; set; }
    }
}
