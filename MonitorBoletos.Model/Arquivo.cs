using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Arquivo
    {
        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public string Diretorio { get; set; }

        //public Carteira Carteira { get; set; }

        //public ContaCorrente ContaCorrente { get; set; }

        //[BsonRef("OcorrenciaCobranca")]
        public IList<OcorrenciaCobranca> OcorrenciasCobranca { get; set; }

        public DateTime DataUpload { get; set; }

        public DateTime DataProcessamento { get; set; }

        public string Usuario { get; set; }
    }
}
