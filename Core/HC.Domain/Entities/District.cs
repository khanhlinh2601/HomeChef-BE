using HC.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; }

        public Guid ProvinceId { get; set; }

        public Province Province { get; set; }


        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
        public virtual ICollection<Chef> Chefs { get; set; } = new List<Chef>();

    }
}
