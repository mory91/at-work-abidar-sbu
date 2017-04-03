using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace at_work_abidar_sbu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        /// 
        private static readonly log4net.ILog log =
    log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [STAThread]
        static void Main()
        {
            log.Info("Program Started");
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
