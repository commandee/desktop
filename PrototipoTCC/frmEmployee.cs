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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        bool consulta = false;
        bool delete = false;
        bool ativo = true;
        public void updateTable()
        {

            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                dgvEmployee.ClearSelection();
                DAO_Conexao.con.Open();
                string sql = "SELECT email, name, createdAt, updatedAt, username FROM `Employee`";
                MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvEmployee.DataSource = dt;
                dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dgvEmployee.AllowUserToAddRows = false;
                dgvEmployee.AllowUserToDeleteRows = false;
                dgvEmployee.AllowUserToOrderColumns = false;
                dgvEmployee.AllowUserToResizeRows = false;
                dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DAO_Conexao.con.Close();
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
            txtSpec.Visible = false;
            btnConfirma.Visible = false;
            dgvEmployee.ClearSelection();
            txtSpec.Text = "";
            txtSpec.ForeColor = Color.Black;





        }

        private void btnRemv_Click(object sender, EventArgs e)
        {
            txtBusca.Visible = false;
            btnBusca.Visible = false;
            dgvEmployee.ClearSelection();
            delete = true;
            consulta = false;
            txtSpec.Visible = true;
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
                    DialogResult result = MessageBox.Show("Deseja remover este funcionário?", "Alerta do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (DAO_Conexao.con.State == ConnectionState.Open)
                            {
                                DAO_Conexao.con.Close();
                            }
                            DAO_Conexao.con.Open();
                            string sql = "DELETE FROM `Employee` WHERE `email` = '" + emailToSelect + "'";
                            MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                            command.ExecuteNonQuery();
                            updateTable();
                            dgvEmployee.ClearSelection();
                            DAO_Conexao.con.Close();
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
            txtBusca.Text = "";
            txtBusca.ForeColor = Color.Black;
        }
    }
}
