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
    /// <summary>
    /// 
    /// </summary>
    public class ArquivoBusiness
    {
        private ArquivoDAO _dao = new ArquivoDAO();

        public ArquivoBusiness()
        {
            
        }

        public bool validarArquivo(string filename)
        {
            //TODO : Criar rotina para validar aequivo

            return true;
        }

        public Cronn.Core.Tendencia.Model.Cobranca obterBoletoCronn(OcorrenciaCobranca ocorrencia)
        {
            //TODO : Implementar a consulta de boletos no cronn

            return null;
        }

        public IList<Cronn.Core.Tendencia.Model.Cobranca> obterBoletosCronn(IList<OcorrenciaCobranca> ocorrencias)
        {
            //TODO : implementar obter boletos

            return null;
        }

        public void processarLinhas(string filename)
        {
                        
        }

    }

}
