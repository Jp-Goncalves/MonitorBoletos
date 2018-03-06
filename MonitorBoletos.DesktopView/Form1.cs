using BoletoNet;
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
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Arquivos de Retorno (*.ret;*.crt)|*.ret;*.crt|Todos Arquivos (*.*)|*.*";
                openFile.Title = "Selecione um arquivo!";
                openFile.InitialDirectory = @"C:\Users\joao.goncalves\Desktop\XML";

                //se o dialogo retornar OK
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    txtMsg.Text = openFile.FileName;
                    arquivo = openFile.FileName;

                    ArquivoRetornoCNAB400 cnab400 = null;
                    if (openFile.CheckFileExists == true)
                    {
                        cnab400 = new ArquivoRetornoCNAB400();
                        //cnab400.LinhaDeArquivoLida += new EventHandler<LinhaDeArquivoLidaArgs>(cnab400_LinhaDeArquivoLida);
                        cnab400.LerArquivoRetorno(new BoletoNet.Banco(237), openFile.OpenFile());
                    }

                    if (cnab400 == null)
                    {
                        MessageBox.Show("Arquivo não processado!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir arquivo de retorno.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
