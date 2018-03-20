using LiteDB;
using MonitorBoletos.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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
        public BsonValue Inserir(Arquivo file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                return arquivo.Insert(file);
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

        /// <summary>
        /// Atualiza um registro que ja existe
        /// </summary>
        /// <param name="file"></param>
        public void atualizarBanco(Arquivo file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                arquivo.Update(file);
            }
        }

        /// <summary>
        /// Deleta um arquivo
        /// </summary>
        /// <param name="file"></param>
        public void deletarArquivo(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                arquivo.Delete(file);
            }
        }

        /// <summary>
        /// Retorna uma lista com todos os objetos
        /// </summary>
        /// <returns></returns>
        public IList<Arquivo> obterTodos()
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                var result = arquivo.FindAll().ToList();
                return result;
            }
        }
        #endregion
    }
}
