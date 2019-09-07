using ApplicationCore.Models;
using AutoMapper;
using Mediator.Interfaces;
using Mediator.ViewModel;

namespace Mediator.Profiles
{
    internal class NewsProfile : Profile, IBaseProfile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsViewModel>();
        }
    }
}
