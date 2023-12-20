using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;

namespace HC.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<bool> Create(CreateUserRequest request);
        Task<bool> Update (Guid id, UpdateUserRequest request);
        Task<bool> Delete (Guid id);

        Task<UserResponse> GetById(Guid id);
        Task<IEnumerable<UserResponse>> GetAll();
    }
}
