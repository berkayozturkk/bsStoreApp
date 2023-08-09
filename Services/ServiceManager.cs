using AutoMapper;
using Entities.DataTrasnferObjects;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using Services.Contracs;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;

        public ServiceManager(IRepositoryManager repositoryManager
            ,ILoggerService logger
            ,IMapper mapper
            ,IDataShaper<BookDto> shapper)
        {
            _bookService = new Lazy<IBookService>(()
                => new BookManager(repositoryManager, logger, mapper, shapper));
        }

        public IBookService BookService => _bookService.Value;
    }
}
