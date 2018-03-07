using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Model
{
    public class Banco
    {
        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public int Numero { get; set; }

        public string Descricao => $"{Numero} - {Nome}";
    }
}
