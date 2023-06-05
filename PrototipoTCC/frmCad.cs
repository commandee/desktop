using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototipoTCC
{
    public partial class frmCad : Form
    {
        public frmCad()
        {
            InitializeComponent();
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            
            string email = txtEmail.Text.Trim();
            string name = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordConfirm = txtConfirm.Text.Trim();
            if (passwordConfirm == password)
            {
                try
                {
                    if (DAO_Conexao.con.State == ConnectionState.Open)
                    {
                        DAO_Conexao.con.Close();
                    }
                    DAO_Conexao.con.Open();
                    string sql = "INSERT INTO `Employee` (`email`, `name`, `username`, `password`) VALUES ('" + email + "', '" + name + "', '" + username + "', '" + password + "')";
                    MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                    command.ExecuteNonQuery();
                    DAO_Conexao.con.Close();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MessageBox.Show("Cadastro realizado!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            } else
            {
                MessageBox.Show("As senhas não coincidem.", "Alerta do Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
        }
    }
}
