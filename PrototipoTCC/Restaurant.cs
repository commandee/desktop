using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoTCC
{
    public class Restaurant
    {
        string Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }

        public string id;
        public string name;

        public Restaurant(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
