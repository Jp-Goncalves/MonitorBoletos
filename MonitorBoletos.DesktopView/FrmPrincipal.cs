
using MonitorBoletos.Business;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BoletoNet;
using Semafaro.Titulos.Model;
using Semafaro.Titulos.Business;
using System.Linq;
using MonitorBoletos.Util;

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
        ArquivoRetornoCNAB400 cnab400 = new BoletoNet.ArquivoRetornoCNAB400();
        ArquivoRetornoCNAB240 cnab240 = new ArquivoRetornoCNAB240();
        List<string> tipo02 = new List<string>();
        List<string> tipo06 = new List<string>();
        List<string> tipo10 = new List<string>();
        List<string> tipo17 = new List<string>();
        List<string> outrasOcorrencias = new List<string>();
        List<string> NossoNumeroNaoEncontado = new List<string>();

        #endregion

        #region Eventos

        /// <summary>
        /// Processa o arquivo de retorno
        /// </summary>
        private bool LerArquivoRetorno()
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
                                return bussArquivo.lerArquivoRetorno(banco, openFile.OpenFile(), tipo);
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Envia o arquivo para ser processado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btEnviar_Click(object sender, EventArgs e)
        {
            if (LerArquivoRetorno())
            {
                //TODO Carregar o grid (atualizar)
            }
            else
            {
                //TODO Exibir msg ao usuario
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

        private async void btProcessarArquivoCronn_Click(object sender, EventArgs e)
        {
            processarArquivoCronn_PRD_SgvCobranca();
        }

        /// <summary>
        /// Processa o arquivo na base Cronn_PRD
        /// </summary>
        private void processarArquivoCronn_PRD_SgvCobranca()
        {
            //Cria uma lista com o NossoNumero
            List<string> listaNossoNumero = new List<string>();
            //abre o objeto cnab400 e varre a ListDetalhe, que contem as ocorrencias
            foreach (var item in cnab400.ListaDetalhe)
            {
                // listaNossoNumero.Add(item.NossoNumero);

                // 02 = Entrada Confirmada (verificar motivo na posição 319 a 328 )
                if (item.CodigoOcorrencia == 2)
                {
                    tipo02.Add(item.NossoNumero);
                }
                // 06 = Liquidação normal (sem motivo)
                else if (item.CodigoOcorrencia == 6)
                {
                    tipo06.Add(item.NossoNumero);
                    listaNossoNumero.Add(item.NossoNumero);
                }
                // 10 = Baixado conforme instruções da Agência(verificar motivo pos.319 a 328)
                else if (item.CodigoOcorrencia == 10)
                {
                    tipo10.Add(item.NossoNumero);
                }
                // 17 = Liquidação após baixa ou Título não registrado (sem motivo)
                else if (item.CodigoOcorrencia == 17)
                {
                    tipo17.Add(item.NossoNumero);
                    listaNossoNumero.Add(item.NossoNumero);
                }
                //caso o tipo de ocorrencia não é nenhuma das anteriores
                else
                {
                    outrasOcorrencias.Add(item.NossoNumero);
                }
            }
            //adiciona na ListBox os valores de acordo com o pedido do financeiro
            listBoxMsg.Items.Add(cnab400.HeaderRetorno.NomeEmpresa);
            listBoxMsg.Items.Add(string.Format("Quantidade total de boletos: {0}", listaNossoNumero.Count));
            listBoxMsg.Items.Add(string.Format("Quantidade total do tipo 06 - Liquidação Normal: {0}", tipo06.Count));
            listBoxMsg.Items.Add(string.Format("Quantidade total do tipo 17 - Liquidação Após Baixa ou Liquidação Título Não Registrado: {0}", tipo17.Count));
            listBoxMsg.Items.Add(string.Format("Quantidade de boletos do tipo 02 - Entrada Confirmada: {0}", tipo02.Count));
            listBoxMsg.Items.Add(string.Format("Quantidade de boletos do tipo 10 - Baixado Instrução Agencia: {0}", tipo10.Count));


            //cria uma instancia um objeto do tipo CronnSgvCobranca
            var sgvCobranca = new CronnSgvCobranca();
            //cria uma lista com esses objetos criados
            var ListCronnSgvCobranca = new List<CronnSgvCobranca>();
            //cria uma instancia do CronnBusiness
            var cronnbs = new CronnSgvCobrancaBusiness();

            //lista PosPago = 0;
            var PosPago = new List<string>();
            //lista PrePago = 0;
            var PrePago = new List<string>();

            //varre a lista com os todos os nossos numeros contido no arquivo e retorna uma lista de objetos do tipo CronnSgvCobranca
            foreach (var item in listaNossoNumero)
            {
                sgvCobranca = cronnbs.ObterCronnSgvCobranca(item);

                //verifica se o nossoNumero que está no arquito de retorno se econtrar na base de dados Cronn_PRD
                if (sgvCobranca == null)
                {
                    NossoNumeroNaoEncontado.Add(item);
                    listBoxMsg.Items.Add(string.Format("NossoNumero não encotrado na base de dados: {0}", item));
                }
                else
                {
                    //adiciona o objeto CronnSgvCobranca na lista
                    ListCronnSgvCobranca.Add(sgvCobranca);

                    //verificar se a ocorrencia é do tipo 0-PosPago ou 1-PrePago
                    if (sgvCobranca.TipoCobranca == 0)
                    {
                        PosPago.Add(item);
                        Console.WriteLine("Quantidade de PosPago processado: {0}", PosPago.Count);
                    }
                    else
                    {
                        PrePago.Add(item);
                        Console.WriteLine("Quantidade de PrePago processado: {0}", PrePago.Count);
                    }
                }
            }

            listBoxMsg.Items.Add(string.Format("Quantidade de PosPago: {0}", PosPago.Count));
            listBoxMsg.Items.Add(string.Format("Quantidade de PrePago: {0}", PrePago.Count));
            listBoxMsg.Items.Add(string.Empty);
            resetarBotoes();

            btSendEmail.Enabled = true;
        }

        private void resetarBotoes()
        {
            btProcessarArquivoCronn.Enabled = false;
            txtMsg.Clear();
            btSendEmail.Enabled = false;
        }

        private void btSendEmail_Click(object sender, EventArgs e)
        {
            var listItens = new List<string>();
            foreach (var item in listBoxMsg.Items)
            {
                listItens.Add(item.ToString());
            }
            var arquivo = new SendEmails();
            try
            {
                arquivo.SendMail(listItens);
                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }

            resetarBotoes();
        }
    }
}
