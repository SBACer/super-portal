using Mediator.ViewModel;
using System.Collections.Generic;

namespace Mediator.Interfaces
{
    public interface INewsService : IBaseService
    {
        List<NewsViewModel> GetNews();
    }
}
