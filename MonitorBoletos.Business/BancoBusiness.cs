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
    /// Centralizar as regras de negocio de <see cref="Banco"/>
    /// </summary>
    public class BancoBusiness : IDisposable
    {
        private BancoDAO dao = new BancoDAO();

        public Banco validaBanco(Banco bank)
        {
            var banco = new Banco();
            banco = bank;

            return banco;
        }

        public bool Salvar(Banco banco)
        {
            var result = dao.Inserir(banco);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public IList<Banco> ObterTodos()
        {
            return dao.obterTodos();
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

        public Banco ObterPorID(object objectID)
        {
            return dao.obterPorId((ObjectId)objectID);
        }



        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BancoBusiness() {
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
    }
}
