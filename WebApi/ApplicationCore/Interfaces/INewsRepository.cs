using ApplicationCore.Models;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface INewsRepository : IBaseRepository
    {
        List<News> GetNews();
    }
}
