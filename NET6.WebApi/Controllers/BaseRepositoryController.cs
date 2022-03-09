using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6.Shared.Interfaces;
using NET6.Shared.Models;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseRepositoryController<T> : ControllerBase where T : class, IDbResource
    {
        private readonly ILogger _logger;
        private readonly IBaseDbRepository<T> _repo;

        public BaseRepositoryController(ILogger logger, IBaseDbRepository<T> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IList<T>?>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get items of type {type}", typeof(T));
                var items = await _repo.GetAllAsync();

                var response = new ApiResponse<IList<T>?> { Data = items };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ServerError(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<T>?>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Get item of type {type} with id = {id}", typeof(T), id);
                var item = await _repo.GetByIdAsync(id);
                if (item == null)
                {
                    _logger.LogWarning("Item of type {type} with id = {id} was not found", typeof(T), id);
                    return NotFound();
                }

                var response = new ApiResponse<T?> { Data = item };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ServerError(ex);
            }
        }

        protected ActionResult ServerError(Exception ex)
        {
            _logger.LogError("Server error: {message}", ex.Message);
            return Problem(statusCode: 500, title: "Server Error", detail: ex.Message, instance: HttpContext.TraceIdentifier);
        }
    }
}
