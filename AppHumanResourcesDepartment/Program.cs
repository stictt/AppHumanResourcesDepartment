using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppHumanResourcesDepartment.Service;
using AppHumanResourcesDepartment.View;

namespace AppHumanResourcesDepartment
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationBuilderService.Run();

            Application.Run(new DesktopForm());
        }
    }
}
