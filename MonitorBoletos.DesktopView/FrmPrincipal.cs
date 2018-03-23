
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
using System.Data;

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
                atualizarGridView();
                MessageBox.Show("Leitura realizada com sucesso!", "Arquivo Retorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btProcessarArquivoCronn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Não foi possivel ler o arquivo", "Arquivo Retorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmCadastroBanco().Show();
        }

        /// <summary>
        /// Metodos executados ao carregar o formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            atualizarComboBanco();

            atualizarGridView();
        }

        /// <summary>
        /// Ao clicar no botão atualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkAtualizarCbBancos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            atualizarComboBanco();

            atualizarGridView();
        }

        private void atualizarGridView()
        {
            using (var bc = new ArquivoBusiness())
            {
                //Cria um DataTable referente ao objeto Arquivo e as colunas que serão mostradas na Grid
                var dtArquivo = new DataTable();
                dtArquivo.Columns.Add("Nome", typeof(string));
                dtArquivo.Columns.Add("Diretorio", typeof(string));
                dtArquivo.Columns.Add("OcorrenciasCobranca", typeof(string));
                dtArquivo.Columns.Add("DataUpload", typeof(DateTime));
                dtArquivo.Columns.Add("DataProcessamento", typeof(DateTime));
                dtArquivo.Columns.Add("Usuario", typeof(string));

                //Cria um DataTable referente ao objeto Arquivo e as colunas que serão mostradas na Grid
                var dtOcorrencias = new DataTable();
                dtOcorrencias.Columns.Add("NossoNumero");

                //Pega todos os objetos do tipo Arquivo que se encontram no banco de dados
                var file = new List<Arquivo>();
                file = (List<Arquivo>)bc.ObterTodos();
                var ocorrencias = new List<OcorrenciaCobranca>();
                var ocorrenciaBusiness = new OcorrenciaCobrancaBusiness();

                ocorrencias = (List<OcorrenciaCobranca>)ocorrenciaBusiness.ObterTodos();

                //Percorre a List de objetos do tipo Arquivo
                foreach (var item in file)
                {
                    //Adiciona cd linha na sua respectiva coluna
                    DataRow row = dtArquivo.NewRow();
                    row["Nome"] = item.Nome;
                    row["Diretorio"] = item.Diretorio;
                    row["DataUpload"] = item.DataUpload;
                    row["DataProcessamento"] = item.DataProcessamento;
                    row["Usuario"] = item.Usuario;
                    dtArquivo.Rows.Add(row);

                    ocorrencias = (List<OcorrenciaCobranca>)item.OcorrenciasCobranca;
                    foreach (var itens in ocorrencias)
                    {
                        DataRow rowOcorrencia = dtOcorrencias.NewRow();
                        rowOcorrencia["NossoNumero"] = itens.NossoNumero;
                        dtOcorrencias.Rows.Add(rowOcorrencia);
                        row["OcorrenciasCobranca"] = itens.NossoNumero;
                    }
                }
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(dtArquivo);
                dataSet.Tables.Add(dtOcorrencias);

                DataRelation dataRelation = new DataRelation("Nossos Numeros", dataSet.Tables[0].Columns[2], dataSet.Tables[1].Columns[0], true);
                dataSet.Relations.Add(dataRelation);

                //Popula a Grid com o DataTable
                dataGridView1.DataSource = dataSet;
            }


            //using (var bc = new ArquivoBusiness())
            //{
            //    dataGridView1.DataSource = bc.ObterTodos();
            //    var arquivo = bc.ObterTodos();
            //}
        }

        /// <summary>
        /// Atualizando o combo com os registros já cadastrados
        /// </summary>
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
            processarArquivoCronn_PRD_SgvCobranca(cnab400);
        }

        /// <summary>
        /// Processa o arquivo na base Cronn_PRD
        /// </summary>
        private void processarArquivoCronn_PRD_SgvCobranca(ArquivoRetornoCNAB400 cnab400)
        {

            //Cria uma lista com o NossoNumero e separado por tipos
            List<string> listaNossoNumero = new List<string>();
            List<string> tipo02 = new List<string>();
            List<string> tipo06 = new List<string>();
            List<string> tipo10 = new List<string>();
            List<string> tipo17 = new List<string>();

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
