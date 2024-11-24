using System;
using System.Drawing;
using System.Windows.Forms;


namespace ProyectoBase
{
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
        }

        Post pst = new Post();
        Conexion con = new Conexion();
        Usuario u = new Usuario();

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            pst.CargarPost("principal", null, null);
            if (con.CheckConn() == false)
            {
                pnlInvitado.Enabled = true;
                pnlInvitado.Visible = true;
            }
            
            
        }

        private void btnIS_Click(object sender, EventArgs e)
        {
            Program.frmLogin = new frmLogin();
            Program.frmLogin.ShowDialog();

            if (con.CheckConn() == true)
            {
                pnlInvitado.Hide();
                pnlInvitado.Enabled = false;
                lblUsuario.Text = Program.userid;
                label2.Text = Program.username;
            }
            pst.CargarPost("principal", null, null);
            Focus();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            pst.CargarPost("principal", null, null);
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            Program.frmNotificaciones = new Notificaciones();
            Program.frmNotificaciones.Show();
        }

        private void btnComunidades_Click(object sender, EventArgs e)
        {
            Program.frmComunidades = new Comunidades();
            Program.frmComunidades.Show();
        }

        private void btnChats_Click(object sender, EventArgs e)
        {
            Program.frmChats = Program.FrmChats;
            Program.frmChats.Show();
        }

        private void btnEnevtos_Click(object sender, EventArgs e)
        {
            Program.frmEvento = new Evento();
            Program.frmEvento.Show();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            Program.frmCrearPost = new frmCrearPost();
            Program.frmCrearPost.Show();
        }

        private void LogoApp_Click(object sender, EventArgs e)
        {
            if (!Program.userid.Equals("Invitado")) {
                frmPerfil frmPerfil = new frmPerfil();
                u.cargarUsuario(Program.userid, frmPerfil);
                pst.CargarPost("perfil", Program.userid, frmPerfil);
                frmPerfil.Show();
            }
            
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            if (!Program.userid.Equals("Invitado"))
            {
                frmPerfil frmPerfil = new frmPerfil();
                u.cargarUsuario(Program.userid, frmPerfil);
                pst.CargarPost("perfil", Program.userid, frmPerfil);
                frmPerfil.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmPerfil frmPerfil = new frmPerfil();
            u.cargarUsuario(Program.userid, frmPerfil);
            frmPerfil.Show();
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            if (con.CheckConn() == false)
            {
                pnlInvitado.Enabled = true;
                pnlInvitado.Visible = true;
                lblUsuario.Text = Program.userid;
            }
            pst.CargarPost("principal", null, null);
        }

        private void frmPrincipal_SizeChanged(object sender, EventArgs e)
        {
            if (con.CheckConn() == false)
            {
                pnlInvitado.Enabled = true;
                pnlInvitado.Visible = true;
                lblUsuario.Text = Program.userid;
            }
            pst.CargarPost("principal", null, null );
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
        }
    }
}
