using HC.Domain.Common;
using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Entities;

public class Feedback : BaseEntity
{
    public Order Order { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int Rating { get; set; } = 1;
}

