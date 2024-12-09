namespace Elux.Domain.Entities
{
    public class ApplicationExpert
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Proffesion { get; set; }
        public string Description { get; set; }
        public int Experiense { get; set; }
        public DateTime ExpertsFreeTime { get; set; }
        public List<ExpertsWork> Works{ get; set; }
        public List<string> Certificate {  get; set; }
    }
}
