using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.LinkModels
{
    public class Link
    {
        public string? HRef { get; set; }
        public string? Relation { get; set; }
        public string? Method { get; set; }

        public Link()
        {
                
        }

        public Link(string? hRef, string? relation, string? method)
        {
            HRef = hRef;
            Relation = relation;
            Method = method;
        }
    }
}
