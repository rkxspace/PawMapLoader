using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PawMapLoader.Res
{
    public class NTCheck
    {
        public static bool Wine;

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        public static void WineCheck()
        {
            IntPtr moduleHandle = GetModuleHandle("ntdll.dll");
            if (moduleHandle == IntPtr.Zero)
            {
                MessageBox.Show("O_O", "Could not get ntdll.\n" +
                                       "You might want to check your PC.");
                return;
            }

            Wine = GetProcAddress(moduleHandle, "wine_get_version") != IntPtr.Zero;
        }
    }
}