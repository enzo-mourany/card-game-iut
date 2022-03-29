using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame2022
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Basic init, do not change
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #endregion
            //MessageBox.Show("Hello.");
            GameController gameController = new GameController(2);  // New GameController, GameLogic
            Application.Run(new MainWindow(gameController)); // New MainWindow
        }
    }
}
