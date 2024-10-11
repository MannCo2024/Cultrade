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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Program.frmPerfil = new frmPerfil();
            Program.frmPerfil.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Program.pst.CargarPost();
            if (Program.con.CheckConn() == false)
            {
                pnlInvitado.Enabled = true;
                pnlInvitado.Visible = true;
            }
            
        }

        private void btnIS_Click(object sender, EventArgs e)
        {
            Program.frmLogin = new frmLogin();
            Program.frmLogin.ShowDialog();
            if (Program.con.CheckConn() == true)
            {
                pnlInvitado.Hide();
                pnlInvitado.Enabled = false;
                Program.pst.CargarPost();
                lblUsuario.Text = Program.userid;
                this.Focus();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Program.pst.CargarPost();
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
            Program.frmChats = new frmChats();
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
            //pnlFeed.Controls.Add(Program.con.CargarPost());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.pst.CargarPost();
        }

        private void LogoApp_Click(object sender, EventArgs e)
        {
            Program.frmPerfil = new frmPerfil();
            Program.frmPerfil.Show();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            Program.frmPerfil = new frmPerfil();
            Program.frmPerfil.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Program.frmPerfil = new frmPerfil();
            Program.frmPerfil.Show();
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            if (Program.con.CheckConn() == false)
            {
                pnlInvitado.Enabled = true;
                pnlInvitado.Visible = true;
                lblUsuario.Text = Program.userid;
            }
            Program.pst.CargarPost();
        }

        private void frmPrincipal_SizeChanged(object sender, EventArgs e)
        {
            if (Program.con.CheckConn() == false)
            {
                pnlInvitado.Enabled = true;
                pnlInvitado.Visible = true;
                lblUsuario.Text = Program.userid;
            }
            Program.pst.CargarPost();
        }
    }
}
