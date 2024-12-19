using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Domain.Entities
{
    public class ServiceGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ServiceGroupName { get; set; }
        public string ServiceDescription { get; set; }
        public string Picture { get; set; }
    }
}
