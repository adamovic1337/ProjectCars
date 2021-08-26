using System;
using System.Linq;

namespace ProjectCars.Repository.Helpers
{
    public class PaginationData<T>
    {
        #region FIELDS

        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);

        #endregion FIELDS

        #region CONSTRUCTORS

        private PaginationData(int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public static PaginationData<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            return new PaginationData<T>(count, pageNumber, pageSize);
        }

        #endregion METHODS
    }
}