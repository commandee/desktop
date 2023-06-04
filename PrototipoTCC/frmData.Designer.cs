namespace PrototipoTCC
{
    partial class frmData
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgPedidos = new System.Windows.Forms.DataGridView();
            this.btnTotal = new System.Windows.Forms.Button();
            this.btnMaisPedido = new System.Windows.Forms.Button();
            this.btnPrioridade = new System.Windows.Forms.Button();
            this.btnMenosPedido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantidade de pedidos:";
            // 
            // dgPedidos
            // 
            this.dgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPedidos.Location = new System.Drawing.Point(257, 24);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.Size = new System.Drawing.Size(595, 528);
            this.dgPedidos.TabIndex = 1;
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(12, 24);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(239, 31);
            this.btnTotal.TabIndex = 5;
            this.btnTotal.Text = "Total de pedidos";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // btnMaisPedido
            // 
            this.btnMaisPedido.Location = new System.Drawing.Point(12, 61);
            this.btnMaisPedido.Name = "btnMaisPedido";
            this.btnMaisPedido.Size = new System.Drawing.Size(239, 31);
            this.btnMaisPedido.TabIndex = 6;
            this.btnMaisPedido.Text = "Item mais pedido";
            this.btnMaisPedido.UseVisualStyleBackColor = true;
            this.btnMaisPedido.Click += new System.EventHandler(this.btnMaisPedido_Click);
            // 
            // btnPrioridade
            // 
            this.btnPrioridade.Location = new System.Drawing.Point(12, 98);
            this.btnPrioridade.Name = "btnPrioridade";
            this.btnPrioridade.Size = new System.Drawing.Size(239, 31);
            this.btnPrioridade.TabIndex = 7;
            this.btnPrioridade.Text = "Item com mais prioridade";
            this.btnPrioridade.UseVisualStyleBackColor = true;
            this.btnPrioridade.Click += new System.EventHandler(this.btnPrioridade_Click);
            // 
            // btnMenosPedido
            // 
            this.btnMenosPedido.Location = new System.Drawing.Point(12, 135);
            this.btnMenosPedido.Name = "btnMenosPedido";
            this.btnMenosPedido.Size = new System.Drawing.Size(239, 31);
            this.btnMenosPedido.TabIndex = 8;
            this.btnMenosPedido.Text = "Item menos pedido";
            this.btnMenosPedido.UseVisualStyleBackColor = true;
            this.btnMenosPedido.Click += new System.EventHandler(this.btnMenosPedido_Click);
            // 
            // frmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 568);
            this.Controls.Add(this.btnMenosPedido);
            this.Controls.Add(this.btnPrioridade);
            this.Controls.Add(this.btnMaisPedido);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.dgPedidos);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmData";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgPedidos;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Button btnMaisPedido;
        private System.Windows.Forms.Button btnPrioridade;
        private System.Windows.Forms.Button btnMenosPedido;
    }
}