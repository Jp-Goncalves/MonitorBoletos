using LiteDB;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.DAO
{
    public class BancoDAO : GenericDAO<Banco>
    {
        #region Contrutor
        /// <summary>
        /// Connstruindo e setando o nome da tabela
        /// </summary>
        public BancoDAO() : base("bancos") { }

        #endregion

    }
}
