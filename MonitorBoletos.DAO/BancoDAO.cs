using LiteDB;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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
        public BsonValue Inserir(Banco bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                return banco.Insert(bank);
            }
        }

        public IList<Banco> obterTodos()
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                var result = banco.FindAll().ToList();
                return result;
            }
        }

        public Banco GetByNumero(Banco numero)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                var result = banco.FindById(numero.Numero);

                return result;
            }
        }

        public Banco obterPorId(ObjectId id)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                var result = banco.FindById(id);
                return result;
            }
        }

        public void atualizar(Banco bank)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Banco>(_tableName);

                banco.Update(bank);
            }
        }

        public void deletar(string bank)
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
