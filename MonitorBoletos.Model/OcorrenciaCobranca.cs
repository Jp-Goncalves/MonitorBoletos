using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace MonitorBoletos.Model
{
    /// <summary>
    /// Ocorrencia
    /// </summary>
    public class OcorrenciaCobranca
    {
        [BsonId]
        public Guid Id { get; set; }

        public int TipoCobranca { get; set; }

        public string NossoNumero { get; set; }

        public string CodigoOcorrencia { get; set; }

        public string MotivosOcorrencia { get; set; }

        public string DataOcorrencia { get; set; }

        public bool Pagamento { get; set; }

        public string DataCredito { get; set; }

        public decimal ValorTitulo { get; set; }

        public decimal ValorPago { get; set; }

        public decimal ValorMultaPaga { get; set; }

        public decimal ValorJurosPago { get; set; }

        public decimal ValorTaxaCobranca { get; set; }

        public decimal ValorCredito { get; set; }

        public string NumeroDocumento { get; set; }

        public decimal ValorDesconto { get; set; }

        public string Banco { get; set; }

        public string Carteira { get; set; }

        public string Agencia { get; set; }

        public string ContaCorrente { get; set; }

        public string CodigoCedente { get; set; }

        public string NumeroControle { get; set; }

        public decimal ValorOutrosAcrescimos { get; set; }

        public string DadosOcorrencia { get; set; }

        public decimal ValorAbatimento { get; set; }

        public decimal ValorIOF { get; set; }

        public decimal ValorOutrasDespesas { get; set; }


        [BsonRef("arquivo")]
        public Arquivo Arquivo { get; set; }
    }
}
