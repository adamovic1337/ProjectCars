using Microsoft.AspNetCore.Mvc;
using ProjectCars.Repository.Helpers;
using System.Text.Json;

namespace ProjectCars.API.Helpers
{
    public static class Utility
    {
        public static void PaginationMetadata<T>(this ControllerBase controllerBase, PaginationData<T> paginationData)
        {
            var paginationMetadata = new
            {
                totalCount = paginationData.TotalCount,
                pageSize = paginationData.PageSize,
                currentPage = paginationData.CurrentPage,
                totalPages = paginationData.TotalPages,
            };

            controllerBase.Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
        }
    }
}