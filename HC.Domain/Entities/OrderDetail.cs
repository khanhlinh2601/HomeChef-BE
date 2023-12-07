using HC.Domain.Common;
using HC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public string Dish { get; set; }
        public DishType DishType { get; set;}
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
