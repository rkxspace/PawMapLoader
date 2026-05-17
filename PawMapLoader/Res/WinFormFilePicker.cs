using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct OpenFileName
    {
        public int    lStructSize;
        public IntPtr hwndOwner;
        public IntPtr hInstance;
        public string lpstrFilter;
        public string lpstrCustomFilter;
        public int    nMaxCustFilter;
        public int    nFilterIndex;
        public string lpstrFile;
        public int    nMaxFile;
        public string lpstrFileTitle;
        public int    nMaxFileTitle;
        public string lpstrInitialDir;
        public string lpstrTitle;
        public int    Flags;
        public short  nFileOffset;
        public short  nFileExtension;
        public string lpstrDefExt;
        public IntPtr lCustData;
        public IntPtr lpfnHook;
        public string lpTemplateName;
    }

    public class OpenFileDialog
    {
        public string FileName { get; private set; } = "";
        public string Filter   { get; set; } = "All Files\0*.*\0";
        public string Title    { get; set; } = "Open";

        [DllImport("comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetOpenFileName(ref OpenFileName ofn);

        [DllImport("comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetSaveFileName(ref OpenFileName ofn);

        public bool ShowDialog()
        {
            var ofn = new OpenFileName();
            ofn.lStructSize = Marshal.SizeOf(ofn);
            ofn.lpstrFilter = Filter;
            ofn.lpstrFile   = new string('\0', 260);
            ofn.nMaxFile    = ofn.lpstrFile.Length;
            ofn.lpstrTitle  = Title;
            ofn.Flags       = 0x00080000 | 0x00001000 | 0x00000800;

            if (GetOpenFileName(ref ofn))
            {
                FileName = ofn.lpstrFile;
                return true;
            }
            return false;
        }
    }

    public class SaveFileDialog
    {
        public string FileName { get; private set; } = "";
        public string Filter   { get; set; } = "All Files\0*.*\0";
        public string Title    { get; set; } = "Save";

        [DllImport("comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetSaveFileName(ref OpenFileName ofn);

        public bool ShowDialog()
        {
            var ofn = new OpenFileName();
            ofn.lStructSize = Marshal.SizeOf(ofn);
            ofn.lpstrFilter = Filter;
            ofn.lpstrFile   = new string('\0', 260);
            ofn.nMaxFile    = ofn.lpstrFile.Length;
            ofn.lpstrTitle  = Title;
            ofn.Flags       = 0x00080000 | 0x00000002;

            if (GetSaveFileName(ref ofn))
            {
                FileName = ofn.lpstrFile;
                return true;
            }
            return false;
        }
    }
}