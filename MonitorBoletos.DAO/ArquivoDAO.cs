using LiteDB;
using MonitorBoletos.Model;
using System;
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
        /// Inseri um registro novo no banco
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
        /// Pega um registro a partir do numero
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Arquivo getByNumero(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                var result = arquivo.FindById(file);

                return result;
            }
        }

        public Arquivo getByNumero(Guid file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                var result = arquivo.FindById(file);

                return result;
            }
        }

        /// <summary>
        /// Atualiza um registro que ja existe
        /// </summary>
        /// <param name="file"></param>
        public void Atualizar(Arquivo file)
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

        public void deletarArquivo(Guid file)
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

        public Arquivo obterUltimoInserido()
        {
            var file = new Arquivo();
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>(_tableName);

                var result = arquivo.Find(Query.All(Query.Descending), limit: 1);
                foreach (var item in result)
                {
                    file = item;
                }
                return file;
            }
        }
        #endregion
    }
}
