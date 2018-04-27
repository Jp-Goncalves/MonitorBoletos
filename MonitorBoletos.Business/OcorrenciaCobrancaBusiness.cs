using MonitorBoletos.Model;
using MonitorBoletos.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoNet;
using LiteDB;

namespace MonitorBoletos.Business
{
    public class OcorrenciaCobrancaBusiness
    {
        #region Atributos e Propriedades
        private OcorrenciaCobrancaDAO dao = new OcorrenciaCobrancaDAO();
        #endregion

        #region CRUD

        /// <summary>
        /// Chama o DAO para Inserir um objeto OcorrenciaCobranca
        /// </summary>
        /// <param name="ocorrenciaCobranca"></param>
        /// <returns></returns>
        public bool Salvar(OcorrenciaCobranca ocorrenciaCobranca)
        {
            var result = dao.Inserir(ocorrenciaCobranca);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Chama o DAO para Obter todos os objetos no LiteDB
        /// </summary>
        /// <returns></returns>
        public IList<OcorrenciaCobranca> ObterTodos()
        {
            return dao.obterTodos();
        }

        public IList<OcorrenciaCobranca> ObterTodos(Guid arquivo)
        {
            return dao.obterTodos(arquivo);
        }

        /// <summary>
        /// Chama o DAO para Obter um registro pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna um <see cref="OcorrenciaCobranca"></returns>
        public OcorrenciaCobranca ObterPorId(string id)
        {
            return dao.getByNumero(id);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Transforma um objeto do tipo ArquivoRetornoCNAB400 em um OcorrenciaCobranca
        /// </summary>
        /// <param name="retornoCNAB400"></param>
        /// <returns><</OcorrenciaCobranca>"/></returns>
        public List<OcorrenciaCobranca> ocorrenciasCnab400(ArquivoRetornoCNAB400 retornoCNAB400, Arquivo arquivo)
        {
            var listaOcorrencias = new List<OcorrenciaCobranca>();

            foreach (var item in retornoCNAB400.ListaDetalhe)
            {
                var ocorrencia = new OcorrenciaCobranca();
                ocorrencia.Id = Guid.NewGuid();
                ocorrencia.Arquivo = arquivo;
                ocorrencia.TipoCobranca = item.CodigoOcorrencia;
                ocorrencia.NossoNumero = item.NossoNumeroComDV.Substring(0,11);
                ocorrencia.CodigoOcorrencia = item.CodigoOcorrencia.ToString();
                ocorrencia.MotivosOcorrencia = item.MotivoCodigoOcorrencia;
                ocorrencia.DataOcorrencia = item.DataOcorrencia.ToString();
                ocorrencia.Pagamento = item.ValorPago > 0 ? true : false;
                ocorrencia.DataCredito = item.DataCredito.ToString();
                ocorrencia.ValorPago = item.ValorPago;
                ocorrencia.ValorMultaPaga = item.ValorMulta;
                ocorrencia.ValorJurosPago = item.Juros;
                ocorrencia.ValorTaxaCobranca = item.TarifaCobranca;
                ocorrencia.ValorCredito = item.OutrosCreditos;
                ocorrencia.NumeroDocumento = item.NumeroDocumento;
                ocorrencia.ValorDesconto = item.Descontos;
                ocorrencia.Banco = item.CodigoBanco.ToString();
                ocorrencia.Carteira = item.Carteira;
                ocorrencia.Agencia = item.Agencia.ToString();
                ocorrencia.ContaCorrente = item.ContaCorrente.ToString();
                ocorrencia.CodigoCedente = item.AgenciaCobradora.ToString();
                ocorrencia.NumeroControle = item.NumeroControle;
                ocorrencia.ValorOutrosAcrescimos = item.OutrosDebitos;
                ocorrencia.DadosOcorrencia = item.DescricaoOcorrencia;
                ocorrencia.ValorAbatimento = item.ValorAbatimento;
                ocorrencia.ValorIOF = item.IOF;
                ocorrencia.ValorOutrasDespesas = item.ValorOutrasDespesas;
                ocorrencia.ValorTitulo = item.ValorTitulo;

                Salvar(ocorrencia);
                listaOcorrencias.Add(ocorrencia);
            }
            return listaOcorrencias;
        }
        #endregion
    }
}
