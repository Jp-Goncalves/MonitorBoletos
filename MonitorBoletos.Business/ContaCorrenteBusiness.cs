using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Business
{
    public class ContaCorrenteBusiness
    {
        public ContaCorrente validarContaCorrente(ContaCorrente conta)
        {

            if (conta.Numero is null)
            {
                var inserirContaCorrente = new ContaCorrenteDAO();
                inserirContaCorrente.InserirContaCorrente(conta);
            }

            return conta;
        }
    }
}
