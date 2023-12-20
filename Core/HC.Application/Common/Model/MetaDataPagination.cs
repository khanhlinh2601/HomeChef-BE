using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Common.Model
{
    public class MetaDataPagination
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
    }
}
