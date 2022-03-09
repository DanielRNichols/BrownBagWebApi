﻿using Dapper.Contrib.Extensions;
using NET6.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Models
{
    [Table("SessionsPresenters")]
    public class SessionsPresenters : BaseDbResource
    {
        public int SessionId { get; set; }
        public int PresenterId { get; set; }

    }
}
