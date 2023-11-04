using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoTCC
{
    internal interface IRestaurantController
    {
        void Login(Employee employee, string restName);

        void AddEmployee(Employee employee);
        
        void RemoveEmployee(Employee employee);

        IEnumerable<Employee> GetAdmins();

        IEnumerable<Employee> GetEmployees();

        void Promote(Employee employee);

        void Demote(Employee employee);

        Restaurant Restaurant { get; }
    }
    internal class RestaurantController 
    {
        public Restaurant Restaurant { get; private set; }

        public void Login(string restaurant)
        {
            string sql = @"SELECT restaurant.public_id as id, restaurant.name, restaurant.address, role
                           FROM employment
                           INNER JOIN restaurant on restaurant.id = employment.restaurant_id
                           INNER JOIN employee on employee.id = employment.employee_id
                           WHERE employee.public_id = @id AND restaurant.name = @name";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@id", Controllers.loginController.User.Id);
                command.Parameters.AddWithValue("@name", restaurant);

                using (var reader = command.ExecuteReader()) {
                    if (!reader.Read())
                        throw new Exception("Usuário não trabalha neste restaurante.");

                    if (reader.GetString("role") != "admin")
                        throw new Exception("Usuário não é administrador do restaurante");
                    Restaurant = new Restaurant(reader.GetString("id"), reader.GetString("name"), reader.GetString("address"));
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            string sql = @"INSERT INTO employment (restaurant_id, employee_id)
                           VALUES (
                             (SELECT id FROM restaurant WHERE restaurant.public_id = @restaurantID),
                             (SELECT id FROM employee WHERE employee.public_id = @employeeID))";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
                command.Parameters.AddWithValue("@employeeID", employee.Id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Employee> GetAdmins()
        {
            string sql = @"SELECT employee.public_id as id, employee.email, employee.username
                           FROM ownership
                           INNER JOIN restaurant on restaurant.id = ownership.restaurant_id
                           INNER JOIN employee on employee.id = ownership.employee_id
                           WHERE restaurant.public_id = @id";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@id", Restaurant.Id);

                using (var reader = command.ExecuteReader()) {
                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        Employee employee = new Employee(reader.GetString("id"), reader.GetString("email"), reader.GetString("username"));
                        employees.Add(employee);
                    }

                    return employees;
                }
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            string sql = @"SELECT employee.public_id as id, employee.email, employee.username
                           FROM employment
                           INNER JOIN restaurant on restaurant.id = employment.restaurant_id
                           INNER JOIN employee on employee.id = employment.employee_id
                           WHERE restaurant.public_id = @id";

            using ( var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@id", Restaurant.Id);
                using (var reader = command.ExecuteReader()) {
                    var employees = new List<Employee>();

                    while (reader.Read())
                    {
                        var employee = new Employee(reader.GetString("id"), reader.GetString("email"), reader.GetString("username"));
                        employees.Add(employee);
                    }   

                    return employees;
                }
            }
        }

        public void Dismiss(string email)
        {
            var con = DAO_Conexao.con;

            var sql = @"DELETE FROM employment
                        INNER JOIN employee ON employee.id = employment.employee_id
                        INNER JOIN restaurant ON restaurant.id = employment.restaurant_id
                        WHERE employee.email = @email
                        AND restaurant.public_id = @restaurantID";

            using (var command = new MySqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);

                var res = command.ExecuteNonQuery();

                if (res == 0)
                    throw new Exception("Usuário não encontrado");
            }
        }

        public void Demote(string email)
        {
            var con = DAO_Conexao.con;

            var sql = @"UPDATE employment
                        INNER JOIN employee ON employee.id = employment.employee_id
                        INNER JOIN restaurant ON restaurant.id = employment.restaurant_id
                        SET role = 'employee'
                        WHERE employee.email = @email
                        AND restaurant.public_id = @restaurantID";

            using (var command = new MySqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
                var res = command.ExecuteNonQuery();

                if (res == 0)
                    throw new Exception("Usuário não encontrado");
            }
        }

        public void Promote(Employee employee)
        {
            var sql = @"UPDATE employment
                        INNER JOIN employee ON employee.id = employment.employee_id
                        INNER JOIN restaurant ON restaurant.id = employment.restaurant_id
                        SET role = 'admin'
                        WHERE employee.public_id = @id
                        AND restaurant.public_id = @restaurantID";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
                command.Parameters.AddWithValue("@employeeID", employee.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Employ(string email) {
            var sql = @"INSERT INTO employment (restaurant_id, employee_id)
                        VALUES (
                            (SELECT id FROM restaurant WHERE restaurant.public_id = @restaurantID),
                            (SELECT id FROM employee WHERE employee.email = @email)
                        )";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
                command.Parameters.AddWithValue("@email", email);
                command.ExecuteNonQuery();
            }
        }
    }
}
