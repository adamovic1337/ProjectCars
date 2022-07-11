using System;

namespace ProjectCars.Model.DTO.Search
{
    public class SearchMaintenanceDto : BaseSearch
    {
        public DateTime DateFrom { get; set; } = DateTime.Now.AddYears(-1);

        public DateTime DateTo { get; set; } = DateTime.Now;

        public string OrderBy { get; set; } = "repairDate-desc";
    }
}