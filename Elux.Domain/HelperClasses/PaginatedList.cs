namespace Elux.Domain.HelperClasses
{
    /// <summary>
    /// Represents a paginated list of items, extending the functionality of a standard List<T>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class PaginatedList<T> : List<T>
    {
        /// <summary>
        /// Gets the current page index (zero-based).
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Gets the size of each page (number of items per page).
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets the total number of items across all pages.
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class
        /// by paginating an <see cref="IQueryable{T}"/> source.
        /// </summary>
        /// <param name="source">The queryable source of items to paginate.</param>
        /// <param name="pageIndex">The zero-based index of the current page.</param>
        /// <param name="pageSize">The size of each page.</param>
        public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            // Add the items for the current page.
            this.AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class
        /// by paginating an <see cref="IEnumerable{T}"/> source.
        /// </summary>
        /// <param name="source">The enumerable source of items to paginate.</param>
        /// <param name="pageIndex">The zero-based index of the current page.</param>
        /// <param name="pageSize">The size of each page.</param>
        public PaginatedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            // Add the items for the current page.
            this.AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class
        /// by paginating an <see cref="IEnumerable{T}"/> source.
        /// </summary>
        /// <param name="source">The enumerable source of items to paginate.</param>
        /// <param name="pageIndex">The zero-based index of the current page.</param>
        /// <param name="pageSize">The size of each page.</param>
        public PaginatedList(List<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            // Add the items for the current page.
            this.AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }
        /// <summary>
        /// Indicates whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        /// <summary>
        /// Indicates whether there is a next page.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }
    }
}
