﻿namespace ProjectCars.Model.DTO.Search
{
    public class SearchCarDto : BaseSearch
    {
        public string ModelName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "modelName-asc";
    }
}