using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6.Shared.Dtos;
using NET6.Shared.Models;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsRepositoryController 
        : BaseRepositoryController<Session, SessionPostDto, SessionPutDto>
    {
        public SessionsRepositoryController(
            ILogger<SessionsRepositoryController> logger,
            ISessionsRepository repo,
            IMapper mapper) : base(logger, repo, mapper)
        {

        }
    }
}
