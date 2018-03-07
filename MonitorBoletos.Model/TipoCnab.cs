using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Model
{
    /// <summary>
    /// Tipos de CNAB
    /// </summary>
    public enum TipoCnabEnum
    {
        [Description("CNAB 400")]
        CNAB400,

        [Description("CNAB 240")]
        CNAB240
    }
}
