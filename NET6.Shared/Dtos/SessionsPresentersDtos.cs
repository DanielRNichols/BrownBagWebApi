using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Dtos
{
    public class SessionsPresentersResponseDto
    {
        public int SessionId { get; set; }
        public int PresenterId { get; set; }
    }

    public class SessionsPresentersPostDto
    {
        public int SessionId { get; set; }
        public int PresenterId { get; set; }
    }

    public class SessionsPresentersPutDto : SessionsPresentersPostDto
    {
        public DateTime CreatedAt { get; set; }
    }


}
