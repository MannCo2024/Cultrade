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
    public partial class ucMensaje : UserControl
    {
        public ucMensaje()
        {
            InitializeComponent();
        }
        string usu2;
        string fecha;
        public string cargarUsu1 
        { //Quien envía el mensaje
            get => lblUsu.Text;
            set => lblUsu.Text = value;
        }

        public string cargarUsu2
        { //Quien recive el mensaje (por las dudas)
            get => usu2;
            set => usu2 = value;
        }

        public string cargarMsg 
        {
            get => rtbDesc.Text;
            set
            {
                rtbDesc.Text = value;
                rtbDesc.Enabled = false;
                this.Height = (rtbDesc.Lines.Length * 13) + this.Height;
            }
        }

        public string cargarFecha
        {
            get => fecha;
            set => fecha = value;
        }

        private void fuiyo() {
            if (lblUsu.Text.Equals(Program.userid))
            {
                //Dock = DockStyle.Right;
            }
            else 
            {
                //Dock = DockStyle.Left;
            }
        }

        private void rtbDesc_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
