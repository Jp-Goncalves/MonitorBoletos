
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

        private const string V = "2";
        #endregion

        #region Campos
        ArquivoRetornoCNAB400 cnab400 = new BoletoNet.ArquivoRetornoCNAB400();
        ArquivoRetornoCNAB240 cnab240 = new ArquivoRetornoCNAB240();
        List<OcorrenciaCobranca> outrasOcorrencias = new List<OcorrenciaCobranca>();
        List<OcorrenciaCobranca> NossoNumeroNaoEncontado = new List<OcorrenciaCobranca>();
        Guid guid;

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
                        try
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
                        catch (Exception)
                        {

                            throw;
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

        private bool LerArquivoRetorno(OpenFileDialog openFile)
        {
            try
            {
                using (var bussBanco = new BancoBusiness())
                {
                    var cbItem = cbBancos.SelectedValue;
                    var banco = bussBanco.ObterPorID(cbItem);
                    foreach (var item in openFile.FileNames)
                    {
                        var stream = new FileStream(item, FileMode.Open, FileAccess.Read);
                        //lê o arquivo de retorno
                        using (var bussArquivo = new ArquivoBusiness())
                        {
                            var tipo = bussArquivo.verificaTipoCNAB(item);
                            bussArquivo.lerArquivoRetorno(banco, stream, tipo);
                        }
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool LerArquivosRetorno()
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Filter = "Arquivos de Retorno (*.ret;*.crt)|*.ret;*.crt|Todos Arquivos (*.*)|*.*",
                    Title = "Selecione um arquivo!",
                    //InitialDirectory = @"C:\Users\joao.goncalves\Desktop\XML",
                    Multiselect = true
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (openFile.CheckFileExists == true)
                    {
                        return LerArquivoRetorno(openFile);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return false;
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
                //btProcessarArquivoCronn.Enabled = true;
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
                dataGridView1.DataSource = bc.ObterTodos();
                dataGridView1.Columns["OcorrenciasCobranca"].Visible = false;
            }
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
            var arquivo = new Arquivo();
            using (ArquivoBusiness arquivoBuss = new ArquivoBusiness())
            {
                arquivo = arquivoBuss.ObterPorId(guid);
            }
            processarArquivoCronn_PRD_SgvCobranca(arquivo);
        }

        /// <summary>
        /// Processa o arquivo na base Cronn_PRD
        /// </summary>
        private void processarArquivoCronn_PRD_SgvCobranca(Arquivo arquivo)
        {
            //Separa as ocorrencias e mostra a quantidade de cada
            var tipos_ocorrencia = from b in arquivo.OcorrenciasCobranca
                                   group b by b.CodigoOcorrencia into grupo
                                   select new { id = grupo.Key, qtde = grupo.Count() };

            //Cria uma lista de ocorrencias do tipo 6 e 17 "Pagamento"
            var pagos = arquivo.OcorrenciasCobranca.Where(p => p.CodigoOcorrencia.Trim().Equals("6") || p.CodigoOcorrencia.Trim().Equals("17"));

            listBoxMsg.Items.Add(string.Format(arquivo.Nome));
            listBoxMsg.Items.Add(string.Format($"A quantidade TOTAL de registros é {arquivo.OcorrenciasCobranca.Count()}"));
            listBoxMsg.Items.Add(string.Format($"A quantidade TOTAL de boletos pagos: {pagos.Count()}"));

            //Joga na List o resultado da pesquisa
            foreach (var item in tipos_ocorrencia)
            {
                listBoxMsg.Items.Add(string.Format($"A quantidade de registros do tipo {item.id} é de: {item.qtde}"));
                Console.WriteLine($"A quantidade de registros do tipo {item.id} é {item.qtde}");
            }
            Console.WriteLine($"A quantidade TOTAL de registros é {arquivo.OcorrenciasCobranca.Count()}");

            //cria uma instancia um objeto do tipo CronnSgvCobranca
            var sgvCobranca = new CronnSgvCobranca();
            //cria uma lista com esses objetos criados
            var ListCronnSgvCobranca = new List<CronnSgvCobranca>();
            //cria uma instancia do CronnBusiness
            var cronnbs = new CronnSgvCobrancaBusiness();

            var ListaNossoNumero = from n in pagos
                                   select new { n.NossoNumero }.NossoNumero;
            try
            {
                ListCronnSgvCobranca = cronnbs.ObterTodasCobrancas(ListaNossoNumero);

                var group = from b in ListCronnSgvCobranca
                            group b by b.TipoCobranca into grp
                            select new { key = grp.Key, cnt = grp.Count() };

                foreach (var item in group)
                {
                    switch (item.key)
                    {
                        case 0:
                            listBoxMsg.Items.Add(string.Format($"Quantidade de PosPago: {item.cnt}"));
                            Console.WriteLine($"Quantidade de PosPago: {item.cnt}");
                            break;

                        case 1:
                            listBoxMsg.Items.Add(string.Format($"Quantidade de PréPago: {item.cnt}"));
                            Console.WriteLine($"Quantidade de PréPago: {item.cnt}");
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar o banco de dados", ex.InnerException);
            }


            ////varre a lista com os todos os nossos numeros contido no arquivo e retorna uma lista de objetos do tipo CronnSgvCobranca
            //foreach (var item in pagos)
            //{
            //    sgvCobranca = cronnbs.ObterCronnSgvCobranca(item.NossoNumero);

            //    //verifica se o nossoNumero que está no arquito de retorno se econtrar na base de dados Cronn_PRD
            //    if (sgvCobranca == null)
            //    {
            //        NossoNumeroNaoEncontado.Add(item);
            //        listBoxMsg.Items.Add(string.Format("NossoNumero não encotrado na base de dados: {0}", item));
            //    }
            //    else
            //    {
            //        //adiciona o objeto CronnSgvCobranca na lista
            //        ListCronnSgvCobranca.Add(sgvCobranca);
            //    }
            //}

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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var linhaGrid = dataGridView1.Rows[e.RowIndex];
            var id = (Guid)linhaGrid.Cells["Id"].Value;
            new FrmListaOcorrencia(id).Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var linhaGrid = dataGridView1.Rows[e.RowIndex];
            var id = (Guid)linhaGrid.Cells["Id"].Value;
            guid = id;
            btProcessarArquivoCronn.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var svc = new MBSVC.DefaultSoapClient();
            var result = svc.FazerAlgo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LerArquivosRetorno();
            if (LerArquivosRetorno())
            {
                atualizarGridView();
                MessageBox.Show("Leitura realizada com sucesso!", "Arquivo Retorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btProcessarArquivoCronn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Não foi possivel ler o arquivo", "Arquivo Retorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btCalcularQuantidadeTotal_Click(object sender, EventArgs e)
        {
            calcularQuantidadeTotalPorEmpresa();
        }

        private void calcularQuantidadeTotalPorEmpresa()
        {
            using (var todos = new ArquivoBusiness())
            {
                var arquivos = new List<Arquivo>();
                arquivos = (List<Arquivo>)todos.ObterTodos();

                var log = new List<ContadorPorEmpresa>();
                var rdc = new List<ContadorPorEmpresa>();
                var drj = new List<ContadorPorEmpresa>();

                List<ContadorPorEmpresa> contarPorQuantidade(Arquivo arquivo)
                {
                    //Separa as ocorrencias e mostra a quantidade de cada
                    var tipos_ocorrencia = from b in arquivo.OcorrenciasCobranca
                                           group b by b.CodigoOcorrencia into grupo
                                           select new { id = grupo.Key, qtde = grupo.Count() };

                    var resultados = new List<ContadorPorEmpresa>();
                    foreach (var item in tipos_ocorrencia)
                    {
                        var result = new ContadorPorEmpresa();
                        result.TipoOcorrencia = item.id;
                        result.Quantidade = item.qtde;
                        resultados.Add(result);
                    }
                    return resultados;
                }

                foreach (var item in arquivos)
                {
                    if (item.Nome.Trim().ToUpper().Contains("LOG"))
                    {
                        var contar = contarPorQuantidade(item);
                        foreach (var count in contar)
                        {
                            log.Add(count);
                        }
                    }
                    else if (item.Nome.Trim().ToUpper().Contains("RDC"))
                    {
                        var contar = contarPorQuantidade(item);
                        foreach (var count in contar)
                        {
                            rdc.Add(count);
                        }
                    }
                    else if (item.Nome.Trim().ToUpper().Contains("DRJ"))
                    {
                        var contar = contarPorQuantidade(item);
                        foreach (var count in contar)
                        {
                            drj.Add(count);
                        }
                    }
                }

                resultado(log, "LOG");
                resultado(rdc, "RDC");
                resultado(drj, "DRJ");

                void resultado(List<ContadorPorEmpresa> empresa, string nomeEmpresa)
                {
                    var result = from b in empresa
                                 group b by b.TipoOcorrencia into grupo
                                 select new { id = grupo.Key, qtde = grupo.Sum(x => x.Quantidade) };

                    listBoxMsg.Items.Add(string.Format($"Empresa {nomeEmpresa}"));

                    foreach (var itens in result)
                    {
                        listBoxMsg.Items.Add(string.Format($"A quantidade de registros do tipo {itens.id} é de: {itens.qtde}"));
                        Console.WriteLine($"A quantidade de registros do tipo {itens.id} é {itens.qtde}");
                    }
                    listBoxMsg.Items.Add(string.Empty);
                }
            }
        }
    }
}
