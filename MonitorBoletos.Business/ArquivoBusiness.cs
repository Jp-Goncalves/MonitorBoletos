using LiteDB;
using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MonitorBoletos.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class ArquivoBusiness
    {
        public ArquivoBusiness()
        {

        }

        public bool validarArquivo(string filename)
        {
            //TODO : Criar rotina para validar arquivo
            var result = filename;
            var extensao = Path.GetExtension(result).ToUpper();
            var ext = ".RET";

            if (filename == null)
            {
                return false;
            }
            else
            {
                if (extensao != ext)
                {
                    return false;
                }
                return true;
            }
        }

        public Banco validarArquivoLicenca(string arquivo)
        {
            var banco = new Banco();
            //var empresa = new Empresa();
            //var carteira = new Carteira();
            //var contaCorrente = new ContaCorrente();
            //var licenca = new Licenca();

            var header = new HeaderBusiness();
            var result = header.leitorHeader(arquivo);


            //using (var leitor = new StreamReader(arquivo))
            //{
            //    var resultado = leitor.ReadLine();

            //    if (resultado.Contains(drj))
            //    {
            //        cobreBem.ArquivoLicenca = @"C:\Temp\Monitor\lic\13263506000135-237-04.conf";
            //    }
            //    else if (resultado.Contains(log))
            //    {
            //        cobreBem.ArquivoLicenca = @"C:\Temp\Monitor\lic\09427183000109-237-04.conf";
            //    }
            //    else if (resultado.Contains(rdc))
            //    {
            //        cobreBem.ArquivoLicenca = @"C:\Temp\Monitor\lic\09446526000174-237-04.conf";
            //    }

            //    cobreBem.ArquivoRetorno.Diretorio = Path.GetDirectoryName(arquivo);

            //    banco.Nome = cobreBem.NomeBanco;
            //    banco.Numero = cobreBem.NumeroBanco;
            //    empresa.Nome = cobreBem.NomeCedente;
            //    empresa.Cnpj = cobreBem.CnpjCpfCedente;
            //    carteira.Numero = Convert.ToInt32(cobreBem.CodigoCarteira);
            //    contaCorrente.Numero = cobreBem.NumeroContaCorrente;
            //    contaCorrente.Banco = banco;
            //    contaCorrente.Empresa = empresa;
            //    licenca.Diretorio = cobreBem.ArquivoLicenca;
            //    licenca.Nome = Path.GetFileName(arquivo);
            //}

            //var bank = new BancoBusiness();
            //bank.validaBanco(banco);

            return banco;
        }

        //public Cronn.Core.Tendencia.Model.Cobranca obterBoletoCronn(OcorrenciaCobranca ocorrencia)
        //{
        //    //TODO : Implementar a consulta de boletos no cronn

        //    return null;
        //}

        //public IList<Cronn.Core.Tendencia.Model.Cobranca> obterBoletosCronn(IList<OcorrenciaCobranca> ocorrencias)
        //{
        //    //TODO : implementar obter boletos

        //    return null;
        //}

        public void processarLinhas(string filename)
        {

        }

    }

}
