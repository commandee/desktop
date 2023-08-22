﻿using MySql.Data.MySqlClient;
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
    internal class RestaurantController : IRestaurantController
    {
        public Restaurant Restaurant { get; private set; }

        public void Login(Employee employee, string restName)
        {
            DAO_Conexao.con.Open();
            string sql = @"SELECT restaurant.public_id as id, restaurant.name, restaurant.address
                           FROM ownership
                           INNER JOIN restaurant on restaurant.id = ownership.restaurant_id
                           INNER JOIN employee on employee.id = ownership.employee_id
                           WHERE employee.public_id = @id AND restaurant.name = @name";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@id", employee.Id);
            command.Parameters.AddWithValue("@name", restName);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Restaurant = new Restaurant(reader.GetString("id"), reader.GetString("name"), reader.GetString("address"));
            }
            DAO_Conexao.con.Close();
        }

        public void AddEmployee(Employee employee)
        {
            DAO_Conexao.con.Open();
            string sql = @"INSERT INTO employment (restaurant_id, employee_id)
                           VALUES (
                             (SELECT id FROM restaurant WHERE restaurant.public_id = @restaurantID),
                             (SELECT id FROM employee WHERE employee.public_id = @employeeID))";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
            command.Parameters.AddWithValue("@employeeID", employee.Id);
            command.ExecuteNonQuery();
            DAO_Conexao.con.Close();

        }

        public IEnumerable<Employee> GetAdmins()
        {
            DAO_Conexao.con.Open();
            string sql = @"SELECT employee.public_id as id, employee.email, employee.username
                           FROM ownership
                           INNER JOIN restaurant on restaurant.id = ownership.restaurant_id
                           INNER JOIN employee on employee.id = ownership.employee_id
                           WHERE restaurant.public_id = @id";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@id", Restaurant.Id);
            MySqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee(reader.GetString("id"), reader.GetString("email"), reader.GetString("username"));
                employees.Add(employee);
            }
            DAO_Conexao.con.Close();
            return employees;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            DAO_Conexao.con.Open();
            string sql = @"SELECT employee.public_id as id, employee.email, employee.username
                           FROM employment
                           INNER JOIN restaurant on restaurant.id = employment.restaurant_id
                           INNER JOIN employee on employee.id = employment.employee_id
                           WHERE restaurant.public_id = @id";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@id", Restaurant.Id);
            MySqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee(reader.GetString("id"), reader.GetString("email"), reader.GetString("username"));
                employees.Add(employee);
            }   
            DAO_Conexao.con.Close();
            return employees;

        }

        public void Promote(Employee employee)
        {
            DAO_Conexao.con.Open();
            string sql = @"INSERT INTO ownership (restaurant_id, employee_id)
                           VALUES (
                             (SELECT id FROM restaurant WHERE public_id = @restaurantID),
                             (SELECT id FROM employee WHERE public_id = @employeeID))";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
            command.Parameters.AddWithValue("@employeeID", employee.Id);
            command.ExecuteNonQuery();
            DAO_Conexao.con.Close();
        }

        public void Demote(Employee employee)
        {
            DAO_Conexao.con.Open();
            string sql = @"DELETE FROM ownership
                           WHERE restaurant_id = (SELECT id FROM restaurant WHERE public_id = @restaurantID)
                           AND employee_id = (SELECT id FROM employee WHERE public_id = @employeeID)";  
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
            command.Parameters.AddWithValue("@employeeID", employee.Id);
            command.ExecuteNonQuery();
            DAO_Conexao.con.Close();
        }

        public void RemoveEmployee(Employee employee)
        {
            DAO_Conexao.con.Open();
            string sql = @"DELETE FROM employment
                           WHERE restaurant_id = (SELECT id FROM restaurant WHERE public_id = @restaurantID)
                           AND employee_id = (SELECT id FROM employee WHERE public_id = @employeeID)";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@restaurantID", Restaurant.Id);
            command.Parameters.AddWithValue("@employeeID", employee.Id);
            command.ExecuteNonQuery();
            DAO_Conexao.con.Close();
        }
    }

}