using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace gta5SoloSession
{
    public static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern uint SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        private static extern int ResumeThread(IntPtr hThread);

        public static void Main()
        {
            Console.Title = "GTA5 1인 공개 세션 생성기 Made by green1052";

            Process[] processes = Process.GetProcessesByName("GTA5");

            if (processes.Length <= 0)
            {
                Console.WriteLine("GTA5가 실행되지 않았습니다.\n아무 키나 눌러 종료하십시오.");
                Console.ReadKey();

                return;
            }

            SuspendThread(processes[0].Handle);

            Console.WriteLine("GTA5를 일시 중지 했습니다.");

            Thread.Sleep(5000);

            ResumeThread(processes[0].Handle);

            Console.WriteLine("GTA5를 재개했습니다.\n아무 키나 눌러 종료하십시오.");

            Console.ReadKey();
        }
    }
}