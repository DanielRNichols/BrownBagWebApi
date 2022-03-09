using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6.Shared.Models;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsRepositoryController : BaseRepositoryController<Session>
    {
        public SessionsRepositoryController(
            ILogger<SessionsRepositoryController> logger,
            ISessionsRepository repo) : base(logger, repo)
        {

        }
    }
}
