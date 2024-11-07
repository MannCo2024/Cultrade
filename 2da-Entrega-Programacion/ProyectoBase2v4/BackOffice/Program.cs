using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOffice
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        
        public static SolCre SolicitudCuentas;
        public static SolRep SolicitudReportes;

        public static Clase cls = new Clase();
        public static ADODB.Connection cn = new ADODB.Connection();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BackOffice());
        }
    }
}
