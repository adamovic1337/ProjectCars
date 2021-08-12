namespace ProjectCars.Model.DTO.Update
{
    public class UpdateCarModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public int EngineId { get; set; }
    }
}