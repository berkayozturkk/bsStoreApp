using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTrasnferObjects
{
    //public record BookDtoForUpdate
    //{
    //    public int Id { get; init; }
    //    public string Title { get; init; }
    //    public decimal Price { get; init; }
    //}

    public record BookDtoForUpdate(int Id,String Title,decimal Price);
}
