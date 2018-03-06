using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Business
{
    public class HeaderBusiness
    {
        /// <summary>
        /// Le o Header do arquivo de retorno
        /// </summary>
        /// <param name="arquivo">para separar as informações que vem no Header do arquivo</param>
        /// <returns>Objeto Header</returns>
        public Header leitorHeader(string arquivo)
        {
            var header = new Header();

            using (var leitor = new StreamReader(arquivo))
            {
                var result = leitor.ReadLine();

                header.IdentificacaoRegistro = int.Parse(result.Substring(0, 1));
                header.IdentificacaoArquivoRetorno = int.Parse(result.Substring(1, 1));
                header.LiteralRetorno = result.Substring(2, 7);
                header.CodigoServico = int.Parse(result.Substring(9, 2));
                header.LiteralServico = result.Substring(11, 15);
                header.CodigoEmpresa = int.Parse(result.Substring(26, 20));
                header.NomeEmpresa = result.Substring(46, 30);
                header.NumeroBanco = int.Parse(result.Substring(76, 3));
                header.NomeBanco = result.Substring(79, 15);
                header.DataGravacaoArquivo = result.Substring(94, 6);
                header.DensidadeGravacao = int.Parse(result.Substring(100, 8));
                header.NumeroAvisoBancario = int.Parse(result.Substring(108, 5));
                header.DataCredito = result.Substring(379, 6);
                header.NumeroSequencialRegistro = int.Parse(result.Substring(394, 6));
            }

            return header;
        }
    }
}
