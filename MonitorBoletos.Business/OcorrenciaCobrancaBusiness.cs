using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoNet;
using MonitorBoletos.DAO;

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Transforma um objeto do tipo ArquivoRetornoCNAB400 em um OcorrenciaCobranca
        /// </summary>
        /// <param name="retornoCNAB400"></param>
        /// <returns></returns>
        public bool ocorrenciasCnab400(ArquivoRetornoCNAB400 retornoCNAB400)
        {
            var listaOcorrencias = new List<OcorrenciaCobranca>();
            var ocorrencia = new OcorrenciaCobranca();

            foreach (var item in retornoCNAB400.ListaDetalhe)
            {
                ocorrencia.TipoCobranca = item.CodigoOcorrencia;
                ocorrencia.NossoNumero = item.NossoNumero;
                ocorrencia.CodigoOcorrencia = item.CodigoOcorrencia.ToString();
                ocorrencia.MotivosOcorrencia = item.MotivoCodigoOcorrencia;
                ocorrencia.DataOcorrencia = item.DataOcorrencia.ToString();
                ocorrencia.Pagamento = item.ValorPago > 0 ? true : false;
                ocorrencia.DataCredito = item.DataCredito.ToString();
                ocorrencia.ValorPago = Convert.ToDouble(item.ValorPago);
                ocorrencia.ValorMultaPaga = Convert.ToDouble(item.ValorMulta);
                ocorrencia.ValorJurosPago = Convert.ToDouble(item.Juros);
                ocorrencia.ValorTaxaCobranca = Convert.ToDouble(item.TarifaCobranca);
                ocorrencia.ValorCredito = Convert.ToDouble(item.OutrosCreditos);
                ocorrencia.NumeroDocumento = item.NumeroDocumento;
                ocorrencia.ValorDesconto = Convert.ToDouble(item.Descontos);
                ocorrencia.Banco = item.CodigoBanco.ToString();
                ocorrencia.Carteira = item.Carteira;
                ocorrencia.Agencia = item.Agencia.ToString();
                ocorrencia.ContaCorrente = item.ContaCorrente.ToString();
                ocorrencia.CodigoCedente = item.AgenciaCobradora.ToString();
                ocorrencia.NumeroControle = item.NumeroControle;
                ocorrencia.ValorOutrosAcrescimos = Convert.ToDouble(item.OutrosDebitos);
                ocorrencia.DadosOcorrencia = item.DescricaoOcorrencia;
                ocorrencia.ValorAbatimento = Convert.ToDouble(item.ValorAbatimento);
                ocorrencia.ValorIOF = Convert.ToDouble(item.IOF);
                ocorrencia.ValorOutrasDespesas = Convert.ToDouble(item.ValorOutrasDespesas);

                listaOcorrencias.Add(ocorrencia);

                Salvar(ocorrencia);
            }
            return true;
        }
        #endregion
    }
}
