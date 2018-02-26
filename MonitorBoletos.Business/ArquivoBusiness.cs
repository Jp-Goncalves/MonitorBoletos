using MonitorBoletos.DAO;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Banco converter(string arquivo)
        {
            //Regex para ler o Header do arquivo
            var array = Regex.Split(arquivo,
                @"(^\d{1}\d{1}[A-Z]{7}\d{2}[\s A-Z\s]{15}\d{20}[\s A-Z\s]{30}\d{3}[\s A-Z \s]{15}\d{6}\d{8}\d{5}.{266}\d{6}.{9}\d{6})", RegexOptions.Compiled);

            var banco = new Banco();

            banco.Nome = array[8].ToString();

            return banco;
        }

        public List<Banco> validarTitulo(string arquivo)
        {
            if (File.Exists(arquivo))
            {
                var lista = new List<Banco>();
                using (var leitor = new StreamReader(arquivo))
                {
                    leitor.ReadLine();
                }
                return lista;
            }
        }



        public void validarArquivoRetorno(string file)
        {
            //TODO : Validar a Empresa, carteira e banco do arquivo

            //Regex para ler o Header do arquivo
            var leitorTituloCobranca = Regex.Split(file,
                @"(^\d{1}\d{1}[A-Z]{7}\d{2}[\s A-Z\s]{15}\d{20}[\s A-Z\s]{30}\d{3}[\s A-Z \s]{15}\d{6}\d{8}\d{5}.{266}\d{6}.{9}\d{6})", RegexOptions.Compiled);
            
            //valida o banco que está no arquivo
            var banco = new Banco();

            banco.Numero = leitorTituloCobranca[7].ToString();
            banco.Nome = leitorTituloCobranca[8].ToString().ToUpper();

            var bank = new BancoBusiness();
            bank.validaBanco(banco);


            //Regex para ler as  cobranças do arquivo
            var leitorCobranca = Regex.Split(file,
                @"(^.{1}.{2}.{14}.{3}.{17}.{25}.{8}.{12}.{10}.{12}.{1}.{2}.{1}.{2}.{6}.{10}.{20}.{6}.{13}.{3}.{5}.{2}.{13}
                .{13}.{13}.{13}.{13}.{13}.{13}.{13}.{13}.{2}.{1}.{6}.{3}.{10}.{4}.{10}.{40}.{2}.{10}.{14}.{6}$)", RegexOptions.Compiled);

            //Regex para ler a Carteira, Agencia e Conta Corrente
            var info = leitorCobranca[4].ToString();
            var dados = Regex.Split(info, @"^.{1}.{2}.{5}.{8}$", RegexOptions.Compiled);


            //valida a carteira
            var carteira = new Carteira();
            carteira.Numero = Convert.ToInt64(dados[0]);

            var card = new CarteiraBusiness();
            card.validarCarteira(carteira);


            //valida a empresa que está no arquivo
            var empresa = new Empresa();
            empresa.Cnpj = leitorCobranca[2].ToString();
            empresa.Nome = leitorTituloCobranca[6].ToString();

            var company = new EmpresaBusiness();
            company.validaEmpresa(empresa);

            //valida a Conta Corrente
            var contacorrente = new ContaCorrente();
            contacorrente.Numero = dados[3].ToString();
            contacorrente.Banco = banco;
            contacorrente.Empresa = empresa;

            var conta = new ContaCorrenteBusiness();
            conta.validarContaCorrente(contacorrente);


            //Valida o arquivo de licença
            var licenca = new Licenca();
            licenca.Banco = banco;
            licenca.Carteira = carteira;

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
