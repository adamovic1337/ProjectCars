using System;

namespace ProjectCars.Model.DTO.Search
{
    public class SearchMaintenanceDto : BaseSearch
    {
        public string ManufacturerName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "repairDate-desc";
    }
}