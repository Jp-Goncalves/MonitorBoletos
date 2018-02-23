using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Business
{
    public class LicencaBusiness
    {
        public bool validarLicenca(Licenca licenca)
        {
            if (licenca is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
