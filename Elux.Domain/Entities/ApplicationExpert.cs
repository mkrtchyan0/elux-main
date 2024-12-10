namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents an expert in the application.
    /// </summary>
    public class ApplicationExpert
    {
        /// <summary>
        /// Gets or sets the unique identifier for the expert.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the expert.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the expert.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the profession of the expert.
        /// </summary>
        public string Proffesion { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the expert's background or specialization.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the years of experience the expert has.
        /// </summary>
        public int Experiense { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the expert is available.
        /// </summary>
        public DateTime ExpertsFreeTime { get; set; }

        /// <summary>
        /// Gets or sets a list of works the expert has performed.
        /// </summary>
        public List<ExpertsWork> Works { get; set; }

        /// <summary>
        /// Gets or sets a list of certificates the expert holds.
        /// </summary>
        public List<string> Certificate { get; set; }
    }
}
