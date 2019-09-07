using Mediator.Interfaces;
using Mediator.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SuperPortal2._0.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet("[action]")]
        public List<NewsViewModel>GetNews()
        {
            return newsService.GetNews();
        }
    }
}
