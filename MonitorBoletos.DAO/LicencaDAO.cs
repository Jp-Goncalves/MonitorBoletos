using LiteDB;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.DAO
{
    public  class LicencaDAO
    {
        #region Fields
        /// <summary>
        /// Obter a string de conexão que vai ser utilizada
        /// </summary>
        private string Connection = ConexaoDAO.GetConnectionString();

        /// <summary>
        /// Nome da tabela no db para ser utilizada no LiteDB
        /// </summary>
        private readonly string _tableName = "licenca";
        #endregion

        #region Public Methods

        public void Inserir(Licenca file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var licenca = db.GetCollection<Licenca>(_tableName);

                licenca.Insert(file);
            }
        }

        public void Atualizar(Licenca file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var licenca = db.GetCollection<Licenca>(_tableName);

                licenca.Update(file);
            }
        }

        public void Deletar(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var licenca = db.GetCollection<Licenca>(_tableName);

                licenca.Delete(file);
            }
        }


        #endregion
    }
}
