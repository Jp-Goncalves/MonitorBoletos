namespace MonitorBoletos.DesktopView
{
    partial class FrmPrincipal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkAtualizarCbBancos = new System.Windows.Forms.LinkLabel();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btProcessarArquivoCronn = new System.Windows.Forms.Button();
            this.btSendEmail = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkAtualizarCbBancos);
            this.groupBox1.Controls.Add(this.cbBancos);
            this.groupBox1.Controls.Add(this.btEnviar);
            this.groupBox1.Controls.Add(this.txtMsg);
            this.groupBox1.Location = new System.Drawing.Point(13, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CNAB";
            // 
            // lnkAtualizarCbBancos
            // 
            this.lnkAtualizarCbBancos.AutoSize = true;
            this.lnkAtualizarCbBancos.Location = new System.Drawing.Point(224, 31);
            this.lnkAtualizarCbBancos.Name = "lnkAtualizarCbBancos";
            this.lnkAtualizarCbBancos.Size = new System.Drawing.Size(46, 13);
            this.lnkAtualizarCbBancos.TabIndex = 5;
            this.lnkAtualizarCbBancos.TabStop = true;
            this.lnkAtualizarCbBancos.Text = "atualizar";
            this.lnkAtualizarCbBancos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizarCbBancos_LinkClicked);
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(30, 27);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(187, 21);
            this.cbBancos.TabIndex = 4;
            // 
            // btEnviar
            // 
            this.btEnviar.Location = new System.Drawing.Point(384, 29);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(75, 45);
            this.btEnviar.TabIndex = 3;
            this.btEnviar.Text = "Ler Arquivo CNAB";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(30, 54);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(337, 20);
            this.txtMsg.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(67, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(38, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Banco";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btSendEmail);
            this.groupBox2.Controls.Add(this.btProcessarArquivoCronn);
            this.groupBox2.Location = new System.Drawing.Point(13, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 97);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CRONN";
            // 
            // btProcessarArquivoCronn
            // 
            this.btProcessarArquivoCronn.Enabled = false;
            this.btProcessarArquivoCronn.Location = new System.Drawing.Point(384, 30);
            this.btProcessarArquivoCronn.Name = "btProcessarArquivoCronn";
            this.btProcessarArquivoCronn.Size = new System.Drawing.Size(75, 43);
            this.btProcessarArquivoCronn.TabIndex = 0;
            this.btProcessarArquivoCronn.Text = "Processar Arquivo";
            this.btProcessarArquivoCronn.UseVisualStyleBackColor = true;
            this.btProcessarArquivoCronn.Click += new System.EventHandler(this.btProcessarArquivoCronn_Click);
            // 
            // btSendEmail
            // 
            this.btSendEmail.Location = new System.Drawing.Point(30, 30);
            this.btSendEmail.Name = "btSendEmail";
            this.btSendEmail.Size = new System.Drawing.Size(75, 43);
            this.btSendEmail.TabIndex = 1;
            this.btSendEmail.Text = "Enviar o E-mail";
            this.btSendEmail.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Location = new System.Drawing.Point(13, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 40);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cadastro";
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.Location = new System.Drawing.Point(13, 268);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(486, 264);
            this.listBoxMsg.TabIndex = 6;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 546);
            this.Controls.Add(this.listBoxMsg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPrincipal";
            this.Text = "Monitor de boletos";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.LinkLabel lnkAtualizarCbBancos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btProcessarArquivoCronn;
        private System.Windows.Forms.Button btSendEmail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxMsg;
    }
}

