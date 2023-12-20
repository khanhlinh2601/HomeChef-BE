
using HC.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities
{
    public class CustomerAddress : BaseEntity
    {
        public string HouseNumber { get; set; }
        public string HouseType { get; set; }
        public string Ward { get; set; }
        public Guid DistrictId { get; set; }
        public District District { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
