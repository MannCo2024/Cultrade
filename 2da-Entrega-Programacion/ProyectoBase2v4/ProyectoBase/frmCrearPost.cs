using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ProyectoBase
{
    public partial class frmCrearPost : Form
    {
        public frmCrearPost()
        {
            InitializeComponent();
            btnBorrarArchivo.Enabled = false; // Inicialmente deshabilitado
            
            guna2TextBox2.ReadOnly = true; //Textbox2 de la vista previa solo lectura
            txtTexto.TextChanged += guna2TextBox1_TextChanged;
        }
        public string nuevoNomArch;
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulodesc_Click(object sender, EventArgs e)
        {

        }

        private void BtnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                

                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    guna2Panel1.Controls.Add(pictureBox1);
                    pictureBox1.Dock = DockStyle.Fill;

                    // Cargar la imagen seleccionada en el PictureBox
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    btnBorrarArchivo.Enabled = true; //Habilitar boton BorrarArchivo
                    btnPostear.Enabled = true;

                    //GUARDAR IMAGEN EN LA CARPETA
                    string carpetaDestino = Path.Combine(Application.StartupPath, "Resources", "MM");
                    string nomArch = Path.GetFileName(openFileDialog.FileName);
                    string ext = Path.GetExtension(nomArch);
                    
                    string destino;
                    do
                    {
                        nuevoNomArch = "img_" + Program.rnd.Next(0, 99999) + ext;
                        destino = Path.Combine(carpetaDestino, nuevoNomArch);
                    } while (File.Exists(destino));


                    // Guardar la imagen en la carpeta especificada
                    File.Copy(Path.GetFullPath(openFileDialog.FileName),destino);         
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void btnBorrarArchivo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar el archivo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                pictureBox1.Image = null;
                btnBorrarArchivo.Enabled = false; //Deshabilitar boton BorrarArchivo
                btnPostear.Enabled = false;

            }
        }

        private void btnPostear_Click(object sender, EventArgs e)
        {
            string archivo = nuevoNomArch;
            Program.pst.crearPost(txtTexto.Text, archivo);
            Program.pst.CargarPost("principal", null, null);
            Program.frmCrearPost.Dispose();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.Text = txtTexto.Text;
        }

        private void frmCrearPost_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

