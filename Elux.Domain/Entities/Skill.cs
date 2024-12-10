namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a skill entity, with a unique identifier and a name for the skill.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Gets or sets the unique identifier for the skill.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the skill.
        /// </summary>
        public string SkillName { get; set; }
    }
}
