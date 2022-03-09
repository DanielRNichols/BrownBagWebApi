using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6.Shared.Interfaces;
using NET6.Shared.Models;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseRepositoryController<T, P> : ControllerBase 
        where T : class, IDbResource  // Model Class
        where P : class  // PostDto class
    {
        private readonly ILogger _logger;
        private readonly IBaseDbRepository<T> _repo;
        private readonly IMapper _mapper;

        public BaseRepositoryController(ILogger logger, IBaseDbRepository<T> repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<ActionResult<ApiResponse<int>>> Add([FromBody] P dto)
        {
            try
            {
                _logger.LogInformation("Adding item of type {type}", typeof(T));

                var item = _mapper.Map<T>(dto);
                var id = await _repo.AddAsync(item);
                var response = new ApiResponse<int> { Data = id };

                return CreatedAtAction(nameof(GetById), new { Id = id }, response);
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
