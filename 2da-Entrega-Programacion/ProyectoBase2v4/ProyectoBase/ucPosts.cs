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

namespace ProyectoBase
{
    public partial class ucPosts : UserControl
    {
        Conexion con = new Conexion();
        public ucPosts()
        {
            InitializeComponent();
        }
        private string post_id;
        private Boolean liked;
        Post pst = new Post();
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


        private void lblPostLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //CLICK EN LA PFP
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            //CLICK EN LA IMAGEN
        }

        private void guna2Panel2_DoubleClick(object sender, EventArgs e)    //Incredibly messy
        {
            var ucPosts = new ucPosts();
            ucPosts.CargImg = guna2PictureBox1.Image;
            ucPosts.CargarTxt = txtTexto.Text;
            ucPosts.cargarUsu = lblUsu.Text;
            ucPosts.cargarLikes = lblLikes.Text;
            ucPosts.Dock = DockStyle.Fill;
            Program.frmPost = new frmPost();
            Program.frmPost.splitContainer2.Panel1.Controls.Add(ucPosts);
            Program.frmPost.Show();
        }

        private void ucPosts_Load(object sender, EventArgs e)
        {
            if (liked)
            {
                guna2ImageButton2.Image = Resources.corazonhover;
            }
            else 
            {
                guna2ImageButton2.Image = Resources.corazon;
            }
        }

        private void txtTexto_Load(object sender, EventArgs e)
        {
            int altura = txtTexto.Font.Height;
            int padding = 5;

            int lineas = txtTexto.Lines.Length;
            
            txtTexto.Height = (altura * (lineas + 1)) + padding;
            this.Height = this.Height + txtTexto.Height;
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

        }
    }
    
}
