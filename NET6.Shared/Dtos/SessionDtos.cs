using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Dtos
{
    public class SessionPostDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime PresentationDate { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
    }
}
