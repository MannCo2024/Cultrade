using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ProyectoBase
{
    class Post
    {

        public DataTable selectUserPosts(string usu) {

            DataTable dt = new DataTable();
            ADODB.Recordset rs;
            String sql;
            sql = "select * from verposts where Usuario " + usu;    // AL CREAR EL VIEW VERPOSTS, EL USURAIO YA NO TIENE QUE UTILIZAR PERMISOS EN TODAS LAS TABLAS, SOLAMENTE EN EL VIEW, LO MISMO VA PARA LA CREACIÓN DE POSTS CREO
            if (!Program.con.CheckConn())
            {
                Program.con.OpConn("PostLoader", "Xkjjk)923=!1f");
            }
            rs = Program.cn.Execute(sql, out Program.dump);

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
            return dt;
        }

        public string SelectPostLikes(string post)
        {
            string Likes;
            ADODB.Recordset rs;
            String sql;
            sql = "SELECT COUNT(*) as Likes FROM Reacciona WHERE id_post = '" + post + "' AND reaccion = 'corazon'; ";
            if (!Program.con.CheckConn())
            {
                MessageBox.Show("Error: La sesión del usuario esta cerrada.");
                Likes = "Err01";
            }
            else
            {
                rs = Program.cn.Execute(sql, out Program.dump);


                if (!rs.EOF)
                {
                    Likes = rs.Fields["Likes"].Value.ToString();
                }
                else Likes = "0";
            }
            return Likes;

        }

        public Boolean IsLiked(string post) 
        {
            ADODB.Recordset rs;
            String sql;
            sql = "select * from Reacciona where id_post = '" + post + "' AND id_usuario = '" + Program.userid + "'";
            if (!Program.con.CheckConn())
            {
                MessageBox.Show("Error: La sesión del usuario esta cerrada.");
                return false;
            }
            else
            {
                rs = Program.cn.Execute(sql, out Program.dump);

                if (!rs.EOF)
                {
                    //Usuario dio like
                    return true;
                }
                else return false;
            }
        }


        public DataTable SelectPostComm(string post)
        {

            DataTable dt = new DataTable();
            ADODB.Recordset rs;
            String sql;
            sql = "SELECT * from verposts WHERE Post = '" + post + "'";
            if (!Program.con.CheckConn())
            {
                MessageBox.Show("Error: La sesión ha sido cerrada.");
            }
            rs = Program.cn.Execute(sql, out Program.dump);

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
            return dt;
        }

        public void CargarPost()
        {
            Program.frmPrincipal.flowLayoutPanel1.Controls.Clear();

            string usu;
            string txt;
            string img;
            string id;
            string likes;
            Boolean liked;
            //selectUserPosts("IS NOT NULL"); //obtiene los post de todos los usuarios, para un solo usuario usar ("= 'usuario'")
            foreach (DataRow row in selectUserPosts("IS NOT NULL").Rows)
            {
                usu = (string)row["Usuario"];
                txt = (string)row["Texto"];
                img = (string)row["Imagen"];
                id = (string)row["Post"];
                likes = SelectPostLikes(id);
                liked = IsLiked(id);

                var ucPosts = new ucPosts();
                ucPosts.cargarUsu = usu;
                ucPosts.CargarTxt = txt;
                ucPosts.CargarImg = Path.Combine(Application.StartupPath, "Resources", "MM") + @"\" +img;
                ucPosts.CargarID = id;
                ucPosts.cargarLikes = likes;
                ucPosts.userLiked = liked;
                ucPosts.Width = Program.frmPrincipal.flowLayoutPanel1.ClientSize.Width;
                Program.frmPrincipal.flowLayoutPanel1.Controls.Add(ucPosts);
            }

        }

        public void crearPost(string texto, string img) { // SI EL USUARIO TIENE LOS PRIVILEGIOS DE INSERT EN POST Y PUBLICA, DEBERÍA DE PODER CREAR UN POST CON SU USUARIO.
            string sql;
            if (!Program.con.CheckConn())
            {
                MessageBox.Show("Error: La sesión del usuario esta cerrada.");
            }
            else {

                sql = "call creaPost('" + Program.userid + "', '" + texto +"', '" + img +"')";
                Program.cn.Execute(sql, out Program.dump);
            }
        }

        public void CrearCom(string texto, string post) {
            string sql;
            if (!Program.con.CheckConn())
            {
                MessageBox.Show("Error: La sesión del usuario esta cerrada.");
            }
            else
            {
                sql = "insert into Comenta(id_usuario, id_post, fecha, comentario) values('" + Program.userid + "', '" + post + "', NOW(),'" + texto + "')";
                Program.cn.Execute(sql, out Program.dump);
            }
        }
        public void LikePost(string post) { 
            // Falta hacer
        }

        public void CargarComs(string postid) {
            string usu;
            string txt;
            string id;
            foreach (DataRow row in SelectPostComm(postid).Rows)
            {
                usu = (string)row["Usuario"];
                txt = (string)row["Comentario"];
                id = (string)row["Post"];

                var ucComentario = new ucComentario();
                ucComentario.cargarNombre = usu;
                ucComentario.cargarComentario = txt;
                ucComentario.Width = Program.frmPost.flowLayoutPanel1.ClientSize.Width;
                ucComentario.guna2Panel1.Width =
                ucComentario.txtComentario.Width = Program.frmPost.flowLayoutPanel1.ClientSize.Width;
                Program.frmPost.flowLayoutPanel1.Controls.Add(ucComentario);
            }
        }


    }
    
}
