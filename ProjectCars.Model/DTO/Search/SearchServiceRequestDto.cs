using System;

namespace ProjectCars.Model.DTO.Search
{
    public class SearchServiceRequestDto : BaseSearch
    {
        public int StatusId { get; set; }

        public int UserId { get; set; }

        public int CarServiceId { get; set; }

        public string OrderBy { get; set; } = "repairEnd-asc";
    }
}
