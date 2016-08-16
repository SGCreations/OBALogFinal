using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBALog.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Visual Studio 2013 Light";
                DevExpress.Skins.SkinManager.EnableFormSkins();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Control.CheckForIllegalCrossThreadCalls = false;
                Application.Run(new ManageOrganisations());
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Message : {0}{1}{2}StackTrace : {3}{4}", Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.StackTrace));
            }
        }
    }
}
