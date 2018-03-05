using MonitorBoletos.Business;
using MonitorBoletos.Model;
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
            openFile.Filter = "Arquivo de retorno bancario |*.RET";
            openFile.Title = "Selecione um arquivo!";
            openFile.InitialDirectory = @"C:\Users\joao.goncalves\Desktop\XML";

            //se o dialogo retornar OK
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtMsg.Text = openFile.FileName;
                arquivo = openFile.FileName;

                var bussArquivo = new ArquivoBusiness();
                var banco = new Banco();

                if (bussArquivo.validarArquivo(arquivo) == true)
                {
                    banco = bussArquivo.validarArquivoLicenca(arquivo);
                    MessageBox.Show("O banco é: " + banco.Nome + " " + "e o Nº: " + banco.Numero);
                }

                bussArquivo.validarArquivoLicenca(arquivo);
            }
        }
    }
}
