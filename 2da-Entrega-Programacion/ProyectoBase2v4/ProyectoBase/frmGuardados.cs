using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoBase
{
    public partial class frmGuardados : Form
    {
        public frmGuardados()
        {
            InitializeComponent();
        }
        Conexion con = Program.con;
        Post pst = Program.pst;

        private void frmGuardados_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            ADODB.Recordset rs;
            String sql;

            sql = "select * from verguardados where GUsuario = NombreUsuario();";

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

            string usu;
            string txt;
            string img;
            string id;
            string likes;
            Boolean liked;

            foreach (DataRow row in dt.Rows)
            {
                usu = (string)row["Usuario"];
                txt = (string)row["Texto"];
                img = (string)row["Imagen"];
                id = (string)row["Post"];
                likes = pst.SelectPostLikes(id);
                liked = pst.IsLiked(id);

                var ucPosts = new ucPosts();
                ucPosts.cargarUsu = usu;
                ucPosts.CargarTxt = txt;
                ucPosts.CargarImg = Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "MM") + @"\" + img;
                ucPosts.CargarID = id;
                ucPosts.cargarLikes = likes;
                ucPosts.userLiked = liked;
                ucPosts.Width = flowLayoutPanel1.ClientSize.Width;
                flowLayoutPanel1.Controls.Add(ucPosts);
            }

        }
    }
}
