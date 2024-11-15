using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoBase
{
    class Usuario
    {
        ADODB.Connection cn = Program.cn;
        Conexion con = Program.con;
        Post pst = Program.pst;

        public String ObtenerPais() {
            string info = new System.Net.WebClient().DownloadString("https://ipinfo.io");
            var jsonObj = JObject.Parse(info);
            info = jsonObj["country"]?.ToString();

            return info;
        }

        public void CreoUsuario(String usu, String nom, String ape, String edad, String gen, String tel, String mail, String pass)
        {
            if (con.CheckConn() == false)
            {
                if (!con.CheckConn())
                {
                    ADODB.Recordset rs;
                    String sql;

                    try
                    {
                        con.OpConn("UserCheck", "Xk9rr!23=!0A");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al conectarse a la Base de Datos");
                    }

                    sql = "SELECT * FROM verUsu where Usuario = '" + usu + "';";
                    rs = con.Ejecutar(sql);

                    if (rs.EOF)
                    {
                        sql = $"CALL solicitudUsuario('{usu}', '{nom}', '{ape}', '{edad}', '{mail}', '{ObtenerPais()}', '{gen}', '{tel}', '{pass}');";
                        con.Ejecutar(sql);
                        con.CCon();
                    }
                    else
                    {
                        MessageBox.Show("El nombre de usuario ya existe");
                        con.CCon();
                    }
                }
                else
                {
                    con.CCon();
                    CreoUsuario(usu, nom, ape, edad, gen, tel, mail, pass);
                }


            }
        }

        public void ValidoUsuario(String usu, String pass)
        {
            if (!con.CheckConn())     
            {
                ADODB.Recordset rs;                  
                String sql;

                try                                 
                {
                    con.OpConn("UserCheck", "Xk9rr!23=!0A");
                }
                catch (Exception)                     
                {
                    MessageBox.Show("Error al conectarse a la Base de Datos");
                }

                sql = "SELECT * FROM verUsu where Usuario = '" + usu + "';";
                rs = con.Ejecutar(sql);   
                
                if (!rs.EOF)                        
                {
                    con.CCon();
                    try
                    {
                        con.OpConn(usu, pass);
                        Program.userid = usu;
                        Program.frmLogin.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Usuario o contraseña Incorrectos");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña Incorrectos");      //Anteriormente era "Usuario ingresado no existe"
                    con.CCon();
                }
            }
            else { 
                con.CCon();
                ValidoUsuario(usu, pass);
            }
            
        }

        public DataTable ObtenerPerfil(string usu) {
            DataTable dt = new DataTable();
            ADODB.Recordset rs;
            Boolean invitado = false;
            String sql;

            sql = "SELECT * FROM verUsu where Usuario " + usu;
            if (!con.CheckConn())
            {
                con.OpConn("PostLoader", "Xkjjk)923=!1f");
                invitado = true;
            }
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
            if (invitado)
            {
                con.CCon();
                invitado = false;
            }
            return dt;
        }

        public void cargarUsuario(string usuario, frmPerfil perfil)
        {
            usuario = $"= '{usuario}'";

            DataTable talba = ObtenerPerfil(usuario);
            foreach (DataRow row in talba.Rows){
                var ucPerfil = new ucPerfil();
                ucPerfil.CargarUsu = (string)row["Usuario"];
                ucPerfil.CargarNom = (string)row["Nombre"];
                ucPerfil.CargarApe = (string)row["Apellido"];
                ucPerfil.CargarEdad = (string)row["Edad"];
                ucPerfil.CargarMail = (string)row["Mail"];
                ucPerfil.CargarDesc = (string)row["Dcr"];

                ucPerfil.Dock = DockStyle.Fill;
                perfil.splitContainer1.Panel1.Controls.Add(ucPerfil);
            }

        }
    }
}
