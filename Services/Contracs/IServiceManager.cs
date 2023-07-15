using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracs
{
    public interface IServiceManager
    {
         IBookService BookService { get; }
    }
}
