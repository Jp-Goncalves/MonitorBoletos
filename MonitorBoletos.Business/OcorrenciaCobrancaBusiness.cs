using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoNet;

namespace MonitorBoletos.Business
{
    public class OcorrenciaCobrancaBusiness
    {
        public List<OcorrenciaCobranca> ocorrenciasCnab400(ArquivoRetornoCNAB400 retornoCNAB400)
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
                ocorrencia.Pagamento = item.ValorPago > 0 ?  true : false;
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
            }
            
            return listaOcorrencias;
        }
    }
}
