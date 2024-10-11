using System;
using System.Windows.Forms;



namespace ProyectoBase
{
    

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static frmPrincipal frmPrincipal;
        public static frmPerfil frmPerfil;
        public static frmChats frmChats;
        public static frmLogin frmLogin;
        public static Comunidades frmComunidades;
        public static Evento frmEvento;
        public static Notificaciones frmNotificaciones;
        public static frmPost frmPost;
        public static frmCrearPost frmCrearPost;
        public static ADODB.Connection cn = new ADODB.Connection();
        public static Conexion con = new Conexion();
        public static Post pst = new Post();
        public static object dump;
        public static Random rnd = new Random();
        public static string userid;


        public static string CrearString(int largo)
        {
            const string chr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[largo];

            for (int i = 0; i < largo; i++)
            {
                chars[i] = chr[rnd.Next(0, chr.Length)];
            }

            return new string(chars);
        }

        public static string RsAString(ADODB.Recordset rs)
        {
            if (rs == null || rs.EOF)
            {
                return "null";
            }

            string resultado = "null";
            int fieldCount = rs.Fields.Count;

            if (!rs.EOF)
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    string n = rs.Fields[i].Name;
                    object v = rs.Fields[i].Value;

                    resultado = $"{v}";
                }
            }

            return resultado;
        }

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // ApplicationConfiguration.Initialize();
            Application.Run(frmPrincipal = new frmPrincipal());
        }
    }
}