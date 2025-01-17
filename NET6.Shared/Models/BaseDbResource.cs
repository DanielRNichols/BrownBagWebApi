﻿using Dapper.Contrib.Extensions;
using NET6.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Models
{
    public abstract class BaseDbResource : IDbResource
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
