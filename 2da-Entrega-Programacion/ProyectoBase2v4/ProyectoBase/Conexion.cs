using ADODB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase
{
    class Conexion {
        ADODB.Connection cn = new();
        object dump;

        public Boolean CheckConn() {
            if (cn.State == 0) {
                return false; //LA CONEXION ESTA CERRADA. MODO INVITADO.     
            }
            else {
            return true; //CONEXION ABIERTA. CARGANDO DATOS.
            }
                         
        }

        public Recordset Ejecutar(string sentencia) {
            Recordset rs = new Recordset();
            if (cn.State == 0)
            {
                rs = cn.Execute(sentencia, out dump);
                MessageBox.Show("Recordset :|: " + rs.GetString() + " :|: " + rs.GetRows());
            }
                return rs;
        }

        public void OpConn(String usu, String pass) {       //ABRIR CONEXION CON EL USUARIO Y CONSTRASEÑA INSERTADOS
            cn.Open("MiODBC", usu, pass);
            cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
            cn.Execute("USE bdd", out Program.dump);
        }
        public void CCon() {
            if (CheckConn())
            {
                Program.userid = "Invitado";
                cn.Close();
            }
        }        
        
    }
}
