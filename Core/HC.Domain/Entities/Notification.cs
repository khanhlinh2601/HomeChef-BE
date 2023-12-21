using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HC.Domain.Common;

namespace HC.Domain.Entities;

public class Notification : BaseEntity
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid ReceiverId { get; set; }
}

