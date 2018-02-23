using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitorBoletos.DAO;
using MonitorBoletos.Model;

namespace MonitorBoletos.Business
{
    public class EmpresaBusiness
    {
        public Empresa validaEmpresa(Empresa company)
        {
            var empresa = new Empresa();
            empresa = company;

            if (empresa.Cnpj is null)
            {
                var inserirEmpresa = new EmpresaDAO();
                inserirEmpresa.InserirEmpresa(empresa);
            }
            else
            {
                var atualizarEmpresa = new EmpresaDAO();
                atualizarEmpresa.atualizarEmpresa(empresa);
            }

            return empresa;
        }
    }
}
