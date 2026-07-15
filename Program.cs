using System;
using System.Windows.Forms;
using SingleSnapShot.Services;

namespace SingleSnapShot
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                TeklaService.Initialise();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Phase Snapshot Creator");
                return;
            }

            Application.Run(new CreateSnapShot());
        }
    }
}
