using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Repository
{
    internal class NewsRepository : BaseRepository, INewsRepository
    {
        public List<News> GetNews()
        {
            return GenerateFakeNews();
        }

        private List<News> GenerateFakeNews()
        {
            return new List<News>
            {
                new News
                {
                    Id = Guid.NewGuid(),
                    Title = "Новость 1",
                    Content = "Конетент 1 новости",
                    PublishDate = DateTime.Now + TimeSpan.FromDays(new Random().Next(0, 7))
        },
                new News
                {
                    Id = Guid.NewGuid(),
                    Title = "Новость 2",
                    Content = "Конетент 2 новости",
                    PublishDate = DateTime.Now + TimeSpan.FromDays(new Random().Next(0, 7))
                },
                                new News
                {
                    Id = Guid.NewGuid(),
                    Title = "Новость 3",
                    Content = "Конетент 3 новости",
                    PublishDate = DateTime.Now + TimeSpan.FromDays(new Random().Next(0, 7))
                },
                                new News
                {
                    Id = Guid.NewGuid(),
                    Title = "Новость 4",
                    Content = "Конетент 4 новости",
                    PublishDate = DateTime.Now + TimeSpan.FromDays(new Random().Next(0, 7))
                },
            };
        }
    }
}
