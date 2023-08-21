using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoTCC
{
    internal class Employee
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }


        public Employee(string id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

    }
}
