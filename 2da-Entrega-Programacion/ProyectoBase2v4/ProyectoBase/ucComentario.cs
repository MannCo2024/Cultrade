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
    public partial class ucComentario : UserControl
    {
        public ucComentario()
        {
            InitializeComponent();
        }

        public String cargarComentario {
            get => txtComentario.Text;
            set => txtComentario.Text = value;
        }
        public String cargarNombre
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public Image cargarPFP
        {
            get => pbPFP.Image;
            set => pbPFP.Image = value;
        }
    }
}
