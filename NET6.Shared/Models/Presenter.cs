﻿using Dapper.Contrib.Extensions;
using NET6.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Models
{
    [Table("Presenters")]
    public class Presenter : BaseDbResource
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;


        [Write(false)]
        public IList<Session> Sessions { get; set; } = new List<Session>();
    }
}
