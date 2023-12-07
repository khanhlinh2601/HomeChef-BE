using HC.Domain.Common;
using HC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public User Customer { get; set; }
        public Guid ChefId { get; set; }    
        public User Chef { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CookingTime { get; set; }
        public int Hour { get; set; }
        public PaymentType PaymentType { get; set; }
        public double TotalPrice { get; set; }


    }
}
