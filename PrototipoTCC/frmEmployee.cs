using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PrototipoTCC
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        bool consulta = false;
        bool delete = false;
        frmLogin frm = new frmLogin();


        public void updateTable()
        {
            string restaurantId = frm.cmbRestaurant.SelectedValue.ToString();
            try
            {
                dgvEmployee.ClearSelection();

                string sql = $@"SELECT employee.username, employee.email, employee.public_id as id 
                               FROM employment 
                               INNER JOIN employee ON employee.id = employment.employee_id 
                               INNER JOIN restaurant ON restaurant.id = '{restaurantId}'
                               LIMIT 1000";

                using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {                    
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvEmployee.DataSource = dt;
                }

                dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dgvEmployee.AllowUserToAddRows = false;
                dgvEmployee.AllowUserToDeleteRows = false;
                dgvEmployee.AllowUserToOrderColumns = false;
                dgvEmployee.AllowUserToResizeRows = false;
                dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void btnCons_Click(object sender, EventArgs e)
        {
            dgvEmployee.ClearSelection();
            updateTable();
            consulta = true;
            delete = false;
            txtSpec.Visible = false;
            btnConfirma.Visible = false;
            txtBusca.Visible = true;
            btnBusca.Visible = true;
            txtBusca.Text = "Insira o email do funcionário";
            txtBusca.ForeColor = Color.Gray;
            dgvEmployee.CurrentCell = null;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            txtBusca.Visible = false;
            btnBusca.Visible = false;
            dgvEmployee.ClearSelection();
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.ReadOnly = true;
            dgvEmployee.MultiSelect = false;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.ReadOnly = true;
            dgvEmployee.Enabled = false;
            btnConfirma.Visible = false;
            txtSpec.Visible = false;


        }


        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            dgvEmployee.ClearSelection();
            txtSpec.Text = "";
            txtSpec.ForeColor = Color.Black;
        }

        private void btnRemv_Click(object sender, EventArgs e)
        {
            updateTable();
            txtBusca.Visible = false;
            btnBusca.Visible = false;
            
            dgvEmployee.ClearSelection();
            delete = true;
            consulta = false;
            txtSpec.Visible = true;
            btnConfirma.Visible = true;
            txtSpec.Text = "Insira o email do funcionário";
            txtSpec.ForeColor = Color.Gray;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSpec_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            txtBusca.Visible = false;
            btnBusca.Visible = false;
            dgvEmployee.ClearSelection();
            string emailToSelect = txtSpec.Text;
            updateTable();
            if (!string.IsNullOrEmpty(emailToSelect))
            {
                bool foundRow = false;

                foreach (DataGridViewRow row in dgvEmployee.Rows)
                {
                    if (row.Cells["email"].Value.ToString() == emailToSelect)
                    {
                        row.Selected = true;
                        foundRow = true;
                        break;
                    }
                }
                if (foundRow)
                {
                        DialogResult result = MessageBox.Show("Deseja remover este funcionário?", "Alerta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                string sql = $"DELETE FROM `employee` WHERE `email` = @email";

                                using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                                    command.AddWithValue("@email", emailToSelect);
                                    command.ExecuteNonQuery();

                                    updateTable();
                                    dgvEmployee.ClearSelection();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                    }
                else
                {
                    MessageBox.Show("Insira um email válido", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            txtSpec.Visible = false;
            btnConfirma.Visible = false;
            string emailSelecionado = txtBusca.Text;
            if (!string.IsNullOrEmpty(emailSelecionado))
            {
              
                foreach (DataGridViewRow row in dgvEmployee.Rows)
                {
                    if (row.Cells["email"].Value.ToString() == emailSelecionado)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void txtBusca_Enter(object sender, EventArgs e)
        {
            txtSpec.Visible = false;
            btnConfirma.Visible = false;
            txtBusca.Text = "";
            txtBusca.ForeColor = Color.Black;
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
