using LiteDB;
using MonitorBoletos.Model;
using System.Configuration;

namespace MonitorBoletos.DAO
{
    public class BancoDAO
    {
        private string Connection = ConfigurationManager.ConnectionStrings["Monitor"].ConnectionString;

        public void InserirBanco(Banco bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>("banco");

                banco.Insert(bank);
            }
        }

        public Banco getByNumero(Banco numero)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>("banco");

                var result = banco.FindById(numero.Numero);

                return result;
            }
        }

        public void atualizarBanco(Banco bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>("banco");

                banco.Update(bank);
            }
        }

        public void deletarBanco(string bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>("banco");

                banco.Delete(bank);
            }
        }
    }
}
