using LiteDB;
using System;
using System.Collections.Generic;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public static LiteDatabase GetConection()
        {
            if (_db == null)
            {
                _db = new LiteDatabase(@"nosql.db");
            }
            
            return _db;
        }
    }
}
