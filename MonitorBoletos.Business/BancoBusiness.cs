using LiteDB;
using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Business
{
    public class BancoBusiness
    {
        private BancoDAO dao = new BancoDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Banco ObterPorId(ObjectId _id)
        {
            var bancos = dao.Get();

            return bancos.FindById(_id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_nome"></param>
        /// <returns></returns>
        public Banco ObterPorNome(string _nome)
        {
            return dao.Get()
                      .Find(x => x.Nome.Equals(_nome))
                      .FirstOrDefault();
        }

        public Banco GetByNumero()
        {
            return null;
        }

        public void Salvar(Banco b)
        {
            dao.Get().Insert(b);
        }
    }
}
