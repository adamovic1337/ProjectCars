using Microsoft.AspNetCore.Mvc;
using ProjectCars.Repository.Helpers;
using System.Text.Json;

namespace ProjectCars.API.Helpers
{
    public class Pagination : ControllerBase
    {
        public void GetMetadata<T>(PagedList<T> pagedList)
        {
            var paginationMetadata = new
            {
                totalCount = pagedList.TotalCount,
                pageSize = pagedList.PageSize,
                currentPage = pagedList.CurrentPage,
                totalPages = pagedList.TotalPages,
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
        }
    }
}