using System;
using System.Windows.Forms;

namespace ProyectoBase
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        Usuario u = new Usuario();

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuarioIS.Focus();
        }

        private void CrearCuenta_Click(object sender, EventArgs e)
        {
            string fechaNac = dtpFechaNac.Value.Year.ToString() + "-" + dtpFechaNac.Value.Month.ToString() + "-" + dtpFechaNac.Value.Day.ToString();
            u.CreoUsuario(txtUsuR.Text, txtNom.Text, txtApe.Text, fechaNac, cbGen.SelectedIndex.ToString(), txtTel.Text, txtMail.Text, txtPassR.Text);
            this.Refresh();
        }

        private void iniciarbtn_Click(object sender, EventArgs e) 
        {
            panelregistro.Visible = false;
            panelregistro.Enabled = false;
            txtUsuarioIS.Focus();
        }

        private void registrarsebtn_Click(object sender, EventArgs e)
        {
            panelregistro.Enabled = true;
            panelregistro.Visible = true;
            txtUsuR.Focus();
        }

        private void btnIS_Click(object sender, EventArgs e)
        {
            u.ValidoUsuario(txtUsuarioIS.Text, txtPassIS.Text);
        }
    }

}
