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
        //oi copilot, tudo bem?
        //tudo sim, e vc?
        //tbm, obrigado por perguntar
        //de nada
        //vc consegue me ajudar?
        //claro, no que vc precisa?
        //preciso fazer com q esse form receba um id de um restaurante e liste os funcionarios dele, usando o nome do restaurante informado em outro form. como fazer?
        //vc tem o codigo do outro form?
        //sim, tenho
        //vc pode me mandar?
        //por onde?
        //pelo discord
        //qual seu discord?
        //é o mesmo do github
        //copilot só?
        //sim
        //na verdade, posso copiar aqui em comentário e vc me fala oq fazer?
        //pode sim
        //ok, pera
        //ok


        public void updateTable()
        {
            try
            {
                dgvEmployee.ClearSelection();

                var sql = @"SELECT employee.public_id as id, employee.username, employee.email
                            FROM employment
                            INNER JOIN employee ON employee.id = employment.employee_id
                            INNER JOIN restaurant ON restaurant.id = employment.restaurant_id
                            WHERE restaurant.public_id = @restId";
               

                using (var command = new MySqlCommand(sql, DAO_Conexao.con)) {
                    command.Parameters.AddWithValue("@restId", Controllers.restaurantController.Restaurant.Id);

                    var adapter = new MySqlDataAdapter(command);
                    var dt = new DataTable();
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
            updateTable();
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

            if (string.IsNullOrEmpty(emailToSelect)) {
                MessageBox.Show("Insira um email válido", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var foundRow = false;

            foreach (DataGridViewRow row in dgvEmployee.Rows)
            {
                /* if (row.Cells["email"].Value.ToString() == emailToSelect)
                 {
                     row.Selected = true;
                     foundRow = true;
                     break;
                 }*/
                if (row.Cells["email"].Value.ToString() == emailToSelect)
                {
                    row.Selected = true;
                    foundRow = true;
                    DialogResult result = MessageBox.Show("Deseja remover este funcionário?", "Alerta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Controllers.restaurantController.Dismiss(emailToSelect);
                        updateTable();
                    }
                    else
                    {

                    }
                    break;
                }
            }

            if (!foundRow) {
                MessageBox.Show("Email não pertence a nenhum funcionário", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
