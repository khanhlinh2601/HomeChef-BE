using HC.Domain.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Common.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadFile(StorageRequest request);
    }
}
