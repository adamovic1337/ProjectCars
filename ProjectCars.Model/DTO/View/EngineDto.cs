﻿namespace ProjectCars.Model.DTO.View
{
    public class EngineDto : BaseViewDTO
    {
        public int Id { get; set; }
        public int CubicCapacity { get; set; }
        public int Power { get; set; }
        public int FuelTypeId { get; set; }
    }
}
