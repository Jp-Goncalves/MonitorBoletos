using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CobreBemX;
using LiteDB;

namespace MonitorBoletos.Model
{
    /// <summary>
    /// Ocorrencia
    /// </summary>
    public class OcorrenciaCobranca : IOcorrenciaCobranca
    {
        public ObjectId Id { get; set; }

        public int TipoCobranca { get; set; }

        public string NossoNumero { get; set; }

        public string CodigoOcorrencia { get; set; }

        public IMotivosOcorrencia MotivosOcorrencia { get; set; }

        public string DataOcorrencia { get; set; }

        public bool Pagamento { get; set; }

        public string DataCredito { get; set; }

        public double ValorPago { get; set; }

        public double ValorMultaPaga { get; set; }

        public double ValorJurosPago { get; set; }

        public double ValorTaxaCobranca { get; set; }

        public double ValorCredito { get; set; }

        public string NumeroDocumento { get; set; }

        public double ValorDesconto { get; set; }

        public string Banco { get; set; }

        public string Carteira { get; set; }

        public string Agencia { get; set; }

        public string ContaCorrente { get; set; }

        public string CodigoCedente { get; set; }

        public string NumeroControle { get; set; }

        public double ValorOutrosAcrescimos { get; set; }

        public IDadosOcorrencia DadosOcorrencia { get; set; }

        public double ValorAbatimento { get; set; }

        public double ValorIOF { get; set; }

        public double ValorOutrasDespesas { get; set; }
    }
}
