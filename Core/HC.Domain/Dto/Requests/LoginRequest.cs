using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Dto.Requests
{
    public class LoginRequest
    {
        public string IdToken { get; set; } = null!;
        public string? FcmToken { get; set; }
        public Guid RoleId { get; set; }
    }
}
