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
    public class EmpresaDAO
    {
        private string Connection = ConfigurationManager.ConnectionStrings["Monitor"].ConnectionString;

        public void InserirEmpresa(Empresa empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>("empresa");

                company.Insert(empresa);
            }
        }

        public Empresa getByCNPJ(Empresa empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>("empresa");

                var result = company.FindById(empresa.Cnpj);

                return result;
            }
        }

        public void atualizarEmpresa(Empresa empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>("empresa");

                company.Update(empresa);
            }
        }

        public void deletarEmpresa(string empresa)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var company = db.GetCollection<Empresa>("empresa");

                company.Delete(empresa);
            }
        }
    }
}
