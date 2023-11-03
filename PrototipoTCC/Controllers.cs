using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoTCC
{
    internal static class Controllers
    {
        public static readonly EmpController empController = new EmpController();
        public static readonly RestaurantController restaurantController = new RestaurantController();
    }
}
