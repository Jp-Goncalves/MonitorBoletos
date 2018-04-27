using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafaro.Titulos.Model
{
    public class ContadorPorEmpresa
    {
        public string Nome { get; set; }

        public string TipoOcorrencia { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorTitulo { get; set; }

        public decimal ValorPago { get; set; }
    }
}
