using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Model
{
    public class Carteira
    {
        public ObjectId Id { get; set; }

        public long Numero { get; set; }
    }
}
