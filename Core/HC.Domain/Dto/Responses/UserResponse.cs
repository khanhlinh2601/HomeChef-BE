using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HC.Domain.Dto.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Phone { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IdentityCard { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Biography { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Wallet { get; set; }

        public DateTime? Birthday { get; set; }
        public string Role { get; set; } = null!;

        public UserResponse(User user) { 
            Id = user.Id;
            Email = user.Email;
            FullName = user.FullName;
            AvatarUrl = user.AvatarUrl;
            Phone = user.Phone;
            Birthday = user.Birthday;
            Role = user.Role.Name;
            if (user.Chef != null && user.Role.Name.Equals("Chef"))
            {
                IdentityCard = user.Chef.IdentityCard;
                Biography = user.Chef.Biography;
                Wallet = user.Chef.Wallet;
            }
        }

    }
}
