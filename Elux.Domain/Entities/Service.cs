using System.ComponentModel.DataAnnotations;

namespace Elux.Domain.Entities
{
    public class Service
    {       
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        //public ServiceGroup ServiceGroup { get; set; }
        public string ServiceName { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
    }
}
