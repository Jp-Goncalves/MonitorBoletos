using LiteDB;
using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MonitorBoletos.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class ArquivoBusiness
    {
        public ArquivoBusiness()
        {

        }

        public bool validarArquivo(string filename)
        {
            //TODO : Criar rotina para validar arquivo

            var result = filename;
            var extensao = Path.GetExtension(result).ToUpper();
            var ext = ".RET";

            if (filename == null)
            {
                return false;
            }
            else
            {
                if (extensao != ext)
                {
                    return false;
                }
                return true;
            }
        }

        public Banco validarArquivoLicenca(string arquivo)
        {
            var banco = new Banco();
            var empresa = new Empresa();
            var carteira = new Carteira();
            var contaCorrente = new ContaCorrente();

            var header = new HeaderBusiness();
            var result = header.leitorHeader(arquivo);

            banco.Nome = result.NomeBanco;
            banco.Numero = result.NumeroBanco;

            return banco;
        }

        public Cronn.Core.Tendencia.Model.Cobranca obterBoletoCronn(OcorrenciaCobranca ocorrencia)
        {
            //TODO : Implementar a consulta de boletos no cronn

            return null;
        }

        public IList<Cronn.Core.Tendencia.Model.Cobranca> obterBoletosCronn(IList<OcorrenciaCobranca> ocorrencias)
        {
            //TODO : implementar obter boletos

            return null;
        }

        public void processarLinhas(string filename)
        {

        }

    }

}
