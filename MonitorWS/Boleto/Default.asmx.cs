using Semafaro.Titulos.Business;
using Semafaro.Titulos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace MonitorWS.Boleto
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Default : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World!";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string HelloWorld2(String nome)
        {
            return $"Olá {nome}, tudo bem?";
        }

        [WebMethod]
        public int SomarValores(int valor1, int valor2)
        {
            return valor1 + valor2;
        }

        [WebMethod]
        public MyObj FazerAlgo()
        {
            return new MyObj() { Idade = 20, Nome = "JP", Chato = "sim" };
        }

        [WebMethod]
        public CronnSgvCobranca TituloPorNossoNumero(string nossoNumero)
        {
            var boletoBuss = new CronnSgvCobrancaBusiness();
            return boletoBuss.ObterCronnSgvCobranca(nossoNumero);
        }

        [WebMethod]
        public List<CronnSgvCobranca> ObterListaTitulos(List<string> ListNossoNumero)
        {
            var cronnbuss = new CronnSgvCobrancaBusiness();
            return cronnbuss.ObterTodasCobrancas(ListNossoNumero);
        }

    }


    public class MyObj
    {
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Chato { get; set; }
    }
}
