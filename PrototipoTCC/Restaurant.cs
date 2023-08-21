using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoTCC
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Restaurant(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
