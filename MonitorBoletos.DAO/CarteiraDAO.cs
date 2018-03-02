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
        #region Fields

        /// <summary>
        /// Obter a string de conexão que vai ser utilizada
        /// </summary>
        private string Connection = ConexaoDAO.GetConnectionString();

        /// <summary>
        /// Nome da tabela a ser utilizada no LiteDB
        /// </summary>
        private readonly string _tableName = "carteira";

        #endregion

        #region Public Methods
        public void InserirCarteira(Carteira carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>(_tableName);

                card.Insert(carteira);
            }
        }

        public Carteira getByNumero(Carteira carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>(_tableName);

                var result = card.FindById(carteira.Numero);

                return result;
            }
        }

        public void atualizarCarteira(Carteira carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>(_tableName);

                card.Update(carteira);
            }
        }

        public void deletarCarteira(string carteira)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var card = db.GetCollection<Carteira>(_tableName);

                card.Delete(carteira);
            }
        }
        #endregion
    }
}
