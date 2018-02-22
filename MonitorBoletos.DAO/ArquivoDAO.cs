using LiteDB;
using MonitorBoletos.Model;
using System.Configuration;

namespace MonitorBoletos.DAO
{
    public class ArquivoDAO
    {
        private string Connection = ConfigurationManager.ConnectionStrings["Monitor"].ConnectionString;

        public void InserirArquivo(Arquivo file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>("arquivo");

                arquivo.Insert(file);
            }
        }

        public Arquivo getByNumero(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<Arquivo>("arquivo");

                var result = banco.FindById(file);

                return result;
            }
        }

        public void atualizarBanco(Arquivo file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>("arquivo");

                arquivo.Update(file);
            }
        }

        public void deletarArquivo(string file)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var arquivo = db.GetCollection<Arquivo>("arquivo");

                arquivo.Delete(file);
            }
        }
    }
}
