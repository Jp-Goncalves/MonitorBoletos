using Dapper;
using Semafaro.Titulos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafaro.Titulos.DAO
{
    public class CronnSgvCobrancaDAO
    {
        //static string strConexao
        //{
        //    get
        //    {
        //        return "Data Source=CHOI;Initial Catalog=Cronn_PRD;Integrated Security=True";
        //    }
        //}

        public CronnSgvCobranca ObterCronnSgvCobranca(string nossoNumero)
        {
            var query = @"select * from [Cronn_PRD].[Sgv].[Cobranca] where BoletoNossoNro = @NossoNumero";

            using (var conn = new SqlConnection(Semafaro.Titulos.DAO.StringDeConexao.stringConexaoCronn_PRD))
            {
                try
                {
                    var ocorrencia = conn.Query<CronnSgvCobranca>(query, new { NossoNumero = nossoNumero }).FirstOrDefault();

                    return ocorrencia;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
