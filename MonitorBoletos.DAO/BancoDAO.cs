using LiteDB;
using MonitorBoletos.Model;
using System.Configuration;

namespace MonitorBoletos.DAO
{
    public class BancoDAO
    {
        #region Fields

        /// <summary>
        /// Obter a string de conexão que vai ser utilizada
        /// </summary>
        private string Connection = ConexaoDAO.GetConnectionString();

        /// <summary>
        /// Nome da tabela a ser utilizada no LiteDB
        /// </summary>
        private readonly string _tableName = "banco";
        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bank"></param>
        public void InserirBanco(Banco bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                banco.Insert(bank);
            }
        }

        public Banco getByNumero(Banco numero)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                var result = banco.FindById(numero.Numero);

                return result;
            }
        }

        public void atualizarBanco(Banco bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                banco.Update(bank);
            }
        }

        public void deletarBanco(string bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                banco.Delete(bank);
            }
        }
        #endregion
    }
}
