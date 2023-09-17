using Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracs
{
    public interface IDataShaper<T>
    {
        IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities ,string filedString);
        ShapedEntity ShapeData(T entity,string filedString);
    }
}
