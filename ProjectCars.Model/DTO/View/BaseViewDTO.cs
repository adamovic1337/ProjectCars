using System.Collections.Generic;

namespace ProjectCars.Model.DTO.View
{
    public class BaseViewDTO
    {
        public int Id { get; set; }
        public List<LinkDto> Links { get; set; }
    }
}