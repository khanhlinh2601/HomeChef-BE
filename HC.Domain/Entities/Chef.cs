using HC.Domain.Common;
using HC.Domain.Enums;
using HC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities
{
    public class Chef : BaseEntity
    {
        public string IdentityCard { get; set; }
        public string Biography { get; set; }
        public double Wallet { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<District> Districts { get; set; } = new List<District>();
        
    }
}
