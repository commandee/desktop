using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoTCC
{
    public class Employee
    {
        string Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string Username { get; set; }


        public string id;
        public string email;
        public string password;
        public string name;
        public string createdAt;
        public string updatedAt;
        public string username;

        public Employee(string id, string email, string name, string createdAt, string updatedAt, string username)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.username = username;
        }


            }
    
}
