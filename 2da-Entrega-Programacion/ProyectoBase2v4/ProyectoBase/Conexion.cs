using ADODB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase
{
    class Conexion
    {
        ADODB.Connection cn = Program.cn;
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
            if (cn.State != 0)
            {
                rs = cn.Execute(sentencia, out dump);
            }

            return rs;
        }

        public void OpConn(String usu, String pass) {       //ABRIR CONEXION CON EL USUARIO Y CONSTRASEÑA INSERTADOS
            try
            {
                cn.Open("MiODBC", usu, pass);
                cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
                cn.Execute("USE mannco", out Program.dump);
            }
            catch (Exception ex){
                MessageBox.Show("ERROR!!::" + ex.Message + " :: DE PARTE DE :: " + ex.Source + " :: " + ex.StackTrace + " :: " + ex.InnerException);
            };
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
