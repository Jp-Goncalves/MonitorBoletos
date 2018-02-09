using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Model
{
    public class ContaCorrente
    {
        public ObjectId Id { get; set; }

        public String Numero { get; set; }

        public Banco Banco { get; set; }

        public Empresa Empresa { get; set; }
    }
}
