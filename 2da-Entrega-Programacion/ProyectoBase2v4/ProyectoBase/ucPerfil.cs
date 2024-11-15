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
    public partial class ucPerfil : UserControl
    {
        public ucPerfil()
        {
            InitializeComponent();
        }

        private string nom;
        private string ape;
        private string edad;


        public string CargarUsu {
            get => lblUsuario.Text;
            set => lblUsuario.Text = value;
        }
        public string CargarNom
        {
            get => nom;
            set
            {
                nom = value;
                aaa();
            }
        }
        public string CargarApe
        {
            get => ape;
            set
            {
                ape = value;
                aaa();
            }
        }
        public string CargarEdad
        {
            get => edad;
            set
            {
                edad = value;
                aaa();
            }
        }
        public string CargarMail {
            get => lblMail.Text;
            set => lblMail.Text = value;
        }
        public string CargarDesc {
            get => rtbDesc.Text;
            set => rtbDesc.Text = value;
        }

        private void aaa() {
            lblNomApeEdad.Text = $"{nom} {ape} - {edad} años";
        }
    }
}
