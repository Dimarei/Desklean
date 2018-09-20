using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//just an c
namespace Desklean
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
           
            
            MessageService service = new MessageService();
            FilesLogic logic = new FilesLogic();
            ucSettings ucSettings = new ucSettings(service);
            ucHome ucHome = new ucHome();
            ucHelp ucHelp = new ucHelp();
            MainForm form = new MainForm(ucSettings,ucHome,ucHelp);


            MainPresenter presenter = new MainPresenter(form, service, logic,ucSettings,ucHome,ucHelp);

            Application.Run(form);
        }
    }
}
