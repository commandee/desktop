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
                    //frmData form2 = new frmData();
                    //form2.Show();
                    this.Size = new Size(1216, 733);
                    grpLogin.Visible = false;   
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
            this.Size = new Size(1216, 230);
            dgPedidos.Enabled = false;
            btnMaisPedido.Enabled = false;
            btnMenosPedido.Enabled = false;
            btnPrioridade.Enabled = false;
            btnAlterar.Enabled = false;
            txtEmail.Text = "nacrai@gmail.com";
            //txtEmail.Text = "isa@email.com";
            txtSenha.Text = "aaaaaaaaaaaaaaaaaaaaaaaa";
            //txtSenha.Text = "$2a$10$0IgeNIMoENdke2FW3do1ZeFGJEmI..ddOoiqHvCtffwK1JxPnsr5i";
            txtRestaurant.Text = "Augustas";
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            btnMaisPedido.Enabled = true;
            btnMenosPedido.Enabled = true;
            btnPrioridade.Enabled = true;
            btnAlterar.Enabled = true;
            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                dgPedidos.ClearSelection();
                DAO_Conexao.con.Open();
                string sql = "SELECT id, quantity, createdAt, itemId, commandId, priority FROM `Order`";
                MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgPedidos.DataSource = dt;
                dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dgPedidos.AllowUserToAddRows = false;
                dgPedidos.AllowUserToDeleteRows = false;
                dgPedidos.AllowUserToOrderColumns = false;
                dgPedidos.AllowUserToResizeRows = false;
                dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnMaisPedido_Click(object sender, EventArgs e)
        {
            btnMaisPedido.Enabled = true;
            btnMenosPedido.Enabled = true;
            btnPrioridade.Enabled = true;
            btnAlterar.Enabled = true;
            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                dgPedidos.ClearSelection();
                DAO_Conexao.con.Open();

                string sql = "SELECT itemId, COUNT(itemId) AS Frequency " +
                             "FROM `Order` " +
                             "GROUP BY itemId " +
                             "ORDER BY Frequency DESC " +
                             "LIMIT 1";

                MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    string itemFrequente = dr.GetString("itemId");

                    dgPedidos.ClearSelection();

                    foreach (DataGridViewRow row in dgPedidos.Rows)
                    {

                        if (row.Cells["itemId"].Value != null && row.Cells["itemId"].Value.ToString() == itemFrequente)
                        {
                            row.Selected = true;
                        }

                    }
                }

                dr.Close();
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnPrioridade_Click(object sender, EventArgs e)
        {
            btnMaisPedido.Enabled = true;
            btnMenosPedido.Enabled = true;
            btnPrioridade.Enabled = true;
            btnAlterar.Enabled = true;
            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                dgPedidos.ClearSelection();
                DAO_Conexao.con.Open();
                string sql = "SELECT id, quantity, createdAt, itemId, commandId, priority FROM `Order`";
                MySqlCommand prio = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataReader dr = prio.ExecuteReader();
                if (dr.Read())
                {
                    string prioridade = dr.GetString("priority");

                    dgPedidos.ClearSelection();

                    foreach (DataGridViewRow row in dgPedidos.Rows)
                    {
                        if (row.Cells["priority"].Value != null && row.Cells["priority"].Value.ToString() == "high")
                        {
                            row.Selected = true;
                        }
                    }
                    DAO_Conexao.con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnMenosPedido_Click(object sender, EventArgs e)
        {
            btnMaisPedido.Enabled = true;
            btnMenosPedido.Enabled = true;
            btnPrioridade.Enabled = true;
            btnAlterar.Enabled = true;
            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                dgPedidos.ClearSelection();
                DAO_Conexao.con.Open();

                string sql = "SELECT itemId, COUNT(itemId) AS Frequency " +
                             "FROM `Order` " +
                             "GROUP BY itemId " +
                             "ORDER BY Frequency ASC " +
                             "LIMIT 1";

                MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    string itemMenosFrequente = dr.GetString("itemId");

                    dgPedidos.ClearSelection();

                    foreach (DataGridViewRow row in dgPedidos.Rows)
                    {
                        if (row.Cells["itemId"].Value != null && row.Cells["itemId"].Value.ToString() == itemMenosFrequente)
                        {
                            row.Selected = true;
                        }
                    }
                }

                dr.Close();
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frmE = new frmEmployee();
            frmE.Show();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1216, 230);
            btnAlterar.Enabled = false;
            grpLogin.Visible = true;
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtRestaurant.Text = "";
        }
    }
}
