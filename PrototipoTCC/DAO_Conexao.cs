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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                MySqlCommand command = new MySqlCommand(sql, con);
                command.ExecuteNonQuery();
                con.Close();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                con.Close();
            }
            

        }

        public static bool Login(string email, string senha)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }   

                con.Open();
                string sql = $"SELECT * FROM employee WHERE email='{email}' AND password='{senha}'";
                MySqlCommand login = new MySqlCommand(sql, con);
                Console.WriteLine(sql);
                MySqlDataReader result = login.ExecuteReader();
                bool existe = result.Read();
                result.Close();
                return existe;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool VerificaAdmin(string email, string name)
        {
            string id = "";
            bool admin = false;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string sql = $"SELECT id FROM employee WHERE email='{email}'";
                MySqlCommand posicao = new MySqlCommand(sql, con);
                MySqlDataReader dr = posicao.ExecuteReader();
                if (dr.Read())
                {
                    id = Convert.ToString(dr["id"]);
                    admin = true;
                }
                dr.Close();

                string idRes = "";
                string publicId = "";
                string sql2 = $"SELECT id, public_id FROM restaurant WHERE name='{name}'";
                MySqlCommand restaurantCmd = new MySqlCommand(sql2, con);

                MySqlDataReader restaurantDr = restaurantCmd.ExecuteReader();
                if (restaurantDr.Read())
                {
                    idRes = Convert.ToString(restaurantDr["id"]);
                    publicId = Convert.ToString(restaurantDr["public_id"]);
                }
                restaurantDr.Close();

                bool isOwner = VerificaOwner(id, idRes);

                if (!isOwner)
                {
                    admin = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return admin;
        }

        public static bool VerificaOwner(string id, string idRes)
        {
            bool isOwner = false;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string sql = $"SELECT * FROM ownership WHERE owner_id='{id}' AND restaurant_id='{idRes}'";
                MySqlCommand verifica = new MySqlCommand(sql, con);

                MySqlDataReader drVer = verifica.ExecuteReader();
                if (drVer.Read())
                {
                    isOwner = true;
                }
                drVer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return isOwner;
        }
    }
}
