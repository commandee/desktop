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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordConfirm = txtConfirm.Text.Trim();
            
            if (passwordConfirm == password)
            {
                MessageBox.Show("Cadastro realizado!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("As senhas não coincidem.", "Alerta do Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void frmCad_Load(object sender, EventArgs e)
        {

        }
    }
}
