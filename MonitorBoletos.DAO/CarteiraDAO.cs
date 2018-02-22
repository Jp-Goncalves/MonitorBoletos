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
    public class CarteiraDAO
    {
        private string Connection = ConfigurationManager.ConnectionStrings["Monitor"].ConnectionString;

        public void InserirCarteira(Carteira carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>("carteira");

                card.Insert(carteira);
            }
        }

        public Carteira getByNumero(Carteira carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>("carteira");

                var result = card.FindById(carteira.Numero);

                return result;
            }
        }

        public void atualizarCarteira(Carteira carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>("carteira");

                card.Update(carteira);
            }
        }

        public void deletarCarteira(string carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>("carteira");

                card.Delete(carteira);
            }
        }
    }
}
