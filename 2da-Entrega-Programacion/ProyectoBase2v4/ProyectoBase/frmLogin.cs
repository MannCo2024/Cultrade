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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void CrearCuenta_Click(object sender, EventArgs e)
        {
            //ESTA OPCION NO ESTA FUNCIONANDO, PARA LA 3RA ENTREGA ESTA JUNTO AL BACKOFFICE

            Usuario u = new Usuario();
            String test = u.ObtenerPais();
            MessageBox.Show(test);

            
            string fechaNac = dtpFechaNac.Value.Year.ToString() + "-" + dtpFechaNac.Value.Month.ToString() + "-" + dtpFechaNac.Value.Day.ToString();
            MessageBox.Show(fechaNac);
            //VALOR DE FECHA NACIMIENTO CAMBIADO PARA SQL dtpFechaNac.Value.Year.ToString() + "-" + dtpFechaNac.Value.Month.ToString() + "-" + dtpFechaNac.Value.Day.ToString()
        }

        private void iniciarbtn_Click(object sender, EventArgs e) 
        {
            panelregistro.Visible = false;
            panelregistro.Enabled = false;
        }

        private void registrarsebtn_Click(object sender, EventArgs e)
        {
            panelregistro.Enabled = true;
            panelregistro.Visible = true;
        }

        private void btnIS_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            u.ValidoUsuario(txtUsuarioIS.Text, txtPassIS.Text);

        }
    }

}
