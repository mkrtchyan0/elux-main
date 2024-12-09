namespace Elux.Domain.Entities
{
    public class ServiceGroup
    {
        public Guid Id { get; set; }
        //public ICollection<Service> Services { get; set; }
        public string ServiceGroupName { get; set; }
        public string ServiceDescription { get; set; }
        public string Picture { get; set; }
    }
}
