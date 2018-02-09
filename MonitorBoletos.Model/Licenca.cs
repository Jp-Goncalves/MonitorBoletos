using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Model
{
    public class Licenca
    {
        public ObjectId Id { get; set; }

        public Banco Banco { get; set; }

        public Carteira Carteira { get; set; }

        public string Nome { get; set; }

        public string Diretorio { get; set; }
    }
}
