using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.DAO
{
    public class GenericDAO<T>
    {
        /// <summary>
        /// Conexão com o banco LiteDB
        /// </summary>
        private LiteDB.LiteDatabase _db;

        /// <summary>
        /// Nome da tabela a ser criada no LiteDB
        /// </summary>
        private readonly string _tableName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        public GenericDAO(string tableName)
        {
            _db = ConexaoDAO.GetConection();
            _tableName = tableName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public LiteCollection<T> Get()
        {
            return _db.GetCollection<T>(_tableName);
        }

    }
}

