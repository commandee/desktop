using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Permissions;
using System.Windows.Forms;

namespace PrototipoTCC
{
    public class DAO_Conexao
    {
        public static MySqlConnection con;

        public static bool GetConexao(string local, string banco, string user, string senha)
        {
            try
            {
                string connectionString = $"server={local};User ID={user};database={banco};password={senha}";
                con = new MySqlConnection(connectionString);
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static void ExNonQueer(string sql)
        {
            try
            {
                using (var command = new MySqlCommand(sql, con)) {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
