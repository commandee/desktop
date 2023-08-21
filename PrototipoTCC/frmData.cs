using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototipoTCC
{

    public partial class frmLogin : Form
    {
        //static readonly HttpClient dpseumemato = new HttpClient();

        public frmLogin()
        {
            CommandeeData commandeedata = new CommandeeData();
            InitializeComponent();
            if (DAO_Conexao.GetConexao(commandeedata.host, commandeedata.database, commandeedata.username, commandeedata.password))
            {
                
                Console.WriteLine("Conectado.");
            } else
            {
                Console.WriteLine("Vsf restart");
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text.Trim();
            String senha = txtSenha.Text.Trim();
            String restaurantName = txtRestaurant.Text.Trim();

            if (DAO_Conexao.Login(email, senha) == true)
            {
                MessageBox.Show("Usuário é um funcionário.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (DAO_Conexao.VerificaAdmin(email, restaurantName) == true)
                {
                    MessageBox.Show("Seja bem vindo!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frmLogin form2 = new frmLogin();
                    form2.Show();
                    this.Size = new Size(1216, 733);
                    grpLogin.Visible = false;   
                }
                else
                {
                   MessageBox.Show("Você não tem acesso ao restaurante.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Usuário/Senha inválida.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1216, 230);
            dgPedidos.Enabled = false;
            btnMaisPedido.Enabled = false;
            btnMenosPedido.Enabled = false;
            btnPrioridade.Enabled = false;
            btnAlterar.Enabled = false;
            txtEmail.Text = "wanna@kry.com";
            //txtEmail.Text = "isa@email.com";
            txtSenha.Text = "$2a$10$61KLS.QoBh/EjrpnZ8o1vu.ReCgfpFyn.JoMiGh.se0seRGWcC5D6";
            //txtSenha.Text = "$2a$10$0IgeNIMoENdke2FW3do1ZeFGJEmI..ddOoiqHvCtffwK1JxPnsr5i";
            txtRestaurant.Text = "Augustas";
        }

        private void BtnTotal_Click(object sender, EventArgs e)
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
                string sql = "SELECT id, commanda_id, quantity, item_id, , priority FROM `Order`";
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

        private void BtnMaisPedido_Click(object sender, EventArgs e)
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

                string sql = "SELECT item_id, COUNT(item_id) AS Frequency " +
                             "FROM `Order` " +
                             "GROUP BY item_id " +
                             "ORDER BY Frequency DESC " +
                             "LIMIT 1";

                MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    string itemFrequente = dr.GetString("item_id");

                    dgPedidos.ClearSelection();

                    foreach (DataGridViewRow row in dgPedidos.Rows)
                    {

                        if (row.Cells["item_id"].Value != null && row.Cells["item_id"].Value.ToString() == itemFrequente)
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

        private void BtnPrioridade_Click(object sender, EventArgs e)
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
                string sql = "SELECT public_id, quantity, priority, status, notes FROM `order`";
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

        private void BtnMenosPedido_Click(object sender, EventArgs e)
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

                string sql = "SELECT item_id, COUNT(item_id) AS Frequency " +
                             "FROM `Order` " +
                             "GROUP BY item_id " +
                             "ORDER BY Frequency ASC " +
                             "LIMIT 1";

                MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    string itemMenosFrequente = dr.GetString("item_id");

                    dgPedidos.ClearSelection();

                    foreach (DataGridViewRow row in dgPedidos.Rows)
                    {
                        if (row.Cells["item_id"].Value != null && row.Cells["item_id"].Value.ToString() == itemMenosFrequente)
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

        private void grpLogin_Enter(object sender, EventArgs e)
        {

        }
    }
}
