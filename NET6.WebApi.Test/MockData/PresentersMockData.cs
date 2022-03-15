using NET6.Shared.Dtos;
using NET6.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.WebApi.Test.MockData
{
    public class PresentersMockData
    {
        public static IList<Presenter> MockPresenters()
        {
            return new List<Presenter>
            {
                new Presenter{Id = 1, Name = "Al Alberts",   Bio = "AAA", CreatedAt = DateTime.Now },
                new Presenter{Id = 2, Name = "Bob Baker",    Bio = "BBB", CreatedAt = DateTime.Now },
                new Presenter{Id = 3, Name = "Carla Carlos", Bio = "CCC", CreatedAt = DateTime.Now },
            };
        }

        public static IList<PresenterResponseDto> MockPresentersResponse()
        {
            return new List<PresenterResponseDto>
            {
                new PresenterResponseDto{Id = 1, Name = "Al Alberts",   Bio = "AAA", CreatedAt = DateTime.Now },
                new PresenterResponseDto{Id = 2, Name = "Bob Baker",    Bio = "BBB", CreatedAt = DateTime.Now },
                new PresenterResponseDto{Id = 3, Name = "Carla Carlos", Bio = "CCC", CreatedAt = DateTime.Now },
            };
        }



        public static PresenterPostDto MockPresenterPostDto()
        {
            return new PresenterPostDto { Name = "Dave Davis", Bio = "DDD" };

        }
        public static Presenter MockPresenterAdded()
        {
            return new Presenter { Id = 4, Name = "Dave Davis", Bio = "DDD" };

        }
    }
}
