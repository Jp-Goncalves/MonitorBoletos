using MonitorBoletos.Business;
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
    public partial class FrmListaOcorrencia : Form
    {
        public FrmListaOcorrencia()
        {
            InitializeComponent();
        }

        private void FrmListaOcorrencia_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new OcorrenciaCobrancaBusiness().ObterTodos();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            dataGridView1.Columns["NossoNumero"].Visible = true;
            dataGridView1.Columns["DataOcorrencia"].Visible = true;
            dataGridView1.Columns["ValorPago"].Visible = true;
            dataGridView1.Columns["DadosOcorrencia"].Visible = true;
        }
    }
}
