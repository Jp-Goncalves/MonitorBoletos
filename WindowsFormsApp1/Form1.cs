using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String arquivo { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = ".RET";
            openFile.Title = "Selecio o arquivo";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtEnviar.Text = openFile.FileName;
            }
                arquivo = openFile.FileName;
            var validarArquivo = new MonitorBoletos.Business.ArquivoBusiness();
            validarArquivo.validarArquivo(arquivo);
        }
    }
}
