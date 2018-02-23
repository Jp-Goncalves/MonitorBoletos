using LiteDB;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.DAO
{
    public  class ContaCorrenteDAO
    {
        private string Connection = ConfigurationManager.ConnectionStrings["Monitor"].ConnectionString;

        public void InserirContaCorrente(ContaCorrente conta)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var contacorrente = db.GetCollection<ContaCorrente>("contacorrente");

                contacorrente.Insert(conta);
            }
        }

        public ContaCorrente getByNumero(ContaCorrente numero)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var contacorrente = db.GetCollection<ContaCorrente>("contacorrente");

                var result = contacorrente.FindById(numero.Numero);

                return result;
            }
        }

        public void atualizarContaCorrente(ContaCorrente conta)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<ContaCorrente>("contacorrente");

                banco.Update(conta);
            }
        }

        public void deletarContaCorrente(string conta)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var contacorrente1 = db.GetCollection<ContaCorrente>("contacorrente");

                contacorrente1.Delete(conta);
            }
        }
    }
}
