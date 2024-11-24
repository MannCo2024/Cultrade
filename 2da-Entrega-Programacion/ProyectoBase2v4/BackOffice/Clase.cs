using ADODB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOffice
{
    internal class Clase
    {
        Connection cn = Program.cn;
        Clase cls = Program.cls;
        object dump;

        public Boolean CheckConn()
        {
            if (cn.State == 0)
            {
               return false; //LA CONEXION ESTA CERRADA. MODO INVITADO.     
            }
            else
            {
                return true; //CONEXION ABIERTA. CARGANDO DATOS.
            }

        }

        public Recordset Ejecutar(string sentencia)
        {
            Recordset rs = new Recordset();
            if (cn.State != 0)
            {
                rs = cn.Execute(sentencia, out dump);
            }

            return rs;
        }
        public void CCon()
        {
            if (CheckConn())
            {
                cn.Close();
            }
        }
        public void OpConn(String usu, String pass)
        {       //ABRIR CONEXION CON EL USUARIO Y CONSTRASEÑA INSERTADOS
            try
            {
                cn.Open("MiODBC", usu, pass);
                cn.CursorLocation = CursorLocationEnum.adUseClient;
                cn.Execute("USE bdd", out dump);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :: " + ex.Message + " ::  :: " + ex.Source + " :: :: " + ex.StackTrace + " :: :: " + ex.InnerException);
            
            }
        }

        public DataTable selectInfo(int selec)
        {
            if (!CheckConn()) 
            {
                OpConn("Backoffice", "Backoffice");
            }
            
            DataTable dt = new DataTable();
            Recordset rs;
            String sql;
            string opc;

            switch (selec) {
                case 1: //Pendientes
                    opc = "= 'Pendiente'";
                    break;
                case 2: //Completadas
                    opc = "!= 'Pendiente'";
                    break;
                case 3: //Rechazadas
                    opc = "= 'Rechazado'";
                    break;
                case 4: //Aceptadas
                    opc = "= 'Aceptado'";
                    break;
                default: //Todas
                    opc = "IS NOT NULL";
                    break;
            }

            sql = "SELECT * FROM verSolicitudes WHERE Estado " + opc;
            try
            {
                rs = Ejecutar(sql);
            }
            catch {
                MessageBox.Show("umm guys..");
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
            return dt;
        }

        public void ValidoUsuario(String usu, String pass)
        {
            if (!CheckConn())
            {
                ADODB.Recordset rs;
                String sql;

                try
                {
                    OpConn("UserCheck", "Xk9rr!23=!0A");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al conectarse a la Base de Datos");
                }

                sql = "SELECT * FROM usuBO where Usuario = '" + usu + "';";
                rs = Ejecutar(sql);

                if (!rs.EOF)
                {
                    CCon();
                    try
                    {
                        OpConn(usu, pass);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Usuario o contraseña Incorrectos");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña Incorrectos");      //Anteriormente era "Usuario ingresado no existe"
                    CCon();
                }
            }
            else
            {
                CCon();
                ValidoUsuario(usu, pass);
            }

        }

    }

}
