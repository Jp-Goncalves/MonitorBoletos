using MonitorBoletos.Business;
using MonitorBoletos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorBoletos.DesktopView
{
    public partial class FrmCadastroBanco : Form
    {
        public FrmCadastroBanco()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var banco = new Banco();

            banco.Nome = tbNomeBanco.Text;
            banco.Numero = int.Parse(tbNumeroBanco.Text);

            using (var bc = new BancoBusiness())
            {
                bc.Salvar(banco);
            }

        }
    }
}
