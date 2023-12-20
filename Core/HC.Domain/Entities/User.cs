using HC.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HC.Domain.Enums;

namespace HC.Domain.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        [Phone]
        public string? Phone { get; set; }

        public List<string> FcmToken { get; set; } = new List<string>();        
        public DateTime? Birthday { get; set; }

        [MaxLength(255)]
        public string? AvatarUrl { get; set; }

        [MaxLength(50)]
        public string? FullName { get; set; }

        public Gender Gender { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;

        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual Chef? Chef { get; set; }
    }
}
