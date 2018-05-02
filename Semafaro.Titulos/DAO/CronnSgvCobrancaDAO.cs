using Dapper;
using Semafaro.Titulos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Semafaro.Titulos.DAO
{
    public class CronnSgvCobrancaDAO
    {
        /// <summary>
        /// Consulta o Cronn
        /// </summary>
        /// <param name="nossoNumero"></param>
        /// <returns><see cref="CronnSgvCobranca"/></returns>
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

        /// <summary>
        /// Metodo para verificar os numeros que não foram encontrados dentro do banco de dados do Cronn
        /// </summary>
        /// <param name="ListNossoNumero"></param>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        public  IEnumerable<string> NumeroNaoEncontrado(IEnumerable<string> ListNossoNumero)
        {
            var cronnSgvCobrancas = ObterTodasCobrancas(ListNossoNumero);
            var nossoNumero = cronnSgvCobrancas
                .Select(x => x.BoletoNossoNro);

            var nossoNumeroNaoEncontrado = ListNossoNumero.Except(nossoNumero);

            return nossoNumeroNaoEncontrado;
        }

        /// <summary>
        /// Quebra uma List em varias dependendo do paramentro de entrada
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="totalPartitions"></param>
        /// <returns></returns>
        public static List<T>[] Partition<T>(List<T> list, int totalPartitions)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (totalPartitions < 1)
                throw new ArgumentOutOfRangeException("totalPartitions");

            List<T>[] partitions = new List<T>[(int)Math.Ceiling(list.Count / (double)totalPartitions)];

            //int maxSize = (int)Math.Ceiling(list.Count / (double)totalPartitions);


            int maxSize = totalPartitions;
            int k = 0;

            for (int i = 0; i < partitions.Length; i++)
            {
                partitions[i] = new List<T>();
                for (int j = k; j < k + maxSize; j++)
                {
                    if (j >= list.Count)
                        break;
                    partitions[i].Add(list[j]);
                }
                k += maxSize;
            }

            return partitions;
        }

        /// <summary>
        /// Consulta o Cronn e retorna os titulos que estiverem na lista
        /// </summary>
        /// <param name="ListNossoNumero"></param>
        /// <returns></returns>
        public List<CronnSgvCobranca> ObterTodasCobrancas(IEnumerable<string> ListNossoNumero)
        {
            var cronnSgvCobrancas = new List<CronnSgvCobranca>();
            try
            {
                if (ListNossoNumero.Count() <= 2000)
                {

                    using (var conn = new SqlConnection(StringDeConexao.stringConexaoCronn_PRD))
                    {
                        var result = conn.Query<CronnSgvCobranca>("select * from [Cronn_PRD].[Sgv].[Cobranca] where BoletoNossoNro in @NossoNumero"
                            , new { NossoNumero = ListNossoNumero });

                        foreach (var item in result)
                        {
                            cronnSgvCobrancas.Add(item);
                        }
                    }
                }
                else
                {
                    var  lista = new List<string>();

                    foreach (var item in ListNossoNumero)
                    {
                        lista.Add(item);
                    }

                    var resultado = Partition(lista, 2000);

                    using (var conn = new SqlConnection(StringDeConexao.stringConexaoCronn_PRD))
                    {
                        foreach (var item in resultado)
                        {
                            var result = conn.Query<CronnSgvCobranca>("select * from [Cronn_PRD].[Sgv].[Cobranca] where BoletoNossoNro in @NossoNumero"
                            , new { NossoNumero = item });

                            foreach (var ocorrencia in result)
                            {
                                cronnSgvCobrancas.Add(ocorrencia);
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return cronnSgvCobrancas;
        }

        /// <summary>
        /// Consulta o Cronn e retorna os titulos que estiverem na lista
        /// </summary>
        /// <param name="ListNossoNumero"></param>
        /// <returns></returns>
        public List<CronnSgvCobranca> ObterTodasCobrancas(List<string> ListNossoNumero)
        {
            var cronnSgvCobrancas = new List<CronnSgvCobranca>();
            try
            {
                if (ListNossoNumero.Count() <= 2000)
                {

                    using (var conn = new SqlConnection(StringDeConexao.stringConexaoCronn_PRD))
                    {
                        var result = conn.Query<CronnSgvCobranca>("select * from [Cronn_PRD].[Sgv].[Cobranca] where BoletoNossoNro in @NossoNumero"
                            , new { NossoNumero = ListNossoNumero });

                        foreach (var item in result)
                        {
                            cronnSgvCobrancas.Add(item);
                        }
                    }
                }
                else
                {
                    var resultado = Partition(ListNossoNumero, 2000);

                    using (var conn = new SqlConnection(StringDeConexao.stringConexaoCronn_PRD))
                    {
                        foreach (var item in resultado)
                        {
                            var result = conn.Query<CronnSgvCobranca>("select * from [Cronn_PRD].[Sgv].[Cobranca] where BoletoNossoNro in @NossoNumero"
                            , new { NossoNumero = item });

                            foreach (var ocorrencia in result)
                            {
                                cronnSgvCobrancas.Add(ocorrencia);
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return cronnSgvCobrancas;
        }
    }
}