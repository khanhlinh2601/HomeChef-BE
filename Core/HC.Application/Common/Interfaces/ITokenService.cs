using HC.Domain.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GetTokenAsync(UserResponse request);
    }
}
