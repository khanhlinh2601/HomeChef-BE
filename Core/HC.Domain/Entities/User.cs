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
using HC.Domain.Common.Enums;

namespace HC.Domain.Entities;

public class User : BaseEntity
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public List<string> FcmToken { get; set; } = new List<string>();
    public DateTime? Birthday { get; set; }
    public string? AvatarUrl { get; set; }
    public string? FullName { get; set; }
    public Gender Gender { get; set; }
    public Role Role { get; set; } 
    public bool EmailConfirmed { get; set; } = false;
    public bool PhoneConfirmed { get; set; } = false;
    public string? PasswordHash { get; set; }
    public List<District> Districts { get; set; } = new List<District>();
    public List<string>? IdentityCard { get; set; }
    public string? Description { get; set; }
    public long Wallet { get; set; } = 0;
    public AuthProviderType Provider { get; set; }
}

