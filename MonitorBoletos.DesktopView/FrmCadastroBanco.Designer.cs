namespace MonitorBoletos.DesktopView
{
    partial class FrmCadastroBanco
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
            this.tbIdBanco = new System.Windows.Forms.TextBox();
            this.tbNomeBanco = new System.Windows.Forms.TextBox();
            this.tbNumeroBanco = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbIdBanco
            // 
            this.tbIdBanco.Location = new System.Drawing.Point(91, 63);
            this.tbIdBanco.Name = "tbIdBanco";
            this.tbIdBanco.ReadOnly = true;
            this.tbIdBanco.Size = new System.Drawing.Size(100, 20);
            this.tbIdBanco.TabIndex = 0;
            // 
            // tbNomeBanco
            // 
            this.tbNomeBanco.Location = new System.Drawing.Point(91, 107);
            this.tbNomeBanco.Name = "tbNomeBanco";
            this.tbNomeBanco.Size = new System.Drawing.Size(100, 20);
            this.tbNomeBanco.TabIndex = 1;
            // 
            // tbNumeroBanco
            // 
            this.tbNumeroBanco.Location = new System.Drawing.Point(91, 149);
            this.tbNumeroBanco.Name = "tbNumeroBanco";
            this.tbNumeroBanco.Size = new System.Drawing.Size(100, 20);
            this.tbNumeroBanco.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Gravar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Numero";
            // 
            // FrmCadastroBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 362);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbNumeroBanco);
            this.Controls.Add(this.tbNomeBanco);
            this.Controls.Add(this.tbIdBanco);
            this.Name = "FrmCadastroBanco";
            this.Text = "FrmCadastroBanco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIdBanco;
        private System.Windows.Forms.TextBox tbNomeBanco;
        private System.Windows.Forms.TextBox tbNumeroBanco;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}