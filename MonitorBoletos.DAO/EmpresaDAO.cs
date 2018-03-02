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
    /// <summary>
    /// Centralizar o acesso a dados do modelo <see cref="Empresa"/>
    /// </summary>
    public class EmpresaDAO
    {
        #region Fields
        /// <summary>
        /// Obter a string de conexão que vai ser utilizada
        /// </summary>
        private string Connection = ConexaoDAO.GetConnectionString();

        /// <summary>
        /// Nome da tabela no db para ser utilizada no LiteDB
        /// </summary>
        private readonly string _tableName = "empresa";
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        public void InserirEmpresa(Empresa empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>(_tableName);

                company.Insert(empresa);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public Empresa getByCNPJ(Empresa empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>(_tableName);

                var result = company.FindById(empresa.Cnpj);

                return result;
            }
        }

        public void atualizarEmpresa(Empresa empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>(_tableName);

                company.Update(empresa);
            }
        }

        public void deletarEmpresa(string empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>(_tableName);

                company.Delete(empresa);
            }
        }
        #endregion
    }
}
