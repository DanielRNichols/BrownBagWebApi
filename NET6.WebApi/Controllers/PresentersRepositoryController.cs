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
    public class PresentersRepositoryController : BaseRepositoryController<Presenter, PresenterPostDto>
    {
        public PresentersRepositoryController(
            ILogger<PresentersRepositoryController> logger,
            IPresentersRepository repo,
            IMapper mapper) : base(logger, repo, mapper)
        {

        }
    }
}
