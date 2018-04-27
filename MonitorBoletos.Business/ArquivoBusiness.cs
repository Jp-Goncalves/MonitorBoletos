using BoletoNet;
using LiteDB;
using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace MonitorBoletos.Business
{
    /// <summary>
    /// Concentra as regras de negócio de arquivos
    /// </summary>
    public class ArquivoBusiness : IDisposable
    {

        #region Atributos e Propriedades
        private ArquivoDAO dao = new ArquivoDAO();
        #endregion

        #region Construtor
        public ArquivoBusiness()
        {

        }
        #endregion

        #region Metodos Publicos

        #region CRUD
        /// <summary>
        /// Chama a DAO para salvar um objeto Arquivo
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns>Retorna true caso consiga salvar e false caso de algum problema</returns>
        public bool Salvar(Arquivo arquivo)
        {
            var result = dao.Inserir(arquivo);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Chama o DAO para Obter todos os objetos no LiteDB
        /// </summary>
        /// <returns></returns>
        public IList<Arquivo> ObterTodos()
        {
            return dao.obterTodos();
        }

        /// <summary>
        /// Chama o DAO para Obter um Objeto do tipo Arquivo no LiteDB a partir de um id
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Arquivo ObterPorId(string file)
        {
            return dao.getByNumero(file);
        }

        public Arquivo ObterPorId(Guid file)
        {
            return dao.getByNumero(file);
        }

        public Arquivo ObterUltimoInserido()
        {
            return dao.obterUltimoInserido();
        }

        public bool DeletarPorId(Guid id)
        {
            var arquivo = ObterPorId(id);

            if (arquivo == null)
            {
                return false;
            }
            else
            {
                dao.deletarArquivo(id);
                return true;
            }
        }

        #endregion


        public bool validarArquivo(string filename)
        {

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
            var header = new HeaderBusiness();
            var result = header.leitorHeader(arquivo);

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
                        cnab.LerArquivoRetorno(banco, s);
                        return salvarArquivo400(b, (ArquivoRetornoCNAB400)cnab, s);
                        break;

                    case TipoArquivo.CNAB240:
                        cnab = new ArquivoRetornoCNAB240();
                        cnab.LerArquivoRetorno(banco, s);
                        return salvarArquivo240(b, (ArquivoRetornoCNAB240)cnab);
                        break;

                    default:
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler o arquivo de retorno.", ex.InnerException);
            }
        }

        /// <summary>
        /// Metodo para processar um arquivo de retorno do tipo Cnab400
        /// </summary>
        /// <param name="banco"><see cref="Model.Banco">vinculado ao arquivo</param>
        /// <param name="stream">stream do arquivo a ser lido</param>
        /// <returns><see cref="BoletoNet.ArquivoRetornoCNAB400"></returns>
        public ArquivoRetornoCNAB400 Retorno400(Model.Banco banco, Stream stream)
        {
            try
            {
                var cnab400 = new ArquivoRetornoCNAB400();
                var bank = new BoletoNet.Banco(banco.Numero);
                cnab400.LerArquivoRetorno(bank, stream);
                return cnab400;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler o arquivo de retorno.", ex.InnerException);
            }
        }

        /// <summary>
        /// Metodo para processar um arquivo de retorno do tipo Cnab200
        /// </summary>
        /// <param name="banco"><see cref="Model.Banco">vinculado ao arquivo</param>
        /// <param name="stream">stram do arquivo a ser lido</param>
        /// <returns><see cref="BoletoNet.ArquivoRetornoCNAB240"></returns>
        public ArquivoRetornoCNAB240 Retorno200(Model.Banco banco, Stream stream)
        {
            try
            {
                var cnab200 = new ArquivoRetornoCNAB240();
                var bank = new BoletoNet.Banco(banco.Numero);
                cnab200.LerArquivoRetorno(bank, stream);
                return cnab200;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler o arquivo de retorno.", ex.InnerException);
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

        #region Metodos Privados

        #region Salvar Arquivo
        /// <summary>
        /// Salva o arquivo no formato 400
        /// </summary>
        /// <param name="b">Banco vinculado</param>
        /// <param name="cnab">Cnab no formato 400</param>
        /// <returns></returns>
        private bool salvarArquivo400(Model.Banco b, ArquivoRetornoCNAB400 cnab, Stream stream)
        {
            var a = new Arquivo();
            FileStream fs = stream as FileStream;
            var ocorrenciaBuss = new OcorrenciaCobrancaBusiness();

            a.Id = Guid.NewGuid();
            a.Nome = fs.Name.Split('\\').Last();
            a.NomeEmpresa = fs.Name.Substring(fs.Name.Length - 7, 3).ToUpper();
            a.Diretorio = Path.GetDirectoryName(fs.Name);
            a.OcorrenciasCobranca = ocorrenciaBuss.ocorrenciasCnab400(cnab, a);
            a.DataProcessamento = DateTime.Now;
            a.Usuario = WindowsIdentity.GetCurrent().Name.Split('\\')[1].Trim();

            return Salvar(a);
        }

        /// <summary>
        /// Salva o arquivo no formato 240
        /// </summary>
        /// <param name="b">Banco vinculado</param>
        /// <param name="cnab">Cnab no formato 240</param>
        /// <returns></returns>
        private bool salvarArquivo240(Model.Banco b, ArquivoRetornoCNAB240 cnab)
        {
            var a = new Arquivo();
            a.DataProcessamento = DateTime.Now;
            a.Usuario = WindowsIdentity.GetCurrent().Name.Split('\\')[1].Trim();

            dao.Inserir(a);

            return false;
        }
        #endregion

        #endregion

    }

}
