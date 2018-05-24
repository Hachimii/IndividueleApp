using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTHWebapp.Models.DomainClasses
{
    public class Role
    {
        public int FunctionID { get; set; }
        public string Name { get; set; }

        public Role(string naam)
        {
            Name = naam;
        }

        public Role()
        {

        }
    }
}
