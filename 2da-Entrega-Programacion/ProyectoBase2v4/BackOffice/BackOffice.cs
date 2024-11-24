using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOffice
{
    public partial class BackOffice : Form
    {
        public BackOffice()
        {
            InitializeComponent();
        }

        private void creacionCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolCre solCre = new SolCre();
            solCre.TopLevel = false;
            solCre.FormBorderStyle = FormBorderStyle.None;
            solCre.Dock = DockStyle.Fill;
            panel1.Controls.Add(solCre);
            solCre.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.Show();
        }
    }
}
