﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace ProyectoBase
{
    class Post
    {
        Conexion con = Program.con;
        ADODB.Connection cn = Program.cn;

        bool invitado = false;

        public DataTable selectUC(string post, string usu) {
            DataTable dt = new DataTable();
            ADODB.Recordset rs;
            String sql; 
            if (post is null) {
                sql = $"select * from verposts where Usuario {usu}";
            } else { 
                sql = $"SELECT * from vercomentarios WHERE Post = '{post}'";
            }


            try
            {
                if (!con.CheckConn())
            {
                con.OpConn("PostLoader", "Xkjjk)923=!1f");
                invitado = true;
            }
                rs = con.Ejecutar(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                return dt;
            }

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
            if (invitado) {
                con.CCon();
                invitado = false;
            }
            return dt;
        }

        public string SelectPostLikes(string post)
        {
            string Likes;
            ADODB.Recordset rs;
            String sql;
            sql = "SELECT COUNT(*) as Likes FROM likes WHERE Post = '" + post + "'";
            if (!con.CheckConn())
            {
                //MessageBox.Show("Error1: La sesión del usuario esta cerrada.");
                //Likes = "Err01";
                con.OpConn("PostLoader", "Xkjjk)923=!1f");
                invitado = true;

            }
            rs = con.Ejecutar(sql);


            if (!rs.EOF)
            {
                Likes = rs.Fields["Likes"].Value.ToString();
            }
            else Likes = "0";

            if (invitado)
            {
                con.CCon();
                invitado = false;
            }
            return Likes;

        }

        public Boolean IsLiked(string post) 
        {
            ADODB.Recordset rs;
            String sql;
            sql = "SELECT * FROM likes WHERE Post = '" + post + "' AND Usuario = NombreUsuario();";
            if (!con.CheckConn())
            {
                return false;
            }
            else
            {
                rs = con.Ejecutar(sql);

                if (rs.EOF && rs.BOF)
                {
                    // Usuario no dio like
                    return false;
                }
                else
                {
                    // Usuario dio like
                    return true;
                }
            }
        }

        public Boolean isSaved(string post) {
            ADODB.Recordset rs;
            String sql;
            sql = "SELECT * FROM verguardados WHERE Post = '" + post + "' AND GUsuario = NombreUsuario();";
            if (!con.CheckConn())
            {
                return false;
            }
            else
            {
                rs = con.Ejecutar(sql);

                if (rs.EOF && rs.BOF)
                {
                    // Usuario no guardo post
                    return false;
                }
                else
                {
                    // Usuario guardo post
                    return true;
                }
            }
        }

        public void CargarPost(string qes, string usu2, frmPerfil perfil)
        {
            FlowLayoutPanel a;
            switch (qes) {
                case "principal":
                    usu2 = "IS NOT NULL";
                    a = Program.frmPrincipal.flowLayoutPanel1;
                    break;
                case "perfil":
                    usu2 = $"= '{usu2}'";
                    a = perfil.flowLayoutPanel1;
                    break;
                default:
                    a = Program.frmPrincipal.flowLayoutPanel1;
                    MessageBox.Show("ERROR!!!!!!");
                    break;
            }
            a.Controls.Clear();

            string usu;
            string txt;
            string img;
            string id;
            string likes;
            Boolean liked;
            Boolean saved;
            if (!con.CheckConn()) {

                con.OpConn("PostLoader", "Xkjjk)923=!1f");
                invitado = true;
            }
            DataTable talba = selectUC(null, usu2);
            foreach (DataRow row in talba.Rows)
            {
                usu = (string)row["Usuario"];
                txt = (string)row["Texto"];
                img = (string)row["Imagen"];
                id = (string)row["Post"];
                likes = SelectPostLikes(id);
                liked = IsLiked(id);
                saved = isSaved(id);

                var ucPosts = new ucPosts();
                ucPosts.cargarUsu = usu;
                ucPosts.CargarTxt = txt;
                ucPosts.CargarImg = Path.Combine(Application.StartupPath, "Resources", "MM") + @"\" +img;
                ucPosts.CargarID = id;
                ucPosts.cargarLikes = likes;
                ucPosts.userLiked = liked;
                ucPosts.userSaved = saved;
                ucPosts.Width = a.ClientSize.Width;
                a.Controls.Add(ucPosts);
            }

        }

        public void crearPost(string texto, string img) { // SI EL USUARIO TIENE LOS PRIVILEGIOS DE INSERT EN POST Y PUBLICA, DEBERÍA DE PODER CREAR UN POST CON SU USUARIO.
            string sql;
            if (!con.CheckConn())
            {
                MessageBox.Show("Error1: La sesión del usuario esta cerrada.");
            }
            else {

                sql = "call creaPost('" + texto +"', '" + img +"')";
                con.Ejecutar(sql);
            }
        }

        public void CrearCom(string texto, string post) {
            string sql;
            if (!con.CheckConn())
            {
                MessageBox.Show("Error: La sesión del usuario esta cerrada.");
            }
            else
            {
                sql = "CALL pubCom('" + post + "','" + texto + "')";
                con.Ejecutar(sql);
            }
        }
        public void LikePost(string post) {
            string sql;
            if (con.CheckConn()) {
                if (IsLiked(post)) { //Usuario ya dio like, hay que quitarlo.
                    sql = "CALL quitarLike('" + post + "')";
                }
                else sql = "CALL darLike('" + post +"')";
                con.Ejecutar(sql);
            }
        }


        public void guardarPost(string post) {
            string sql;
            if (con.CheckConn())
            {
                if (isSaved(post))
                { //Usuario ya guardo post, hay que quitarlo.
                    sql = "CALL quitarGuardarPost('" + post + "')";
                }
                else sql = "CALL guardarPost('" + post + "')";
                con.Ejecutar(sql);
            }
        }

        public void compartirPost(string post)
        {
            string sql;
            if (con.CheckConn())
            {
                sql = $"CALL compartirPost('{post}')";
                con.Ejecutar(sql);
            }
        }

    }
    
}
