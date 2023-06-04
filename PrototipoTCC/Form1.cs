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
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            CommandeeData commandeedata = new CommandeeData();
            InitializeComponent();
            if (DAO_Conexao.getConexao(commandeedata.local, commandeedata.banco, commandeedata.user, commandeedata.password))
            {
                
                Console.WriteLine("Conectado.");
            } else
            {
                Application.Restart();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text.Trim();
            String senha = txtSenha.Text.Trim();
            String restaurantName = txtRestaurant.Text.Trim();

            if (DAO_Conexao.login(email, senha) == true)
            {
                MessageBox.Show("Usuário é um funcionário.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (DAO_Conexao.verificaAdmin(email, restaurantName) == true)
                {
                    MessageBox.Show("Seja bem vindo!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frmData form2 = new frmData();
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "nacrai@gmail.com";
            //txtEmail.Text = "isa@email.com";
            txtSenha.Text = "aaaaaaaaaaaaaaaaaaaaaaaa";
            //txtSenha.Text = "$2a$10$0IgeNIMoENdke2FW3do1ZeFGJEmI..ddOoiqHvCtffwK1JxPnsr5i";
            txtRestaurant.Text = "Augustas";
        }
    }
}
