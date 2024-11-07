using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ProyectoBase
{
    class Usuario
    {
        ADODB.Connection cn = Program.cn;
        Conexion con = Program.con;

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

    }
}
