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
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnIS_Click(object sender, EventArgs e)
        {

        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            lblIS.Location = new Point((this.ClientSize.Width - lblIS.Width) / 2, 8);
            txtUsuarioIS.Location = new Point((this.ClientSize.Width - txtUsuarioIS.Width) / 2, 47);
            txtPassIS.Location = new Point((this.ClientSize.Width - txtPassIS.Width) / 2, 84);
        }
    }
}
