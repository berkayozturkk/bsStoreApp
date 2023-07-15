using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTrasnferObjects
{
    public record BookDto
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public decimal Price { get; set; } 
    } 
}
