using NET6.WebApi.Database;
using NET6.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NET6.WebApi.Test.IntegrationTests
{
    public class PresentersRepositoryTests
    {
        private const string _connectionString = "Server=localhost\\sqlexpress; Database=brownbags_integrationtests; Trusted_Connection=true; TrustServerCertificate=true; Encrypt=false; MultipleActiveResultSets=true";
        private readonly BrownBagConnection _dbConfig;
        private readonly IPresentersRepository _repo;

        public PresentersRepositoryTests()
        {
            _dbConfig = new BrownBagConnection();
            _dbConfig.UseSql(_connectionString);

            //initData();

            _repo = new PresentersRepository(_dbConfig);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnExactCount()
        {
            // Arrange

            // Act
            var result = await _repo.GetAllAsync(null);

            // Assert
            Assert.Equal(7, result?.Count);
        }

        [Fact]
        public async Task GetAllAsyncWithFilter_ShouldReturnExactCount()
        {
            // Arrange
            var queryOptions = new QueryOptions { Filter = "Name like '%o%'" };

            // Act
            var result = await _repo.GetAllAsync(queryOptions);

            // Assert
            Assert.Equal(4, result?.Count);
        }

        [Fact]
        public async Task GetAllAsync_OrderByDescShouldReturnGeorgeFirst()
        {
            // Arrange
            var queryOptions = new QueryOptions { OrderBy = "Name desc" };

            // Act
            var result = await _repo.GetAllAsync(queryOptions);

            // Assert
            Assert.Equal(9, result?.FirstOrDefault()?.Id);

        }

        [Fact]
        public async Task GetAllAsync_SkipShouldReturnExactCount()
        {
            // Arrange
            var queryOptions = new QueryOptions { Skip = 3 };

            // Act
            var result = await _repo.GetAllAsync(queryOptions);

            // Assert
            Assert.Equal(4, result?.Count);

        }

        [Fact]
        public async Task GetAllAsync_LimitShouldReturnExactCount()
        {
            // Arrange
            var queryOptions = new QueryOptions { Limit = 3 };

            // Act
            var result = await _repo.GetAllAsync(queryOptions);

            // Assert
            Assert.Equal(3, result?.Count);

        }

        [Fact]
        public async Task GetAllAsync_SkipWithLimitShouldReturnExactCount()
        {
            // Arrange
            var queryOptions = new QueryOptions { Skip = 3, Limit = 2 };

            // Act
            var result = await _repo.GetAllAsync(queryOptions);

            // Assert
            Assert.Equal(2, result?.Count);
        }
    }
}
