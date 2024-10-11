using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase
{
    class Conexion {
        public Boolean CheckConn() {
            if (Program.cn.State == 0) {
                return false; //LA CONEXION ESTA CERRADA. MODO INVITADO.
            }
            return true; //CONEXION ABIERTA. CARGANDO DATOS.
        }

        public void OpConn(String usu, String pass) {       //ABRIR CONEXION CON EL USUARIO Y CONSTRASEÑA INSERTADOS
            Program.cn.Open("MiODBC", usu, pass);
            Program.cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
            Program.cn.Execute("USE bd", out Program.dump);
        }
        public void CCon() {
            Program.userid = "Invitado";
            Program.cn.Close();
        }        
        
    }
}
