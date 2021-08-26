namespace ProjectCars.Model.DTO.View
{
    public class CarModelDto : BaseViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public int EngineId { get; set; }
        public string EngineName { get; set; }
    }
}