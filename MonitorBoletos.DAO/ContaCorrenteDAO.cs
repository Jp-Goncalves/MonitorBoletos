using LiteDB;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.DAO
{
    /// <summary>
    /// Centralizar o acesso a dados do modelo <see cref="ContaCorrente"/>
    /// </summary>
    public  class ContaCorrenteDAO
    {
        #region Fields
        /// <summary>
        /// Obter a string de conexão que vai ser utilizada
        /// </summary>
        private string Connection = ConexaoDAO.GetConnectionString();

        /// <summary>
        /// Nome da tabela no db para ser utilizada no LiteDB
        /// </summary>
        private readonly string _tableName = "contacorrente";
        #endregion

        #region Public Methods
        /// <summary>
        /// Inserir uma conta-corrente no banco de dados
        /// </summary>
        /// <param name="conta"></param>
        public void InserirContaCorrente(ContaCorrente conta)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var contacorrente = db.GetCollection<ContaCorrente>(_tableName);

                contacorrente.Insert(conta);
            }
        }

        /// <summary>
        /// Buscar uma conta-corrente pelo seu numero
        /// </summary>
        /// <param name="numero">numero a ser pesquisado</param>
        /// <returns>se existir uma <see cref="ContaCorrente"/>, se não existir retornará null</returns>
        public ContaCorrente getByNumero(ContaCorrente numero)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var contacorrente = db.GetCollection<ContaCorrente>(_tableName);

                var result = contacorrente.FindById(numero.Numero);

                return result;
            }
        }

        /// <summary>
        /// Atualiza uma conta-corrente
        /// </summary>
        /// <param name="conta">conta a ser atualizada</param>
        public void atualizarContaCorrente(ContaCorrente conta)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var banco = db.GetCollection<ContaCorrente>(_tableName);

                banco.Update(conta);
            }
        }

        /// <summary>
        /// Deletar uma conta-corrente do banco
        /// </summary>
        /// <param name="conta">conta a ser excluida</param>
        public void deletarContaCorrente(string conta)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var contacorrente1 = db.GetCollection<ContaCorrente>(_tableName);

                contacorrente1.Delete(conta);
            }
        }
        #endregion
    }
}
