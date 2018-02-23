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
        private string Connection = ConfigurationManager.ConnectionStrings["Monitor"].ConnectionString;

        public void InserirLicenca(Licenca file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var licenca = db.GetCollection<Licenca>("licenca");

                licenca.Insert(file);
            }
        }

        public Licenca getByNumero(Banco numero)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var licenca = db.GetCollection<Licenca>("licenca");

                var result = licenca.FindById(numero.Numero);

                return result;
            }
        }

        public void atualizarLicenca(Licenca file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var licenca = db.GetCollection<Licenca>("licenca");

                licenca.Update(file);
            }
        }

        public void deletarLicenca(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var licenca = db.GetCollection<Licenca>("licenca");

                licenca.Delete(file);
            }
        }
    }
}
