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
        DataTable testm = Program.testm;

        Recordset rs;
        public SolCre()
        {
            InitializeComponent();
        }

        private void SolCre_Load(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 6);
        }

        private void cargarDatos() {
            testm = cls.selectInfo(cbOpcion.SelectedIndex);
            dgvSolicitudes.DataSource = testm;
            dgvSolicitudes.Columns["pass"].Visible = false;
            dgvSolicitudes.Refresh();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void SolCre_Resize(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 6);
        }

        private void SolCre_SizeChanged(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 6);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count > 0) {
                if (dgvSolicitudes.SelectedRows[0].Cells["Estado"].Value.Equals("Pendiente")) {
                    //MessageBox.Show(dgvSolicitudes.SelectedRows[0].Cells[0].Value.ToString());
                    cls.Ejecutar($"CALL aceptarSolicitudReg('{dgvSolicitudes.SelectedRows[0].Cells[0].Value}');");
                    cargarDatos();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count > 0)
            {
                if (dgvSolicitudes.SelectedRows[0].Cells["Estado"].Value.Equals("Pendiente"))
                {
                    //MessageBox.Show(dgvSolicitudes.SelectedRows[0].Cells[0].Value.ToString());
                    cls.Ejecutar($"CALL rechazarSolicitudReg('{dgvSolicitudes.SelectedRows[0].Cells[0].Value}');");
                    cargarDatos();
                }
            }
        }
    }
}
