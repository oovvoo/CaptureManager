using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CaptureManager
{
    public class ProcessManager
    {

        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern int IsIconic(IntPtr hWnd);

        /**
         * 메인윈도우 핸들을 가지고있는(화면 윈도우를 가지고 있는 == 백그라운드 프로세스가 아닌) 프로세스 목록을 리턴
         */
        public static Process[] getWindowProcesses()
        {
            try
            {
                return Process.GetProcesses().Where(pr => pr.MainWindowHandle != IntPtr.Zero).ToArray();
            }
            catch
            {
                return null;
            }
        }

        public static Process getProcessByName(string name)
        {
            try{

                Process proc = getWindowProcesses().Where(p => p.ProcessName.ToLower().Contains(name.ToLower())).First();
                setProcessShow(proc);
                return proc;
            }catch
            {
                return null;
            }

        }

        public static void setProcessShow(Process p)
        {
            //Process가 최소화 된 경우 복원 후 리턴함
            if (IsIconic(p.MainWindowHandle) != 0)
                ShowWindow(p.MainWindowHandle, SW_RESTORE);

        }
    }
}
