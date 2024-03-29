﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PrototipoTCC
{
    internal interface IEmpController
    {

        void Create(string email, string username, string password);

        bool IsAdmin(Employee employee);

        Employee Login(string email, string senha);

        IEnumerable<Employee> GetAll();
        IEnumerable<Restaurant> WorksAt(Employee employee);

        IEnumerable<Restaurant> Owns(Employee employee);
    }
    internal class EmpController : IEmpController
    {
        public void Create(string email, string username, string password)
        {
            var con = DAO_Conexao.con;

            var sql = @"INSERT INTO `employee` 
                        (`email`,`username`, `password`) 
                        VALUES (@email,@username,@password)";

            using (var command = new MySqlCommand(sql, con)) {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Restaurant> WorksAt(Employee employee)
        {
            var con = DAO_Conexao.con;

            var sql = @"SELECT restaurant.public_id as id, restaurant.name, restaurant.address
                        FROM employment
                        INNER JOIN restaurant on restaurant.id = employment.restaurant_id
                        INNER JOIN employee on employee.id = employment.employee_id  
                        WHERE employee.public_id = @id";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@id", employee.Id);

                using (var reader = command.ExecuteReader()) {
                    var restaurants = new List<Restaurant>();
                    while (reader.Read())
                    {
                        var restaurant = new Restaurant(reader.GetString("id"), reader.GetString("name"), reader.GetString("address"));
                        restaurants.Add(restaurant);
                    }

                    return restaurants;
                }
            }
        }

        public IEnumerable<Restaurant> Owns(Employee employee)
        {
            var con = DAO_Conexao.con;

            var sql = @"SELECT restaurant.public_id as id, restaurant.name, restaurant.address
                           FROM employment
                           INNER JOIN restaurant on restaurant.id = employment.restaurant_id
                           INNER JOIN employee on employee.id = employment.employee_id
                           WHERE employee.public_id = @id AND role = 'admin'";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                command.Parameters.AddWithValue("@id", employee.Id);

                using (var reader = command.ExecuteReader()) {
                    List<Restaurant> restaurants = new List<Restaurant>();

                    while (reader.Read())
                    {
                        Restaurant restaurant = new Restaurant(reader.GetString("id"), reader.GetString("name"), reader.GetString("address"));
                        restaurants.Add(restaurant);
                    }

                    return restaurants;
                }
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            var sql = @"SELECT employee.username, employee.email, employee.public_id as id 
                           FROM 
                           INNER JOIN employee ON employee.id = employment.employee_id 
                           INNER JOIN restaurant ON restaurant.id = employment.restaurant_id 
                           WHERE restaurant.public_id = @id    
                           LIMIT 0, 1000";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con))
            {
                using (var reader = command.ExecuteReader()) {
                    List<Employee> employees = new List<Employee>();
                    while (reader.Read())
                    {
                        Employee employee = new Employee(reader.GetString("username"), reader.GetString("email"), reader.GetString("id"));
                        employees.Add(employee);
                    }

                    return employees;
                }
            }
        }

        public bool IsAdmin(Employee employee)
        {
            var con = DAO_Conexao.con;

            var sql = @"SELECT employee.public_id as id FROM ownership
                           INNER JOIN employee ON employee.id = ownership.employee_id
                           INNER JOIN restaurant ON restaurant.id = ownership.restaurant_id
                           WHERE restaurant.public_id = @id   
                           LIMIT 1";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con))
            {
                command.Parameters.AddWithValue("@id", employee.Id);
                var reader = command.ExecuteNonQuery();

                return reader != 0;
            }
        }

        public Employee Employee { get; private set; }

        public Employee Login(string email, string senha)
        {
            var con = DAO_Conexao.con;

            var sql = @"SELECT public_id as id, email, username, password FROM employee
                           WHERE employee.email = @email
                           LIMIT 1";

            using (var command = new MySqlCommand(sql, DAO_Conexao.con))
            {
                command.Parameters.AddWithValue("@email", email);

                using (var reader = command.ExecuteReader()) {
                    if (reader.Read())
                    {
                        string senhaDB = reader.GetString("password");
                        if (senha == senhaDB)
                        {
                            var employee = new Employee(reader.GetString("id"), reader.GetString("username"), reader.GetString("email"));
                            Employee = employee;
                            return employee;
                            //return new Employee(reader.GetString("id"), reader.GetString("username"), reader.GetString("email")); 
                        }
                        else throw new Exception("Senha incorreta.");
                    }
                    else throw new Exception("Usuário não encontrado.");
                }
            }
        }
    }
}
