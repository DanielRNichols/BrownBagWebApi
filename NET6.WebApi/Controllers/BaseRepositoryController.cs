using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6.Shared.Interfaces;
using NET6.Shared.Models;
using NET6.WebApi.Database;
using NET6.WebApi.Repositories;

namespace NET6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseRepositoryController<T, R, P, U> : ControllerBase 
        where T : class, IDbResource  // Model Class
        where R : class   // ResponseDto class 
        where P : class   // PostDto class
        where U : class   // PutDto class
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
        public virtual async Task<ActionResult<ApiResponse<IList<R>>>> GetAll([FromQuery] QueryOptions? queryOptions)
        {
            _logger.LogInformation("Get items of type {type}", typeof(T));
            var items = await _repo.GetAllAsync(queryOptions);

            var response = new ApiResponse<IList<R>> { Data = _mapper.Map<IList<R>>(items) };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ApiResponse<R>>> GetById(int id, [FromQuery] bool includeRelated)
        {
            _logger.LogInformation("Get item of type {type} with id = {id}", typeof(T), id);
            var item = await _repo.GetByIdAsync(id, includeRelated);
            if (item == null)
            {
                _logger.LogWarning("Item of type {type} with id = {id} was not found", typeof(T), id);
                return NotFound();
            }

            var response = new ApiResponse<R> { Data = _mapper.Map<R>(item) };

            return Ok(response);
        }

        [HttpPost]
        public virtual async Task<ActionResult<ApiResponse<int>>> Add([FromBody] P dto)
        {
            _logger.LogInformation("Adding item of type {type}", typeof(T));

            var item = _mapper.Map<T>(dto);
            // Set the CreateAt date
            item.CreatedAt = DateTime.Now;
            var id = await _repo.AddAsync(item);
            var response = new ApiResponse<int> { Data = id };

            return CreatedAtAction(nameof(GetById), new { Id = id }, response);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<ApiResponse<bool>>> Update([FromRoute] int id, [FromBody] U dto)
        {
            _logger.LogInformation("Adding item of type {type}", typeof(T));

            var item = _mapper.Map<T>(dto);
            // Set item Id and ModifiedAt date
            item.Id = id;
            item.ModifiedAt = DateTime.Now;

            var success = await _repo.UpdateAsync(item);
            var response = new ApiResponse<bool> { Data = success };

            return CreatedAtAction(nameof(GetById), new { Id = id }, response);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Delete item of type {type} with id = {id}", typeof(T), id);

            var success = await _repo.DeleteAsync(id);
            if (!success)
            {
                _logger.LogWarning("Item of type {type} with id = {id} was not found", typeof(T), id);
                return NotFound();
            }

            return NoContent();
        }
    }
}
