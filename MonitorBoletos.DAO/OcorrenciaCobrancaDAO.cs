using LiteDB;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.DAO
{
    public  class OcorrenciaCobrancaDAO
    {
        #region Fields
        /// <summary>
        /// Obter a string de conexão que vai ser utilizada
        /// </summary>
        private string Connection = ConexaoDAO.GetConnectionString();

        /// <summary>
        /// Nome da tabela a ser utilizada no LiteDB
        /// </summary>
        private readonly string _tableName = "OcorrenciaCobranca";

        #endregion

        #region Public Methods

        /// <summary>
        /// Inseri um registro novo no banco
        /// </summary>
        /// <param name="file"></param>
        public BsonValue Inserir(OcorrenciaCobranca file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var ocorrencia = db.GetCollection<OcorrenciaCobranca>(_tableName);

                return ocorrencia.Insert(file);
            }
        }

        /// <summary>
        /// Pega um registro a partir do numero
        /// </summary>
        /// <param name="file"></param>
        /// <returns>retorna um <see cref="OcorrenciaCobranca"/></returns>
        public OcorrenciaCobranca getByNumero(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var ocorrencia = db.GetCollection<OcorrenciaCobranca>(_tableName);

                var result = ocorrencia.FindById(file);

                return result;
            }
        }

        /// <summary>
        /// Atualiza um registro que ja existe
        /// </summary>
        /// <param name="file"></param>
        public void Atualizar(OcorrenciaCobranca file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var ocorrencia = db.GetCollection<OcorrenciaCobranca>(_tableName);

                ocorrencia.Update(file);
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
                var ocorencia = db.GetCollection<OcorrenciaCobranca>(_tableName);

                ocorencia.Delete(file);
            }
        }

        /// <summary>
        /// Retorna uma lista com todos os objetos
        /// </summary>
        /// <returns></returns>
        public IList<OcorrenciaCobranca> obterTodos()
        {
            using (var db = new LiteDatabase(Connection))
            {
                var ocorrencia = db.GetCollection<OcorrenciaCobranca>(_tableName);

                var result = ocorrencia.FindAll().ToList();
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public IList<OcorrenciaCobranca> obterTodos(Guid arquivo)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var ocorrencia = db.GetCollection<OcorrenciaCobranca>(_tableName);

                var result = ocorrencia.Find(Query.EQ("Arquivo.$id", arquivo));
                return result.ToList();
            }
        }

        #endregion
    }
}
