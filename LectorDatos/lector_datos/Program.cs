using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lectorDatos
{
    static class Program
    {
        public static MySqlConnection con;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
