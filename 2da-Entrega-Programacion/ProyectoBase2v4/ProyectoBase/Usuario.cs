using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ProyectoBase
{
    class Usuario
    {
        ADODB.Connection cn = new ADODB.Connection();
        Conexion con = new Conexion();
        public String ObtenerPais() {
            IpInfo ipInfo = new IpInfo();
            string info = new System.Net.WebClient().DownloadString("https://ipinfo.io");

            return info;
        }

        class IpInfo {
            string Pais { get; set; }
        }
        public void CreoUsuario(String usu, String nom, String ape, String edad, String gen, String tel, String mail, String pass)
        {
            if (con.CheckConn() == false)
            {
                /*
                ADODB.Recordset rs;
                String sql;
                try
                {
                    Program.con.OpConn("UserCheck", "Xk9rr!23=!0A");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al conectarse a la Base de Datos");
                }

                sql = "SELECT * FROM Usuario where id_usuario = '" + usu + "';";
                rs = Program.cn.Execute(sql, out Program.dump);
                if (rs.RecordCount == 0)        // rs = 0 significa que no encontró el usuario en la bdd
                {
                    //Program.cn.Close();           // Quizas tenga que crear un usuario con solo insert en la tabla usuario
                    try
                    {
                        Program.con.OpConn(usu, pass);

                        Program.frmLogin.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Usuario o contraseña Incorrectos");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no existe");      //Cambiar el texto para que no sea tan informativo
                    Program.cn.Close();
                }*/
            }
            else MessageBox.Show("La conexion con la base de datos ya está abierta"); 
                

                /*sql = "CREATE USER '" + usu + "'@'localhost' IDENTIFIED BY '" + pass + "';";
                Program.cn.Execute(sql, out Program.dump);
                sql = "INSERT INTO Usuario VALUES('" + usu + "', '" + nom + "', '" + ape + "', '" + edad + "', 'aaa', 'default.jpg', '" + gen + "', 'Online', sysdate(), '" + tel + "', '" + mail + "');";
                Program.cn.Execute(sql, out Program.dump);
                sql = "GRANT SELECT ON miodbc.* TO '" + usu + "'@localhost;";
                Program.cn.Execute(sql, out Program.dump);
                MessageBox.Show("USUARIO CREADO EXITOSAMENTE");*/


        }

        public void ValidoUsuario(String usu, String pass)
        {
            if (con.CheckConn() == false)     
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

                sql = "SELECT id_usuario FROM Usuario where id_usuario = '" + usu + "';";
                rs = con.Ejecutar(sql);                           
                Program.userid = usu;                                                         
                if (!rs.EOF)                        
                {
                    con.CCon();
                    try
                    {
                        con.OpConn(usu, pass);
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
