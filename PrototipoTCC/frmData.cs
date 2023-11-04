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
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtSenha.Text;
                try
                {
                    Controllers.loginController.Login(email, password);
                    cmbRestaurant.DataSource = Controllers.empController.Owns(Controllers.loginController.User);
                    
                    cmbRestaurant.Enabled = true;
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
            txtEmail.Text = "printer@bigrat.monster";
            //txtEmail.Text = "isa@email.com";
            txtSenha.Text = "prointer";
            //txtSenha.Text = "$2a$10$0IgeNIMoENdke2FW3do1ZeFGJEmI..ddOoiqHvCtffwK1JxPnsr5i";
        }

        private void BtnTotal_Click(object sender, EventArgs e)
        {
            btnMaisPedido.Enabled = true;
            btnMenosPedido.Enabled = true;
            btnPrioridade.Enabled = true;
            btnAlterar.Enabled = true;

            var con = DAO_Conexao.con;

            try
            {
                //em nome do pai, do filho e do espirito santo, eu rezo para que isso funcione.
                dgPedidos.ClearSelection();

                var sql = @"SELECT commanda_id, item_id, quantity, priority, status 
                            FROM `order`";

                using (var command = new MySqlCommand(sql, con)) {
                    var adapter = new MySqlDataAdapter(command);

                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dgPedidos.DataSource = dt;
                    dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dgPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dgPedidos.AllowUserToAddRows = false;
                    dgPedidos.AllowUserToDeleteRows = false;
                    dgPedidos.AllowUserToOrderColumns = false;
                    dgPedidos.AllowUserToResizeRows = false;
                    dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                dgPedidos.ClearSelection();

                var sql = @"SELECT item.name as 'Nome', COUNT(item_id) AS 'Frequência'
                            FROM `order`
                            INNER JOIN item on item.id = `order`.item_id
                            GROUP BY item_id
                            ORDER BY `Frequência` DESC;";

                using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                    var adapter = new MySqlDataAdapter(command);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgPedidos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                dgPedidos.ClearSelection();

                string sql = @"SELECT item.name as 'Nome', priority as 'Prioridade'
                               FROM `order`
                               INNER JOIN item on item.id = `order`.item_id
                               ORDER BY priority DESC";

                using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                    var adapter = new MySqlDataAdapter(command);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgPedidos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                dgPedidos.ClearSelection();

                string sql = @"SELECT item.name as 'Nome', COUNT(item_id) AS 'Frequência'
                               FROM `order`
                               INNER JOIN item on item.id = `order`.item_id
                               GROUP BY item_id
                               ORDER BY `Frequência` ASC";

                using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                    var adapter = new MySqlDataAdapter(command);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgPedidos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            cmbRestaurant.DataSource = null;
            cmbRestaurant.DisplayMember = "Name";
            btnPesquisar.Visible = false;
            cmbRestaurant.Enabled = false;
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
