﻿namespace PrototipoTCC
{
    partial class frmLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRestaurant = new System.Windows.Forms.TextBox();
            this.dgPedidos = new System.Windows.Forms.DataGridView();
            this.btnTotal = new System.Windows.Forms.Button();
            this.btnMaisPedido = new System.Windows.Forms.Button();
            this.btnPrioridade = new System.Windows.Forms.Button();
            this.btnMenosPedido = new System.Windows.Forms.Button();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).BeginInit();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(76, 98);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 37);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Cadastrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(76, 22);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(417, 29);
            this.txtEmail.TabIndex = 1;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(76, 61);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(417, 29);
            this.txtSenha.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "E-mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome do restaurante:";
            // 
            // txtRestaurant
            // 
            this.txtRestaurant.Location = new System.Drawing.Point(666, 22);
            this.txtRestaurant.Name = "txtRestaurant";
            this.txtRestaurant.Size = new System.Drawing.Size(498, 29);
            this.txtRestaurant.TabIndex = 6;
            // 
            // dgPedidos
            // 
            this.dgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPedidos.Location = new System.Drawing.Point(257, 244);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.Size = new System.Drawing.Size(931, 438);
            this.dgPedidos.TabIndex = 7;
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(12, 244);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(239, 31);
            this.btnTotal.TabIndex = 8;
            this.btnTotal.Text = "Total de pedidos";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // btnMaisPedido
            // 
            this.btnMaisPedido.Location = new System.Drawing.Point(12, 281);
            this.btnMaisPedido.Name = "btnMaisPedido";
            this.btnMaisPedido.Size = new System.Drawing.Size(239, 31);
            this.btnMaisPedido.TabIndex = 9;
            this.btnMaisPedido.Text = "Item mais pedido";
            this.btnMaisPedido.UseVisualStyleBackColor = true;
            this.btnMaisPedido.Click += new System.EventHandler(this.btnMaisPedido_Click);
            // 
            // btnPrioridade
            // 
            this.btnPrioridade.Location = new System.Drawing.Point(12, 318);
            this.btnPrioridade.Name = "btnPrioridade";
            this.btnPrioridade.Size = new System.Drawing.Size(239, 31);
            this.btnPrioridade.TabIndex = 10;
            this.btnPrioridade.Text = "Item com mais prioridade";
            this.btnPrioridade.UseVisualStyleBackColor = true;
            this.btnPrioridade.Click += new System.EventHandler(this.btnPrioridade_Click);
            // 
            // btnMenosPedido
            // 
            this.btnMenosPedido.Location = new System.Drawing.Point(12, 355);
            this.btnMenosPedido.Name = "btnMenosPedido";
            this.btnMenosPedido.Size = new System.Drawing.Size(239, 31);
            this.btnMenosPedido.TabIndex = 11;
            this.btnMenosPedido.Text = "Item menos pedido";
            this.btnMenosPedido.UseVisualStyleBackColor = true;
            this.btnMenosPedido.Click += new System.EventHandler(this.btnMenosPedido_Click);
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.label1);
            this.grpLogin.Controls.Add(this.txtEmail);
            this.grpLogin.Controls.Add(this.label3);
            this.grpLogin.Controls.Add(this.txtRestaurant);
            this.grpLogin.Controls.Add(this.label2);
            this.grpLogin.Controls.Add(this.txtSenha);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Location = new System.Drawing.Point(12, 5);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(1176, 233);
            this.grpLogin.TabIndex = 12;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login - Commandee";
            this.grpLogin.Enter += new System.EventHandler(this.grpLogin_Enter);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(12, 622);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(239, 60);
            this.btnEmployee.TabIndex = 13;
            this.btnEmployee.Text = "Gerenciar Funcionários";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(12, 530);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(239, 37);
            this.btnAlterar.TabIndex = 14;
            this.btnAlterar.Text = "Alterar usuário";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 694);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.btnMenosPedido);
            this.Controls.Add(this.btnPrioridade);
            this.Controls.Add(this.btnMaisPedido);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.dgPedidos);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLogin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRestaurant;
        private System.Windows.Forms.DataGridView dgPedidos;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Button btnMaisPedido;
        private System.Windows.Forms.Button btnPrioridade;
        private System.Windows.Forms.Button btnMenosPedido;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnAlterar;
    }
}

