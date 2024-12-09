namespace Elux.Domain.Entities
{
    public class ApplicationBlog
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Picture { get; set; }
    }
}
