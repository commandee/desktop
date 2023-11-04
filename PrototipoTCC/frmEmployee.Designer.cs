namespace PrototipoTCC
{
    partial class frmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.btnCons = new System.Windows.Forms.Button();
            this.btnRemv = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBusca = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(334, 55);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new System.Drawing.Size(854, 627);
            this.dgvEmployee.TabIndex = 0;
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            // 
            // btnCons
            // 
            this.btnCons.Location = new System.Drawing.Point(12, 55);
            this.btnCons.Name = "btnCons";
            this.btnCons.Size = new System.Drawing.Size(316, 37);
            this.btnCons.TabIndex = 2;
            this.btnCons.Text = "Consultar funcionários";
            this.btnCons.UseVisualStyleBackColor = true;
            this.btnCons.Click += new System.EventHandler(this.btnCons_Click);
            // 
            // btnRemv
            // 
            this.btnRemv.Location = new System.Drawing.Point(12, 98);
            this.btnRemv.Name = "btnRemv";
            this.btnRemv.Size = new System.Drawing.Size(316, 37);
            this.btnRemv.TabIndex = 3;
            this.btnRemv.Text = "Remover funcionário";
            this.btnRemv.UseVisualStyleBackColor = true;
            this.btnRemv.Click += new System.EventHandler(this.btnRemv_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1024, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(164, 37);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(12, 141);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(316, 29);
            this.txtSpec.TabIndex = 5;
            this.txtSpec.TextChanged += new System.EventHandler(this.txtSpec_TextChanged);
            this.txtSpec.Enter += new System.EventHandler(this.txtConsulta_Enter);
            // 
            // btnConfirma
            // 
            this.btnConfirma.Location = new System.Drawing.Point(12, 176);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(316, 37);
            this.btnConfirma.TabIndex = 6;
            this.btnConfirma.Text = "Confirmar";
            this.btnConfirma.UseVisualStyleBackColor = true;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(12, 219);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(316, 29);
            this.txtBusca.TabIndex = 7;
            this.txtBusca.Enter += new System.EventHandler(this.txtBusca_Enter);
            // 
            // btnBusca
            // 
            this.btnBusca.Location = new System.Drawing.Point(12, 254);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(316, 37);
            this.btnBusca.TabIndex = 8;
            this.btnBusca.Text = "Confirmar";
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 694);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnRemv);
            this.Controls.Add(this.btnCons);
            this.Controls.Add(this.dgvEmployee);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEmployee";
            this.Text = "Gerenciar funcionários";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button btnCons;
        private System.Windows.Forms.Button btnRemv;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBusca;
    }
}