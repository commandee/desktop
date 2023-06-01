using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototipoTCC
{
    class DAO_Conexao
    {
        public static MySqlConnection con;
        public static Boolean getConexao(String local, String banco, String user, String senha)
        {
            Boolean retorno = false;
            try
            {
                con = new MySqlConnection("server=" + local + ";User ID=" + user + ";database=" + banco + ";password=" + senha);
                retorno = true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retorno;
        }

        public static bool login(String email, String senha)
        {
            Boolean existe = false;

            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                con.Open();
                //string sql = $"SELECT id FROM Employee WHERE email = '${email}' AND password='${senha}'";
                string sql = "SELECT id FROM Employee WHERE email LIKE '" + email + "' AND password LIKE '" + senha + "'";
                MessageBox.Show(sql);
                int result1 = new MySqlCommand(sql, con).ExecuteNonQuery();
                MySqlCommand login = new MySqlCommand(sql, con);
                Console.WriteLine(sql);
                MySqlDataReader result = login.ExecuteReader();
                if (result.Read())
                {
                    existe = true;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                con.Close();
            }
            return existe;
            
        }

        public static bool verificaAdmin(String email)
        {
            string id = "";
            Boolean admin = false;
            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                con.Open();
                string sql = "SELECT id FROM Employee WHERE email=" + email + "";
                MySqlCommand posicao = new MySqlCommand(sql, con);
                Console.WriteLine(posicao);
                MySqlDataReader dr = posicao.ExecuteReader();
                if (dr.Read())
                {
                    id = Convert.ToInt32(dr["id"]).ToString();
                    MessageBox.Show(id);
                    admin = true;

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

        
    }
}
