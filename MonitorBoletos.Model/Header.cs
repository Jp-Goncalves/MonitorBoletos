using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Business
{
    public class Header
    {
        public int IdentificacaoRegistro { get; set; }

        public int IdentificacaoArquivoRetorno { get; set; }

        public string LiteralRetorno { get; set; }

        public int CodigoServico  { get; set; }

        public string LiteralServico { get; set; }

        public int CodigoEmpresa { get; set; }

        public string NomeEmpresa { get; set; }

        public int NumeroBanco { get; set; }

        public string NomeBanco { get; set; }

        public string DataGravacaoArquivo { get; set; }

        public int DensidadeGravacao { get; set; }

        public int NumeroAvisoBancario { get; set; }

        public string DataCredito { get; set; }

        public int NumeroSequencialRegistro { get; set; }
    }
}
