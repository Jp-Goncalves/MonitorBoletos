using LiteDB;
using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Business
{
    public class BancoBusiness
    {
        public Banco validaBanco(Banco bank)
        {
            var banco = new Banco();
            banco = bank;

            if (banco.Numero is null)
            {
                var inserirBanco = new BancoDAO();
                inserirBanco.InserirBanco(banco);
            }
            else
            {
                var atualizarBanco = new BancoDAO();
                atualizarBanco.atualizarBanco(banco);
            }

            return banco;
        }
    }
}
