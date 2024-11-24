using System;
using System.Data;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoBase
{
    public partial class frmChats : Form
    {
        public frmChats()
        {
            InitializeComponent();
        }
        Conexion con = Program.con;
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmChats_Load(object sender, EventArgs e)
        {
            cargaChats();
        }

        public void cargaChats() {
            DataTable dt = new DataTable();
            ADODB.Recordset rs;
            String sql;

            sql = "CALL ultimoMensaje('(Origen IS NOT NULL AND Destinatario = NombreUsuario()) OR (Origen = NombreUsuario() AND Destinatario IS NOT NULL)')";

            rs = con.Ejecutar(sql);

            for (int i = 0; i < rs.Fields.Count; i++)
            {
                dt.Columns.Add(rs.Fields[i].Name, typeof(string));
            }

            while (!rs.EOF)
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < rs.Fields.Count; i++)
                {
                    row[i] = rs.Fields[i].Value;
                }
                dt.Rows.Add(row);
                rs.MoveNext();
            }

            string origen;
            string destino;
            string mensaje;

            foreach (DataRow row in dt.Rows)
            {
                origen = (string)row["Origen"];
                destino = (string)row["Destinatario"];
                mensaje = (string)row["Mensaje"];

                var ucChat = new ucChat();
                if (destino.Equals(Program.userid))
                {
                    ucChat.cargarUsu = origen;
                }
                else
                {
                    ucChat.cargarUsu = destino;
                }

                ucChat.ultMsg = mensaje;
                ucChat.Width = flpChats.ClientSize.Width;
                flpChats.Controls.Add(ucChat);
            }
        }
    }
}
