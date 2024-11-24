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
    public partial class frmComentar : Form
    {
        public string post_id;
        public frmComentar(string post)
        {
            InitializeComponent();
            post_id = post;
        }

        private void btnPostear_Click(object sender, EventArgs e)
        {
            if (!txtTexto.Text.Equals(""))
            {
                Program.pst.CrearCom(txtTexto.Text, post_id);
                this.Dispose();
            }
        }
    }
}

