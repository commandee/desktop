using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PrototipoTCC
{
    class DAO_Conexao
    {
        public static MySqlConnection con;
        public static bool getConexao(string local, string banco, string user, string senha)
        {
            bool retorno = false;
            try
            {
                con = new MySqlConnection("server=" + local + ";User ID=" + user + ";database=" + banco + ";password=" + senha);
                retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retorno;
        }

        public static bool login(string email, string senha)
        {
            bool existe = false;

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                string sql = $"SELECT * FROM Employee WHERE email='{email}' AND password='{senha}'";
                MySqlCommand login = new MySqlCommand(sql, con);
                Console.WriteLine(sql);
                MySqlDataReader result = login.ExecuteReader();
                if (result.Read())
                {
                    existe = true;
                }
                result.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public static bool verificaAdmin(string email, string name)
        {
            string id = "";
            bool admin = false;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string sql = $"SELECT id FROM Employee WHERE email='{email}'";
                MySqlCommand posicao = new MySqlCommand(sql, con);
                MessageBox.Show(sql);

                MySqlDataReader dr = posicao.ExecuteReader();
                if (dr.Read())
                {
                    id = Convert.ToString(dr["id"]);
                    admin = true;
                }
                dr.Close();

                string idRes = "";
                string sql2 = $"SELECT id FROM Restaurant WHERE name='{name}'";
                MessageBox.Show(sql2);
                MySqlCommand restaurantCmd = new MySqlCommand(sql2, con);

                MySqlDataReader restaurantDr = restaurantCmd.ExecuteReader();
                if (restaurantDr.Read())
                {
                    idRes = Convert.ToString(restaurantDr["id"]);
                }
                restaurantDr.Close();

                bool isOwner = verificaOwner(id, idRes);

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

        public static bool verificaOwner(string id, string idRes)
        {
            bool isOwner = false;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string sql = $"SELECT * FROM _ownership WHERE A='{id}' AND B='{idRes}'";
                MessageBox.Show(sql);
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




























