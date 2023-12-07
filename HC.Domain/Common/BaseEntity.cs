﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; init; }


        public bool IsDeleted { get; set; } = false;
    }
}