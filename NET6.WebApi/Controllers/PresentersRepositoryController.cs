using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6.Shared.Models;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentersRepositoryController : BaseRepositoryController<Presenter>
    {
        public PresentersRepositoryController(
            ILogger<PresentersRepositoryController> logger,
            IPresentersRepository repo) : base(logger, repo)
        {

        }
    }
}
