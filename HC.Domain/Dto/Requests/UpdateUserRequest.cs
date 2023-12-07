using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Dto.Requests
{
    public class UpdateUserRequest
    {
        public string Email { get; set; } = null!;
        public string? FullName { get; set; } = null!;
        public string? AvatarUrl { get; set; }
        public string Phone { get; set; } = null!;

        public string? IdentityCard { get; set; } 

        public string? Biography { get; set; }

    public List<Guid>? DistrictIds { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
