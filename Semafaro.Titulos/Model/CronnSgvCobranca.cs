using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafaro.Titulos.Model
{
    public class CronnSgvCobranca
    {
        public long Id { get; set; }

        public DateTime? DataCobranca { get; set; }

        public decimal? ValorPagto { get; set; }

        public decimal? ValorTotal { get; set; }

        public string BoletoLinhaDig { get; set; }

        public decimal? BoletoValor { get; set; }

        public string BoletoNossoNro { get; set; }

        public string Dac { get; set; }

        public string BoletoCodBarras { get; set; }

        public decimal? CustoBoleto { get; set; }

        public int? TipoCobranca { get; set; }

        public string Situacao { get; set; }

        public DateTime? DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        public decimal? Juros { get; set; }

        public decimal? Multa { get; set; }

        public decimal? OutrosAcrescimos { get; set; }

        public decimal? ValorTitulo { get; set; }

        public string NumeroDocumento { get; set; }

        public string Parcela { get; set; }

        public DateTime? DataImpressao { get; set; }

        public string UsuarioImpressao { get; set; }

        public bool? CobrancaRede { get; set; }

        public bool? LimiteUnificado { get; set; }

        public bool? EmailEnviado { get; set; }

        public string IniciativaRegeracao { get; set; }

        public DateTime? DataProcessamento { get; set; }

        public long? IdCliente { get; set; }

        public long? IdCobrancaOrigem { get; set; }

        public long? IdNegociacaoCobranca { get; set; }

        public long? IdConvenioBancario { get; set; }

        public long? IdParametroCobranca { get; set; }

        public string IdTerminal { get; set; }

        public long? IdRede { get; set; }

        public long? IdResponsavelLimite { get; set; }

        public long? IdEmpresa { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
