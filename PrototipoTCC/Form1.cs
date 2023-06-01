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
            String senha = textBox2.Text.Trim();
           
            if (DAO_Conexao.login(email,senha) == true)
            {
                MessageBox.Show("Usuário é um funcionário.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (DAO_Conexao.verificaAdmin(email) == true)
                {
                    MessageBox.Show("Usuário é um administrador.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Usuário é um funcionário comum.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Usuário/Senha inválida.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
