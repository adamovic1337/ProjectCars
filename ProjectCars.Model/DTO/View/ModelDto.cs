namespace ProjectCars.Model.DTO.View
{
    public class ModelDto : BaseViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public int EngineId { get; set; }
    }
}