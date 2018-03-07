
using MonitorBoletos.Business;
using MonitorBoletos.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace MonitorBoletos.DesktopView
{
    public partial class FrmPrincipal : Form
    {

        #region Construtor
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        #endregion

        #region Campos

        #endregion

        #region Eventos
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

                    //verifica se o arquivo existe
                    if (openFile.CheckFileExists == true)
                    {
                        using (var bussBanco = new BancoBusiness())
                        {
                            var cbItem = cbBancos.SelectedValue;

                            var banco = bussBanco.ObterPorID(cbItem);

                            //lê o arquivo de retorno
                            using (var bussArquivo = new ArquivoBusiness())
                            {
                                var tipo = bussArquivo.verificaTipoCNAB(openFile.FileName);
                                bussArquivo.lerArquivoRetorno(banco, openFile.OpenFile(), tipo);
                            }
                        }
                    }
                    else
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

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmCadastroBanco().Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            atualizarComboBanco();
        }

        private void lnkAtualizarCbBancos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            atualizarComboBanco();
        }

        private void atualizarComboBanco()
        {
            using (BancoBusiness bc = new BancoBusiness())
            {
                cbBancos.DataSource = bc.ObterTodos();
                cbBancos.DisplayMember = "Descricao";
                cbBancos.ValueMember = "Id";
            }
        }
    }
}
