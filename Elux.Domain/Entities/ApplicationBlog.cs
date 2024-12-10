namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a blog application entity.
    /// </summary>
    public class ApplicationBlog
    {
        /// <summary>
        /// Gets or sets the unique identifier for the blog.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the blog.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description or content of the blog.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the release date of the blog post.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the picture URL or path associated with the blog post.
        /// </summary>
        public string Picture { get; set; }
    }
}
