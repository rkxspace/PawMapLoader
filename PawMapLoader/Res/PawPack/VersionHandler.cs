using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MelonLoader;

namespace PawMapLoader.Res.PawPack
{
    public class VersionHandler
    {
        public static byte[] ExpectedHeader = { 0x5F, 0x50, 0x4D, 0x4C, 0x5F, 0x00, 0x4D, 0x41, 0x50, 0x50, 0x41, 0x43, 0x4B, 0x00};

        private static Dictionary<byte[], Unpacker> UnpackVersions = new Dictionary<byte[], Unpacker>
        {
            {new byte[] {0x30,0x30,0x30,0x31}, V1.Unpacker.Unpack}
        };

        public static Task<string> ShowFilePicker()
        {
            var filepicker = new OpenFileDialog { Filter = "PawPack Files (*.pawpack)\0*.pawpack", Title = "Install a Map Pack"};
            return Task.FromResult(filepicker.ShowDialog() ? filepicker.FileName : string.Empty);
        }

        public static void UnpackEntry()
        {
            MelonCoroutines.Start(waitForFilePick());
            IEnumerator waitForFilePick()
            {
                var filepickerTask = ShowFilePicker();
                while (!filepickerTask.IsCompleted) yield return null;
                if (filepickerTask.Result != string.Empty) Unpack(filepickerTask.Result);
            }
        }

        public static void Unpack(string filepath)
        {
            byte[] file = File.ReadAllBytes(filepath);
            byte[] header = new byte[ExpectedHeader.Length];
            byte[] version = new byte[4];
            byte[] data = new byte[file.Length - (version.Length+header.Length+1)];

            Buffer.BlockCopy(file, 0, header, 0, header.Length);
            if (!ExpectedHeader.SequenceEqual(header)) throw new InvalidDataException($"File is not PAWPACK, or file is corrupt. (Header Invalid)\nExpected: {ExpectedHeader}\nReceived: {header}");

            Buffer.BlockCopy(file, header.Length, version, 0, version.Length);
            
            Buffer.BlockCopy(file, version.Length+header.Length+1, data , 0, data.Length);
            UnpackVersions[version](data);
        }

        private delegate void Unpacker(byte[] data);
    }
}