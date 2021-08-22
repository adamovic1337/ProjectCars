using System;

namespace ProjectCars.Model.DTO.Search
{
    public class SearchServiceRequestDto : BaseSearch
    {
        public string Status { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "repairEnd-asc";
    }
}
