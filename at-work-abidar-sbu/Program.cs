using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace at_work_abidar_sbu
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
            Application.Run(new MainForm());
           // Application.Run(new ObjectRecognitionTestForm());
//            SVMTraining svmTraining = new SVMTraining();
//            svmTraining.train();
//            Application.Run(new ArmControl());
//            Application.Run(new ObjectRecognitionTestForm());
//            Listener listener = new Listener();
//            listener.startListener();
        }
    }
}
