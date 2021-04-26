using System;

namespace ProjectCars.Model.DTO.Search
{
    public class SearchServiceRequestDto : BaseSearch
    {
        public DateTime? DateRepairedFrom { get; set; }
        public DateTime? DateRepairedTo { get; set; }

        public string OrderBy { get; set; } = "repairEnd-asc";
    }
}
