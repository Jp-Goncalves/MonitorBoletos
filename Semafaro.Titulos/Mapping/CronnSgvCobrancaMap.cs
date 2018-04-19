using FluentNHibernate.Automapping;
using FluentNHibernate.Mapping;
using Semafaro.Titulos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafaro.Titulos.Mapping
{
    public class CronnSgvCobrancaMap : ClassMap<CronnSgvCobranca>
    {
        public CronnSgvCobrancaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.DataCobranca);
            Map(x => x.ValorPagto);
            Map(x => x.ValorTotal);
            Map(x => x.BoletoLinhaDig);
            Map(x => x.BoletoValor);
            Map(x => x.BoletoNossoNro).Not.Nullable();
            Map(x => x.Dac);
            Map(x => x.BoletoCodBarras);
            Map(x => x.CustoBoleto);
            Map(x => x.TipoCobranca);
            Map(x => x.Situacao);
            Map(x => x.DataVencimento);
            Map(x => x.DataPagamento);
            Map(x => x.Juros);
            Map(x => x.Multa);
            Map(x => x.OutrosAcrescimos);
            Map(x => x.ValorTitulo);
            Map(x => x.NumeroDocumento);
            Map(x => x.Parcela);
            Map(x => x.DataImpressao);
            Map(x => x.UsuarioImpressao);
            Map(x => x.CobrancaRede);
            Map(x => x.LimiteUnificado);
            Map(x => x.EmailEnviado);
            Map(x => x.IniciativaRegeracao);
            Map(x => x.DataProcessamento);
            Map(x => x.IdCliente);
            Map(x => x.IdCobrancaOrigem);
            Map(x => x.IdNegociacaoCobranca);
            Map(x => x.IdConvenioBancario);
            Map(x => x.IdParametroCobranca);
            Map(x => x.IdTerminal);
            Map(x => x.IdRede);
            Map(x => x.IdResponsavelLimite);
            Map(x => x.IdEmpresa);
            Map(x => x.DataInclusao);
            Map(x => x.DataAlteracao);

            Table("Cobranca");
        }
    }
}
