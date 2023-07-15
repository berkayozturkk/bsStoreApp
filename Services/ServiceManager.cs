using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using Services.Contracs;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;

        public ServiceManager(IRepositoryManager repositoryManager
            ,ILoggerService logger)
        {
            _bookService = new Lazy<IBookService>(()
                => new BookManager(repositoryManager, logger));
        }

        public IBookService BookService => _bookService.Value;
    }
}
