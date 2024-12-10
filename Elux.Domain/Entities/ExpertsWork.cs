namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents an expert's work or specialization.
    /// </summary>
    public class ExpertsWork
    {
        /// <summary>
        /// Gets or sets the unique identifier for the expert's work.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name or title of the work or specialization.
        /// </summary>
        public string WorkName { get; set; }
    }
}
