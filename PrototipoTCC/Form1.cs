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
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            CommandeeData commandeedata = new CommandeeData();
            InitializeComponent();
            if (DAO_Conexao.getConexao(commandeedata.local, commandeedata.banco, commandeedata.user, commandeedata.password))
            {
                MessageBox.Show("Conectado ao banco de dados.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine("Conectado.");
            } else
            {
                Application.Restart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text.Trim(); 
            String senha = txtSenha.Text.Trim();
            String restaurantName = txtRestaurant.Text.Trim();
           
            if (DAO_Conexao.login(email,senha) == true)
            {
                MessageBox.Show("Usuário é um funcionário.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (DAO_Conexao.verificaAdmin(email, restaurantName) == true)
                {
                    MessageBox.Show("Seja bem vindo!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Você não tem acesso ao restaurante.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.Write("aaaa");
                }
            }
            else
            {
                MessageBox.Show("Usuário/Senha inválida.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "nacrai@gmail.com";
            txtSenha.Text = "aaaaaaaaaaaaaaaaaaaaaaaa";
            txtRestaurant.Text = "Augustas";
        }
    }
}
