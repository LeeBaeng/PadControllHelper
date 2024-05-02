using System.Diagnostics;

namespace PadControlHelper {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            if(IsExistProcessMutex(Process.GetCurrentProcess().ProcessName)) {
                MessageBox.Show("LeeBaeng PCH가 이미 실행 중입니다.", "중복 실행 불가");
            } else {
                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            //Application.Run(new Form1());
        }

        private static bool IsExistProcessMutex(string processName) {
            new Mutex(true, processName, out bool createdNew);
            return !createdNew;
        }
    }
}