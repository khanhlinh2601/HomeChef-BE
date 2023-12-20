using HC.Domain.Common;
using HC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities
{
    public class Promotion : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BannerUrl { get; set; }
        public PromotionStatus Status { get; set; }
    }
}
