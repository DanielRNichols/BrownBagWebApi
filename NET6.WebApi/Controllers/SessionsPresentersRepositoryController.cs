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
    public class SessionsPresentersRepositoryController 
        : BaseRepositoryController<SessionsPresenters, SessionsPresentersResponseDto, SessionsPresentersPostDto, SessionsPresentersPutDto>
    {
        public SessionsPresentersRepositoryController(
            ILogger<SessionsRepositoryController> logger,
            ISessionsPresentersRepository repo,
            IMapper mapper) : base(logger, repo, mapper)
        {

        }
    }
    
}
