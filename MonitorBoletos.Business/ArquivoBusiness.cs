using BoletoNet;
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
    /// Concentra as regras de negócio de arquivos
    /// </summary>
    public class ArquivoBusiness : IDisposable
    {
        #region Construtor
        public ArquivoBusiness()
        {

        }
        #endregion

        #region Metodos Publicos
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

        public Model.Banco validarArquivoLicenca(string arquivo)
        {
            var banco = new Model.Banco();
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

        public void processarLinhas(string filename)
        {

        }

        /// <summary>
        /// Verifica o tipo de CNAB ao ler um Stream
        /// </summary>
        /// <param name="arquivo">stream a ser lido</param>
        /// <returns>retorna um <see cref="TipoArquivo"/></returns>
        public TipoArquivo verificaTipoCNAB(string arquivo)
        {
            using (StreamReader stream = new StreamReader(arquivo, System.Text.Encoding.UTF8))
            {
                // Lendo o arquivo
                string linha = stream.ReadLine();

                if (linha.Length > 240)
                {
                    return TipoArquivo.CNAB400;
                }

                return TipoArquivo.CNAB240;
            }
        }

        /// <summary>
        /// Metodo para ler e processar o arquivo de retorno
        /// </summary>
        /// <param name="b"><see cref="Model.Banco"/> vinculado ao arquivo</param>
        /// <param name="s">stream do arquivo a ser lido</param>
        /// <param name="tipo">informa o tipo do cnab a ser lido</param>
        /// <returns></returns>
        public bool lerArquivoRetorno(Model.Banco b, Stream s, TipoArquivo tipo)
        {
            try
            {
                IArquivoRetorno cnab = null;
                var banco = new BoletoNet.Banco(b.Numero);

                switch (tipo)
                {
                    case TipoArquivo.CNAB400:
                        cnab = new ArquivoRetornoCNAB400();
                        //cnab.LinhaDeArquivoLida += new EventHandler<LinhaDeArquivoLidaArgs>(cnab400_LinhaDeArquivoLida);
                        cnab.LerArquivoRetorno(banco, s);
                        //cnab.TipoArquivo
                        break;

                    case TipoArquivo.CNAB240:
                        cnab = new ArquivoRetornoCNAB240();
                        cnab.LerArquivoRetorno(banco, s);
                        break;

                    default:
                        break;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler o arquivo de retorno.",ex.InnerException);
            }            
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ArquivoBusiness() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #endregion
    }

}
