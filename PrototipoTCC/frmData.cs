﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PrototipoTCC
{
    public partial class frmData : Form
    {
        public frmData()
        {
            CommandeeData commandeedata = new CommandeeData();
            InitializeComponent();
            if (DAO_Conexao.getConexao(commandeedata.local, commandeedata.banco, commandeedata.user, commandeedata.password))
            {
                MessageBox.Show("Conectado ao banco de dados.", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine("Conectado.");
            }
            else
            {
                Application.Restart();
            }

        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                DAO_Conexao.con.Open();
                string sql = "SELECT id, quantity, createdAt, itemId, commandId, priority FROM `Order`";
                MySqlCommand command = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgPedidos.DataSource = dt;
                dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnMaisPedido_Click(object sender, EventArgs e)
        {
           
            {
                try
                {
                    if (DAO_Conexao.con.State == ConnectionState.Open)
                    {
                        DAO_Conexao.con.Close();
                    }
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
                        string itemFrequente= dr.GetString("itemId");

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
        }

        private void btnPrioridade_Click(object sender, EventArgs e)
        {
            try
            {
                if (DAO_Conexao.con.State == ConnectionState.Open)
                {
                    DAO_Conexao.con.Close();
                }
                DAO_Conexao.con.Open();
                string sql = "SELECT id, quantity, createdAt, itemId, commandId, priority FROM `Order`";
                MySqlCommand prio = new MySqlCommand(sql, DAO_Conexao.con);
                MySqlDataAdapter da = new MySqlDataAdapter(prio);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgPedidos.DataSource = dt;
                dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    }


