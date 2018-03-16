using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafaro.Titulos.DAO
{
    public class StringDeConexao
    {
        /// <summary>
        /// String de comunicação com o Banco de Dados Choi
        /// </summary>
        /// <return>Uma string de conexao com o bando Cronn_PRD</return>
        public static string stringConexaoCronn_PRD
        {
            get
            {
                return "Data Source=CHOI;Initial Catalog=Cronn_PRD;Integrated Security=True";
            }
        }
    }
}
