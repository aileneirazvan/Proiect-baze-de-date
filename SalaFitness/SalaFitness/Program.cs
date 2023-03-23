using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace SalaFitness
{
    static class Program
    {
        public static string user = "system";
        public static string pwd = "Lkbfsauip88!";
        public static string db = "localhost/orcl";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string conStringUser = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";
            OracleConnection con = new OracleConnection(conStringUser);


            OracleCommand cmd = con.CreateCommand();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(cmd, con));
        }
    }
}
