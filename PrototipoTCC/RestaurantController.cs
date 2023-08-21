using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoTCC
{
    internal interface IRestaurantController
    {
        IEnumerable<Employee> GetAllEmployees(Restaurant restaurant);
        Restaurant Restaurant { get; }
        


    }
}
