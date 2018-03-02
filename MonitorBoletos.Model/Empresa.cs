using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Model
{
    public class Empresa
    {
        public ObjectId Id { get; set; }

        public String Cnpj { get; set; }  

        public string Nome { get; set; }

        public IList<ContaCorrente> ContasCorrente { get; set; }
    }
}
