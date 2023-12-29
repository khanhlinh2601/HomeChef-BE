using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HC.Domain.Dto.Requests;

public class UpdateUserRequest
{
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Phone { get; set; }
    public List<string>? IdentityCard { get; set; }
    public string? Biography { get; set; }
    public DateTime? Birthday { get; set; }
}
