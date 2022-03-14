using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6.Shared.Dtos;
using NET6.Shared.Models;
using NET6.WebApi.Database;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentersController 
        : BaseRepositoryController<Presenter, PresenterResponseDto, PresenterPostDto, PresenterPutDto>
    {
        public PresentersController(
            ILogger<PresentersController> logger,
            IPresentersRepository repo,
            IMapper mapper) : base(logger, repo, mapper)
        {
        }

        [HttpGet]
        [Authorize(Roles = "PowerUser")]
        public override Task<ActionResult<ApiResponse<IList<PresenterResponseDto>>>> GetAll([FromQuery] QueryOptions? queryOptions)
        {
            return base.GetAll(queryOptions);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public override Task<ActionResult<ApiResponse<PresenterResponseDto>>> GetById([FromRoute] int id, [FromQuery] bool includeRelated)
        {
            return base.GetById(id, includeRelated);
        }

    }
}
