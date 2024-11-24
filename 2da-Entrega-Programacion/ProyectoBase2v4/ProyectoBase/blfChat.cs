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
    public partial class blfChat : Form
    {

        public blfChat()
        {
            InitializeComponent();
        }
        string usu1;
        string usu2;
        Conexion con = Program.con;
        public string cargarUsu {
            get => usu2;
            set 
            { 
                usu2 = value;
                cargaMensajes(cargarUsu);
            }
        }

        public void cargaMensajes(string usu)
        {
            DataTable dt = new DataTable();
            ADODB.Recordset rs;
            String sql;

            flpMensajes.Controls.Clear();

            sql = $"SELECT * FROM verMensajes WHERE (Origen = '{usu}' AND Destinatario = NombreUsuario()) OR (Origen = NombreUsuario() AND Destinatario = '{usu}') ORDER BY FechaEnvio DESC";
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
            string fecha;

            foreach (DataRow row in dt.Rows)
            {
                origen = (string)row["Origen"];
                destino = (string)row["Destinatario"];
                mensaje = (string)row["Mensaje"];
                fecha = (string)row["FechaEnvio"];

                if (!destino.Equals(Program.userid))
                {
                    usu1 = destino;
                }

                var ucMensaje = new ucMensaje();
                ucMensaje.cargarUsu1 = origen;
                ucMensaje.cargarUsu2 = destino;
                ucMensaje.cargarMsg = mensaje;
                ucMensaje.cargarFecha = fecha;
                flpMensajes.Controls.Add(ucMensaje);
            }

            if (string.IsNullOrEmpty(usu1))
            {
                usu1 = usu;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim().Length != 0)
            {
                con.Ejecutar($"CALL enviarMensajeP('{usu1}', '{richTextBox1.Text}')");
                richTextBox1.Text = "";
                richTextBox1.Focus();
                cargaMensajes(cargarUsu);
            }
        }
    }
}
