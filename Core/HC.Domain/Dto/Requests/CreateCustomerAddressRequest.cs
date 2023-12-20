using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Dto.Requests
{
    public class CreateCustomerAddressRequest
    {
        public string HouseNumber { get; set; } = null!;
        public string HouseType { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public Guid DistrictId { get; set; }
        public Guid UserId { get; set;}
    }
}
