using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NET6.Shared.Dtos;
using NET6.Shared.Models;
using NET6.WebApi.Controllers;
using NET6.WebApi.MappingProfiles;
using NET6.WebApi.Repositories;
using System.Collections.Generic;
using Xunit;

namespace NET6.WebApi.Test
{
    public class PresentersControllerTests
    {
        private readonly Mock<ILogger<PresentersController>> _logger;
        private readonly Mock<IPresentersRepository> _mockRepo;
        private readonly PresentersController _controller;
        private readonly IMapper _mapper;


        public PresentersControllerTests()
        {
            _logger = new Mock<ILogger<PresentersController>>();
            _mockRepo = new Mock<IPresentersRepository>();

            // AutoMapper
            var config = new MapperConfiguration(cfg => cfg.AddMaps(new[] { typeof(RepositoryMappingProfiles) }));
            _mapper = new Mapper(config);
            _controller = new PresentersController(_logger.Object, _mockRepo.Object, _mapper);
        }

        [Fact]
        public async void GetAll_ReturnsExactCount()
        {
            // Arrange
            _mockRepo.Setup((repo) => repo.GetAllAsync(null))
                .ReturnsAsync(new List<Presenter>
                {
                    new Presenter{},
                    new Presenter{}
                });

            // Act
            var result = await _controller.GetAll(null);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ApiResponse<IList<PresenterResponseDto>>>> (result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var apiResponse = Assert.IsType<ApiResponse<IList<PresenterResponseDto>>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal(2, apiResponse.Data?.Count);
        }

        [Fact]
        public async void Create_Returns_CreatedAtAction()
        {
            // Arrange
            var presenter = new Presenter();
            _mockRepo.Setup((repo) => repo.AddAsync(presenter));

            // Act
            var presenterDto = new PresenterPostDto();
            var result = await _controller.Add(presenterDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ApiResponse<int>>>(result);
            var createdAtResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var apiResponse = Assert.IsType<ApiResponse<int>>(createdAtResult.Value);
            Assert.Equal("getbyid", createdAtResult.ActionName?.ToLower());
            //Assert.Equal("Id", createdAtResult.)
        }
    }
}