using MonitorBoletos.Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace MonitorBoletos.DesktopView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string arquivo { get; set; }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Cursor Files|*.RET";
            openFile.Title = "Selecione um arquivo!";
            openFile.InitialDirectory = @"C:\Users\joao.goncalves\Desktop\XML";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtMsg.Text = openFile.FileName;
                arquivo = openFile.FileName;
            }

            var validarArquivo = new ArquivoBusiness();

            if (validarArquivo.validarArquivo(arquivo) == true)
            {
                MessageBox.Show(arquivo);
            }

            validarArquivo.validarTitulo(arquivo);
            MessageBox.Show(validarArquivo.ToString());
        }
    }
}
