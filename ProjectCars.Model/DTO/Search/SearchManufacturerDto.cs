namespace ProjectCars.Model.DTO.Search
{
    public  class SearchManufacturerDto : BaseSearch
    {
        public string ManufacturerName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "name-asc";
    }
}