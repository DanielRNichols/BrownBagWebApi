using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NET6.Shared.Dtos;
using NET6.Shared.Models;
using NET6.WebApi.Controllers;
using NET6.WebApi.Repositories;
using NET6.WebApi.Test.MockData;
using System.Collections.Generic;
using Xunit;

namespace NET6.WebApi.Test.UnitTests
{
    public class PresentersControllerTests
    {
        private readonly Mock<ILogger<PresentersController>> _logger;
        private readonly Mock<IPresentersRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PresentersController _controller;

        public PresentersControllerTests()
        {
            _logger = new Mock<ILogger<PresentersController>>();
            _mockRepo = new Mock<IPresentersRepository>();
            _mockMapper = new Mock<IMapper>();

            _controller = new PresentersController(_logger.Object, _mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async void GetAll_ReturnsExactCount()
        {
            // Arrange
            var presenters = PresentersMockData.MockPresenters();
            _mockRepo.Setup(repo => repo.GetAllAsync(null))
                .ReturnsAsync(presenters);

            _mockMapper.Setup(mapper => mapper.Map<IList<PresenterResponseDto>>(presenters))
                .Returns(PresentersMockData.MockPresentersResponse());

            // Act
            var result = await _controller.GetAll(null);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ApiResponse<IList<PresenterResponseDto>>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var apiResponse = Assert.IsType<ApiResponse<IList<PresenterResponseDto>>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal(3, apiResponse.Data?.Count);
        }

        [Fact]
        public async void Add_Returns_CreatedAtAction()
        {
            // Arrange
            var presenterDto = new PresenterPostDto();
            var presenter = PresentersMockData.MockPresenterAdded();
            _mockRepo.Setup(repo => repo.AddAsync(presenter))
                            .ReturnsAsync(presenter.Id);

            _mockMapper.Setup(mapper => mapper.Map<Presenter>(presenterDto))
                .Returns(presenter);

            // Act
            var result = await _controller.Add(presenterDto);

            // Assert
            var createdAtResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<int>>(createdAtResult.Value);
            Assert.Equal("getbyid", createdAtResult.ActionName?.ToLower());
            Assert.Equal("Id", (createdAtResult.RouteValues.Keys as string[])[0]);
            Assert.Equal(apiResponse.Data, (createdAtResult.RouteValues.Values as object[])[0]);
        }
    }
}