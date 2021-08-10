using Microsoft.AspNetCore.Mvc;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Repository.Helpers;
using System.Text.Json;

namespace ProjectCars.API.Helpers
{
    public static class Utility
    {
        public static void PaginationMetadata<T>(this ControllerBase controllerBase, PagedList<T> pagedEntity) 
        {
            var paginationMetadata = new
            {
                totalCount = pagedEntity.TotalCount,
                pageSize = pagedEntity.PageSize,
                currentPage = pagedEntity.CurrentPage,
                totalPages = pagedEntity.TotalPages,
            };

            controllerBase.Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
        }
    }
}