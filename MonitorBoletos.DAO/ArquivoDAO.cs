using LiteDB;
using MonitorBoletos.Model;
using System.Configuration;

namespace MonitorBoletos.DAO
{
    public class ArquivoDAO
    {
        #region Fields
        /// <summary>
        /// Obter a string de conexão que vai ser utilizada
        /// </summary>
        private string Connection = ConexaoDAO.GetConnectionString();

        /// <summary>
        /// Nome da tabela a ser utilizada no LiteDB
        /// </summary>
        private readonly string _tableName = "arquivo";

        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public void InserirArquivo(Arquivo file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                arquivo.Insert(file);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Arquivo getByNumero(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Arquivo>(_tableName);

                var result = banco.FindById(file);

                return result;
            }
        }

        public void atualizarBanco(Arquivo file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                arquivo.Update(file);
            }
        }

        public void deletarArquivo(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                arquivo.Delete(file);
            }
        }
        #endregion
    }
}
