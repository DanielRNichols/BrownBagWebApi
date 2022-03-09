using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Dtos
{
    public class PresenterPostDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string ImageSmall { get; set; } = string.Empty;

    }
    public class PresenterPutDto : PresenterPostDto
    {
        public DateTime CreatedAt { get; set; }

    }
}
