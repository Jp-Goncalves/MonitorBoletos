using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.DAO
{
    public static class ConexaoDAO
    {
        /// <summary>
        /// 
        /// </summary>
        private static LiteDatabase _db;

        /// <summary>
        /// Retorna a string de conexão, busca a string noa rquivo de configuração
        /// </summary>
        /// <returns>connection string</returns>
        public static string GetConnectionString()
        {
            //busca a string de conexão no arquivo de configuração
            //return ConfigurationManager.ConnectionStrings["Monitor"].ConnectionString;
            return @"nosql.db";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static LiteDatabase GetConnection()
        {
            if (_db == null)
            {
                _db = new LiteDatabase(@"nosql.db");
            }
            
            return _db;
        }
    }
}
