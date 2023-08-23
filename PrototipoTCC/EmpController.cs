﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DAO_Conexao.con.Open();

            string sql = @"INSERT INTO `employee` (`email`,`username`, `password`) 
                           VALUES (@email,@username,@password)";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            DAO_Conexao.con.Close();
        }

        public IEnumerable<Restaurant> WorksAt(Employee employee)
        {
            DAO_Conexao.con.Open();
            string sql = @"SELECT restaurant.public_id as id, restaurant.name, restaurant.address
                           FROM employment
                           INNER JOIN restaurant on restaurant.id = employment.restaurant_id
                           INNER JOIN employee on employee.id = employment.employee_id  
                           WHERE employee.public_id = @id";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@id", employee.Id);
            MySqlDataReader reader = command.ExecuteReader();
            List<Restaurant> restaurants = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant restaurant = new Restaurant(reader.GetString("id"), reader.GetString("name"), reader.GetString("address"));
                restaurants.Add(restaurant);
                
            }   
            return restaurants;
        }

        

        public IEnumerable<Restaurant> Owns(Employee employee)
        {
            DAO_Conexao.con.Open();
            string sql = @"SELECT restaurant.public_id as id, restaurant.name, restaurant.address
                           FROM ownership
                           INNER JOIN restaurant on restaurant.id = ownership.restaurant_id
                           INNER JOIN employee on employee.id = ownership.employee_id
                           WHERE employee.public_id = @id";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@id", employee.Id);
            MySqlDataReader reader = command.ExecuteReader();
            List<Restaurant> restaurants = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant restaurant = new Restaurant(reader.GetString("id"), reader.GetString("name"), reader.GetString("address"));
                restaurants.Add(restaurant);

            }
            return restaurants;
        }
        
        public IEnumerable<Employee> GetAll()
        {
            DAO_Conexao.con.Open();
            string sql = @"SELECT employee.username, employee.email, employee.public_id as id 
                           FROM employement 
                           INNER JOIN employee ON employee.id = employement.employee_id 
                           INNER JOIN restaurant ON restaurant.id = employement.restaurant_id 
                           WHERE restaurant.public_id = @id    
                           LIMIT 0, 1000";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            MySqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee(reader.GetString("username"), reader.GetString("email"), reader.GetString("id"));              
                employees.Add(employee);
            }
            DAO_Conexao.con.Close();

            return employees;
        }

        public bool IsAdmin(Employee employee)
        {
            DAO_Conexao.con.Open();
            string sql = @"SELECT employee.public_id as id FROM ownership
                           INNER JOIN employee ON employee.id = ownership.employee_id
                           INNER JOIN restaurant ON restaurant.id = ownership.restaurant_id
                           WHERE restaurant.public_id = @id   
                           LIMIT 1";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@id", employee.Id);
            var reader = command.ExecuteNonQuery();
            return reader != 0;
            
        }

        public Employee Login(string email, string senha)
        {
            if (DAO_Conexao.con.State == System.Data.ConnectionState.Closed)
            {
                DAO_Conexao.con.Open();
            }
     
            string sql = @"SELECT public_id as id, email, username, password FROM employee
                           WHERE employee.email = @email
                           LIMIT 1";
            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
            command.Parameters.AddWithValue("@email", email);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read()) { 
                string senhaDB = reader.GetString("password");
                if (senha == senhaDB)                
                {
                    var employee = new Employee(reader.GetString("id"), reader.GetString("username"), reader.GetString("email"));
                    DAO_Conexao.con.Close();
                    return employee;
                    //return new Employee(reader.GetString("id"), reader.GetString("username"), reader.GetString("email")); 
                    
                } else
                {
                    throw new Exception("Senha incorreta.");
                }
            } else
            {
                throw new Exception("Usuário não encontrado.");
            }
            
        }
    }
}
