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
            if (CargarUsu == Program.userid) {
                btnAAmigo.Visible = false;
                btnAAmigo.Enabled = false;
                btnEMsg.Visible = false;
                btnEMsg.Enabled = false;
                btnBlock.Visible = false;
                btnBlock.Enabled = false;

                btnGuardados.Visible = true;
                btnGuardados.Enabled = true;
            }
            if (Program.userid.Equals("Invitado")) {
                btnAAmigo.Visible = false;
                btnAAmigo.Enabled = false;
                btnEMsg.Visible = false;
                btnEMsg.Enabled = false;
                btnBlock.Visible = false;
                btnBlock.Enabled = false;

                btnGuardados.Visible = false;
                btnGuardados.Enabled = false;
            }

        }

        private void btnGuardados_Click(object sender, EventArgs e)
        {
            frmGuardados frmGuardados = new frmGuardados();
            frmGuardados.Show();
        }

        private void btnEMsg_Click(object sender, EventArgs e)
        {
            frmChats frmChats = Program.FrmChats;

            foreach (Control chatControl in frmChats.flpChats.Controls)
            {
                if (chatControl is ucChat existingChat && existingChat.cargarUsu == this.CargarUsu)
                {
                    frmChats.Show();
                    frmChats.BringToFront();
                    return;
                }
            }

            
            var newChat = new ucChat
            {
                cargarUsu = this.CargarUsu,
                ultMsg = "",
                Width = frmChats.flpChats.ClientSize.Width 
            };

            frmChats.flpChats.Controls.Add(newChat);

            frmChats.Show();
            frmChats.BringToFront();

            try
            {
                frmChats.pnl1.Controls.Clear();
            }
            catch
            {
                
            }
            var chatWindow = new blfChat
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                cargarUsu = this.CargarUsu
            };

            frmChats.pnl1.Controls.Add(chatWindow);
            chatWindow.Show();
        }
    }
}
