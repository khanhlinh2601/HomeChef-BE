using HC.Domain.Common;
using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public string Content { get; set; }
        public string CustomerId { get; set; }
        public User Customer { get; set; }
        public string ChefId { get; set; }
        public User Chef { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Rating { get; set; }
    }
}
