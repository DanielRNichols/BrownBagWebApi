using AutoMapper;
using NET6.Shared.Dtos;
using NET6.Shared.Models;

namespace NET6.WebApi.MappingProfiles
{
    public class RepositoryMappingProfiles : Profile
    {
        public RepositoryMappingProfiles()
        {
            CreateMap<PresenterPostDto, Presenter>();
            CreateMap<PresenterPutDto, Presenter>();
            CreateMap<SessionPostDto, Session>();
            CreateMap<SessionPutDto, Session>();
            CreateMap<SessionsPresentersPostDto, SessionsPresenters>();
            CreateMap<SessionsPresentersPutDto, SessionsPresenters>();
        }
    }
}
