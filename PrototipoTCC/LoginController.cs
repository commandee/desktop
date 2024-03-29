﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototipoTCC
{
    internal interface ILoginController
    {
        Employee User { get; }

        void Login(string email, string password);

        void Logout();
    }

    class LoginController : ILoginController
    {
        public Employee User { get; private set; }

        public static bool PasswordCompare(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public void Login(string email, string password)
        {
            
            var conn = DAO_Conexao.con;

            var sql = @"SELECT email, username, password, public_id as id
                        FROM employee
                        WHERE employee.email = @email
                      ";

            using (var command = new MySqlCommand(sql, conn)) {
                command.Parameters.AddWithValue("@email", email);

                using (var reader = command.ExecuteReader()) {
                    if (!reader.Read())
                        throw new Exception("Usuário não encontrado");

                    var dbPassword = reader.GetString("password");

                    if (!PasswordCompare(password, dbPassword)) 
                        throw new Exception("Senha incorreta");

                    User = new Employee(reader.GetString("id"), reader.GetString("username"), reader.GetString("email"));
                }
            }
        }

        public void Logout()
        {
            if (User == null)
                throw new Exception("Não há login");

            User = null;
        }
    }
}
