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

        /// <summary>
        /// Validar a Conta Corrente
        /// </summary>
        /// <param name="conta">para verificar se ela existe</param>
        /// <returns>retorna uma conta</returns>
        public ContaCorrente validarContaCorrente(ContaCorrente conta)
        {
            var account = new ContaCorrenteDAO();

            var contacorrente = account.getByNumero(conta);

            return contacorrente;
        }
    }
}
