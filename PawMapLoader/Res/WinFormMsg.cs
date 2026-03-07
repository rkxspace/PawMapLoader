using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    public static class MessageBox
    {
        public enum MessageBoxButtons : uint
        {
            OK = 0x00000000,
            OKCancel = 0x00000001,
            YesNo = 0x00000004,
        }

        public enum MessageBoxIcon : uint
        {
            Error = 0x00000010,
            Warning = 0x00000030,
            Information = 0x00000040,
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = false)]
        private static extern int MessageBoxW(IntPtr hWnd, string text, string caption, uint type);

        public static void Show(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBoxW(IntPtr.Zero, text, caption, (uint)buttons | (uint)icon);
        }
    }
}