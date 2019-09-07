using ApplicationCore.Interfaces;
using AutoMapper;
using Mediator.Interfaces;
using Mediator.ViewModel;
using System.Collections.Generic;

namespace Mediator.Services
{
    internal class NewsService : BaseService, INewsService
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;

        public NewsService(IMapper mapper, INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }

        public List<NewsViewModel> GetNews()
        {
            var domainResult = newsRepository.GetNews();
            return mapper.Map<List<NewsViewModel>>(domainResult);
        }
    }
}
