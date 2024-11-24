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
    public partial class ucChat : UserControl
    {
        public ucChat()
        {
            InitializeComponent();
        }
        frmChats frmChats = Program.FrmChats;


        public string cargarUsu {
            get => lblUsuario.Text;
            set => lblUsuario.Text = value;
        }

        public string ultMsg {
            set => rtxtMsg.Text = value;
        }

        private void rtxtMsg_Click(object sender, EventArgs e)
        {
            try
            {
                frmChats.pnl1.Controls.Clear();
            }
            catch { 
            
            }

            blfChat blfChat = new blfChat();
            blfChat.TopLevel = false;
            blfChat.Dock = DockStyle.Fill;
            blfChat.cargarUsu = cargarUsu;
            frmChats.pnl1.Controls.Add(blfChat);
            blfChat.Show();
        }
    }
}
