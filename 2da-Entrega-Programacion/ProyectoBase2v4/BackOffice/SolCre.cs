using ADODB;
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
    public partial class SolCre : Form
    {
        Clase cls = Program.cls;
        Recordset rs;
        public SolCre()
        {
            InitializeComponent();
            dgvSolicitudes.DataSource = rs;
        }

        private void SolCre_Load(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 6);
        }

        private void cargarDatos() {
            rs = cls.Ejecutar("");
            dgvSolicitudes.Refresh();
        }
    }
}
