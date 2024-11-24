using ProyectoBase.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ProyectoBase
{
    public partial class ucPosts : UserControl
    {
        Conexion con = new Conexion();
        Usuario u = new Usuario();
        public ucPosts()
        {
            InitializeComponent();
        }
        private string post_id;
        private Boolean liked;
        private Boolean saved;
        Post pst = Program.pst;
        public string CargarID {
            get => post_id;
            set => post_id = value;
        }

        public string CargarImg 
        {
            get => guna2PictureBox1.ImageLocation;
            set => guna2PictureBox1.ImageLocation = value;
        }
        Image CargImg {
            get => guna2PictureBox1.Image;
            set => guna2PictureBox1.Image = value;
        }
        public string CargarTxt
        {
            get => txtTexto.Text;
            set => txtTexto.Text = value;
        }
        public string cargarUsu
        {
            get => lblUsu.Text;
            set => lblUsu.Text = value;
        }
        public string cargarLikes
        {
            get => lblLikes.Text;
            set => lblLikes.Text = value;
        }
        public Boolean userLiked
        {
            get => liked;
            set => liked = value;
        }
        public Boolean userSaved
        {
            get => saved;
            set => saved = value;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frmPerfil frmPerfil = new frmPerfil();
            u.cargarUsuario(cargarUsu, frmPerfil);
            pst.CargarPost("perfil", cargarUsu, frmPerfil);
            frmPerfil.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Panel2_DoubleClick(object sender, EventArgs e)    //Incredibly messy
        {
            frmPost frmPost = new frmPost();
            var ucPosts = new ucPosts();
            
            ucPosts.CargarID = this.CargarID;
            ucPosts.CargImg = guna2PictureBox1.Image;
            ucPosts.CargarTxt = txtTexto.Text;
            ucPosts.cargarUsu = lblUsu.Text;
            ucPosts.cargarLikes = lblLikes.Text;
            ucPosts.Dock = DockStyle.Fill;
            ucPosts.cargarLikes = pst.SelectPostLikes(CargarID);
            ucPosts.userLiked = pst.IsLiked(CargarID);
            ucPosts.userSaved = pst.isSaved(CargarID);

            DataTable talba = pst.selectUC(CargarID, null);

            string usu;
            string comentario;
            foreach (DataRow row in talba.Rows)
            {
                usu = (string)row["Usuario"];
                comentario = (string)row["Comentario"];

                var ucComentario = new ucComentario();
                ucComentario.cargarNombre = usu;
                ucComentario.cargarComentario = comentario;
                ucComentario.Width = frmPost.flowLayoutPanel1.ClientSize.Width;
                frmPost.flowLayoutPanel1.Controls.Add(ucComentario);
            }

            frmPost.splitContainer2.Panel1.Controls.Add(ucPosts);
            frmPost.Show();
        }

        private void ucPosts_Load(object sender, EventArgs e)
        {
            actLikes();
        }

        private void txtTexto_Load(object sender, EventArgs e)
        {
            int altura = txtTexto.Font.Height;
            int padding = 5;

            int lineas = txtTexto.Lines.Length;
            
            txtTexto.Height = (altura * (lineas + 1)) + padding;
            Height = Height + txtTexto.Height;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)      //Click en comentar
        {
            if (con.CheckConn() == true) { 
                frmComentar com = new frmComentar(CargarID);
                com.ShowDialog();
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            pst.LikePost(post_id);
            liked = pst.IsLiked(post_id);
            actLikes();
        }

        private void actLikes() {
            lblLikes.Text = pst.SelectPostLikes(post_id);
            if (liked)
            {
                guna2ImageButton2.Image = Resources.corazonhover;
            }
            else
            {
                guna2ImageButton2.Image = Resources.corazon;
            }
            if (saved)
            {
                guna2ImageButton3.Image = Resources.guardarhover;
            }
            else
            {
                guna2ImageButton3.Image = Resources.guardar;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmPerfil frmPerfil = new frmPerfil();
            u.cargarUsuario(cargarUsu, frmPerfil);
            pst.CargarPost("perfil", cargarUsu, frmPerfil);
            frmPerfil.Show();
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            pst.guardarPost(post_id);
            saved = pst.isSaved(post_id);
            actLikes();
        }
    }
    
}
