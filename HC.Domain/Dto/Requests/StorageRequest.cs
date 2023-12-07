using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Dto.Requests
{
    public class StorageRequest
    {
        //upload file
        public IFormFile File { get; set; }
    }
}
