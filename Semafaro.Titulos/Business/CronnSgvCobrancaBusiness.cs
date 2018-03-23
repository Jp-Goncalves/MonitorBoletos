using Semafaro.Titulos.DAO;
using Semafaro.Titulos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafaro.Titulos.Business
{
    public class CronnSgvCobrancaBusiness
    {
        /// <summary>
        /// Encontra o nosso numero no Cronn_PRD cobrança
        /// </summary>
        /// <param name="nossoNumero"></param>
        /// <returns>um objeto do tipo CronnSgvCobranca</returns>
        public CronnSgvCobranca ObterCronnSgvCobranca(string nossoNumero)
        {
            var dao = new CronnSgvCobrancaDAO();
            return dao.ObterCronnSgvCobranca(nossoNumero);
        }
    }
}
