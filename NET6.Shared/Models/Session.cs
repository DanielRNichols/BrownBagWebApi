﻿using Dapper.Contrib.Extensions;
using NET6.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Models
{
    [Table("Sessions")]
    public class Session : BaseDbResource
    {
        public string Name { get; set; } = string.Empty;
        public DateTime PresentationDate { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;


        [Write(false)]
        public IList<Presenter> Presenters { get; set; } = new List<Presenter>();
    }
}
