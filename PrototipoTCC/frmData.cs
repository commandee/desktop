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
            DAO_Conexao.GetConexao(commandeedata.host, commandeedata.database, commandeedata.username, commandeedata.password);
            if (DAO_Conexao.con.Ping())
            {
                
                Console.WriteLine("Conectado.");
            } else
            {
                Console.WriteLine("Vsf restart");
            }
            DAO_Conexao.con.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtSenha.Text;
                try
                {
                    var employee = Controllers.empController.Login(email, password);
                    cmbRestaurante.DataSource = Controllers.empController.Owns(employee);
                    cmbRestaurante.Enabled = true;
                    btnPesquisar.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtEmail.Text = "ame.pistache@gmail.com";
            //txtEmail.Text = "isa@email.com";
            txtSenha.Text = "$2a$10$dDF5aoRIk62EuzL75Dxn5u/2eWv9e.UDK5PHeWXpEAAAjABrOciRK";
            //txtSenha.Text = "$2a$10$0IgeNIMoENdke2FW3do1ZeFGJEmI..ddOoiqHvCtffwK1JxPnsr5i";
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
            cmbRestaurante.DataSource = null;
            cmbRestaurante.DisplayMember = "Name";
            btnPesquisar.Visible = false;
            cmbRestaurante.Enabled = false;
            }

        private void grpLogin_Enter(object sender, EventArgs e)
        {

        }

        private void cmbRestaurante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1216, 733);
        }
    }
}
