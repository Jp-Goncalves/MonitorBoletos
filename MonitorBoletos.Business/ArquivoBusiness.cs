using LiteDB;
using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MonitorBoletos.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class ArquivoBusiness
    {
        private ArquivoDAO _dao = new ArquivoDAO();

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

        public void validarArquivoRetorno(string file)
        {
            //TODO : Validar a Empresa, carteira e banco do arquivo

            //Regex para ler o Header do arquivo
            var leitorRegularExpression = Regex.Split(file,
                @",(^\d{1}\d{1}[A-Z]{7}\d{2}[\s A-Z\s]{15}\d{20}[\s A-Z\s]{30}\d{3}[\s A-Z \s]{15}\d{6}\d{8}\d{5}.{266}\d{6}.{9}\d{6})", RegexOptions.Compiled);

            var banco = new Banco();

            banco.Numero = leitorRegularExpression[7].ToString();
            banco.Nome = leitorRegularExpression[8].ToString().ToUpper();
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
