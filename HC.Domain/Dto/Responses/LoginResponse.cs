using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Dto.Responses
{
    public class LoginResponse
    {
        public bool IsFirstTime { get; set; }
        public string Token { get; set; } = null!;
        public UserResponse User { get; set; } = null!;
    }
}
