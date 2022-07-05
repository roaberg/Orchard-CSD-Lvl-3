using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orchard_CSD_Lvl_3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OrchardManager om = new OrchardManager();
            om.LoadData(ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home(om));
        }
    }
}
